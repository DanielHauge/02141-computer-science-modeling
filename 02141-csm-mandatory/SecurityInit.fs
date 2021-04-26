module SecurityInit
open AST
open Auxliary

type SecurityClass = string
type SecurityLattice = Map<SecurityClass, Set<SecurityClass>>
type SecurityRule = SecurityClass*SecurityClass
type SecurityPolicy = (Var*SecurityClass)
type SecurityPolicies = SecurityPolicy list

type SecurityConfig = { template : string; policy: string }


let parse_policy (s:string) :  (Var*SecurityClass) =
    let split = Array.toList (s.Split '=')
    (split.Item 0,  split.Item 1)

let parse_policies (s:string) : SecurityPolicies =
    let policies = Array.toList ( s.Replace(" ","").Split ',' )
    List.map (fun a -> parse_policy a) policies

let parse_rule (s:string) : SecurityRule =
    let split = Array.toList (s.Split '<')
    (split.Item 0,  split.Item 1)

let parse_templates (template:string) : SecurityRule list =
    let rules = Array.toList ( template.Replace(" ","").Split ',' )
    List.map (fun a -> parse_rule a) rules
    
let add_new_dir (current:SecurityLattice) (from:SecurityClass) (too:SecurityClass) : SecurityLattice =
    let curFromList = match current.TryFind from with | Some a -> a | None -> Set.empty
    let curTooList = match current.TryFind too with | Some a -> a | None -> Set.empty
    let newList = Map.add too curTooList (Map.add from (curFromList.Add too) current)
    newList

let rec for_all_sec_rules (rule:SecurityRule list)  (acc:SecurityLattice) : SecurityLattice =
    match rule with
    | [] -> acc
    | (f,t)::tail -> for_all_sec_rules tail (add_new_dir acc f t)

let rec security_classes_transitive_reflexive (sl:SecurityLattice) (sc:SecurityClass) : Set<SecurityClass> =
    match sl.TryFind sc with
    | Some a when a.IsEmpty -> Set.empty.Add sc
    | Some a -> (Set.unionMany (Seq.map (fun x -> security_classes_transitive_reflexive sl x) a)).Add sc
    | None -> failwith "Could not find security class in security lattice"

let security_classes_for_policy (sl:SecurityLattice) (sp:SecurityPolicy) : Set<SecurityClass> = security_classes_transitive_reflexive sl (snd sp)


let flows_for_policy (sl:SecurityLattice) (sp:SecurityPolicy) (allPolicies:SecurityPolicies) : SecurityFlows =
    let validSecurityClassFlows = security_classes_for_policy sl sp
    let variablesUnderValidSecurityClass = List.map (fun (a:SecurityPolicy) -> fst a) (List.filter (fun (a:SecurityPolicy) -> validSecurityClassFlows.Contains (snd a)) allPolicies)
    let flowsForVar = List.map (fun (v:Var) -> (fst sp, v) ) variablesUnderValidSecurityClass
    Set.ofList flowsForVar


let allowed_flows (sp:SecurityConfig) : SecurityFlows =
    

    let rules = parse_templates sp.template
    let securityLattice = for_all_sec_rules rules Map.empty
    let policies = parse_policies sp.policy

    let rec for_all_policies (p:SecurityPolicies) : SecurityFlows =
        match p with
        | [] -> Set.empty
        | head::tail -> Set.union (for_all_policies tail) (flows_for_policy securityLattice head policies)

    for_all_policies policies



let evaluate_security_violations (actual:SecurityFlows) (allowed:SecurityFlows) : SecurityFlows = 
    Set.filter (fun (a:Flow) -> not (allowed.Contains a)) actual

