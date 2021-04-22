module SignAnalyser
open AST
open PGCompiler
open PGEvaluator
open SignEvaluator
open PGPrinter
open Auxliary





let analyse_union_all (S1:Signs) (S2:Signs) (eval:Sign->Sign->Signs) : Signs =
    let pairwise = pairwise (Set.toList S1) (Set.toList S2)
    let evaluated = List.map (fun (s1,s2) -> eval s1 s2) pairwise
    Set.unionMany evaluated

let analyse_arithmetic_op (evalFunc: SignA->SignA->Signs) (s1:Sign) (s2:Sign) : Signs =
    match (s1, s2) with
    | (ASign(sign1), ASign(sign2)) -> evalFunc sign1 sign2
    | _ -> failwith "Cannot eval if not both are arithmetic signs."

let analyse_bool_op (evalFunc: SignB->SignB->Signs) (s1:Sign) (s2:Sign) : Signs =
    match (s1, s2) with
    | (BSign(sign1), BSign(sign2)) -> evalFunc sign1 sign2
    | _ -> failwith "Cannot eval if not both are arithmetic signs."

let analyse_bool_op_unary (evalFunc: SignB->Signs) (s1:Sign) : Signs =
    match s1 with
    | BSign(sign) -> evalFunc sign
    | _ -> failwith "Cannot eval if not both are arithmetic signs."

let rec analyse_arithmetic (ari:arithmetic) (m:AbstractMem) : Signs =
    
    match ari with
    | Num(f) -> map_to_generic_asigns(Set.ofList [ sign (int(f)) ])
    | Str(s) -> match m.TryFind s with | Some v -> v | None -> bsigns_from_list []
    | ArrayAccess(s,a) -> match m.TryFind s with | Some v -> v | None -> bsigns_from_list []
    | TimesExpr(a,b) -> analyse_union_all (analyse_arithmetic a m) (analyse_arithmetic b m) (analyse_arithmetic_op sign_times)
    | DivExpr(a,b) -> analyse_union_all (analyse_arithmetic a m) (analyse_arithmetic b m) (analyse_arithmetic_op  sign_divide)
    | PlusExpr(a,b) -> analyse_union_all (analyse_arithmetic a m) (analyse_arithmetic b m) (analyse_arithmetic_op sign_add)
    | MinusExpr(a,b) -> analyse_union_all (analyse_arithmetic a m) (analyse_arithmetic b m) (analyse_arithmetic_op sign_sub)
    | PowExpr(a,b) ->  analyse_union_all (analyse_arithmetic a m) (analyse_arithmetic b m) (analyse_arithmetic_op sign_pow)
    | UPlusExpr(a) -> asigns_from_list [PLUS; ZERO]
    | UMinusExpr(a) -> asigns_from_list [MINUS; ZERO]

let sign_negate_all = Set.map (fun v -> match v with | BSign(s) -> BSign((sign_negate s)) | _ -> failwith "Expected boolean")


let rec analyse_boolean (boo:bools) (m:AbstractMem): Signs =
    
    
    match boo with
    | True -> bsigns_from_list [TT]
    | False -> bsigns_from_list [FF]
    | And(a,b) -> analyse_union_all (analyse_boolean a m) (analyse_boolean b m) (analyse_bool_op sign_conjunction)
    | Or(a,b) -> analyse_union_all (analyse_boolean a m) (analyse_boolean b m) (analyse_bool_op sign_disjunction)
    | AndAnd(a,b) -> let S1 = (analyse_boolean a m) 
                     let S2 = (analyse_boolean b m)
                     Set.union (Set.difference S1 (bsigns_from_list [FF])) (analyse_union_all S1 S2 (analyse_bool_op sign_conjunction))

    // | OrOr(a,b) -> eval_bool_with_op a b (||)
    | Negate(a) -> sign_negate_all (analyse_boolean a m)
    | Equal(a,b) -> analyse_union_all (analyse_arithmetic a m) (analyse_arithmetic b m) (analyse_arithmetic_op sign_equals)
    | NEqual(a,b) -> sign_negate_all (analyse_union_all (analyse_arithmetic a m) (analyse_arithmetic b m) (analyse_arithmetic_op sign_equals))
    | Gt(a,b) -> analyse_union_all (analyse_arithmetic a m) (analyse_arithmetic b m) (analyse_arithmetic_op sign_gt)
    | Gte(a,b) -> analyse_union_all (analyse_arithmetic a m) (analyse_arithmetic b m) (analyse_arithmetic_op sign_gte)
    | Lt(a,b) ->  sign_negate_all (analyse_union_all (analyse_arithmetic a m) (analyse_arithmetic b m) (analyse_arithmetic_op sign_gte))
    | Lte(a,b) -> sign_negate_all (analyse_union_all (analyse_arithmetic a m) (analyse_arithmetic b m) (analyse_arithmetic_op sign_gt))
    | Par(a) -> analyse_boolean a m
        


let analyse_edge (mem:AbstractMem) (ast:AST) : AbstractMem =

    match ast with
    | S(s) -> failwith "uuh what?"
    | A(a) -> failwith "uuh no"
    | B(b) -> let evaluatedBool = (analyse_boolean b mem) 
              if evaluatedBool.Contains (BSign(TT)) then mem else Map.empty
    | C(Skip) -> mem
    | C(VarAssign(s,a)) -> let abstractMem = (analyse_arithmetic a mem)
                           (mem.Remove s).Add(s, abstractMem)
    | C(ArrayAssign(s,a,b)) -> failwith "do not support array sign analysis yet"
    | GC(gc) -> failwith "meeeh"

    //match ast with
    //| B(b) -> match eval_boolean mem b with | Some(boolean) -> (if boolean then Some(mem) else None) | None -> None
    //| C(Skip) -> Some(mem)
    //| C(VarAssign(s,a)) when mem.ContainsKey s -> match (eval_arithmetic mem a) with | Some(i) -> Some(mem.Add(s, i)) | None -> None
    //| C(ArrayAssign(s,a,b)) when mem.ContainsKey s -> 
    //                let index = eval_arithmetic mem a
    //                let value = eval_arithmetic mem b
    //                if index.IsNone || value.IsNone then None else Some(mem.Add(sprintf "%s[%s]" s (string(index.Value)), val ue.Value))
    //| _ -> None

let merge_abstract_mem (m1:AbstractMem) (m2:AbstractMem) : AbstractMem = 
    Map.fold (fun s k v ->  match Map.tryFind k s with
                            | Some existing -> Map.add k (Set.union existing v) s
                            | None -> Map.add k v s
        ) 
        m1 m2
    

let rec sign_analyse_pg (mem:AbstractMem) (pg:ProgramGraph) (acc:SignAnalysis) : SignAnalysis =
    match pg with
    | (e1, ast, e2, _)::tail ->  let newAbstractmem = analyse_edge mem ast
                                 let analysis = sign_analyse_pg newAbstractmem tail acc
                                 match (analysis.TryFind e2) with 
                                 | Some v -> analysis.Remove(e2).Add(e2, merge_abstract_mem newAbstractmem v)
                                 | None -> analysis.Add(e2, newAbstractmem)
    | _ -> acc


let sign_analyse_abstract_mem (initialMem:Mem) : AbstractMem = Map.map (fun _ v -> asigns_from_list([sign v])) initialMem

let sign_analyse_pg_mem (initialMem:Mem) (pg:ProgramGraph) : SignAnalysis = let abstractMem = (sign_analyse_abstract_mem initialMem) 
                                                                            sign_analyse_pg abstractMem pg (Map.empty.Add(InitialNode, abstractMem))

let print_abstract_sign (s:Sign) : string =
    match s with
    | BSign(TT) -> "TT"
    | BSign(FF) -> "FF"
    | ASign(PLUS) -> "+"
    | ASign(ZERO) -> "0"
    | ASign(MINUS) -> "-"

let print_abstract_signs (s:Signs) : string = Seq.reduce (fun a b -> a + ", " +  b) (Seq.map (fun v -> print_abstract_sign v) s)

let print_abstract_var (v:Var) (s:Signs) : string = sprintf "%s : {%s}" v (print_abstract_signs s)

let print_abstract_memory (n:Node) (mem:AbstractMem) : string =
    let signsString = if mem.Count > 0 then (Seq.reduce (fun a b -> a + " | " +  b) (Seq.map (fun (k,v) -> print_abstract_var k v) (Map.toSeq mem))) else "empty"
    sprintf "q%s - (%s)"  (print_node n) signsString

let rec print_sign_analysis (a:(Node*AbstractMem) list) : string list =
    match a with
    | (node, mem)::tail -> print_abstract_memory node mem::print_sign_analysis tail
    | _ -> []

    