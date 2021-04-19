module SignAnalyser
open AST
open PGCompiler
open PGEvaluator
open SignEvaluator

type SignOp = P | S | T | D | POW

let rec pairwise a b =
    let rec makePairsForRow c l =
        match l with
        | [] -> []
        | head::tail -> (c,head)::(makePairsForRow c tail)

    match a with
    | [] -> []
    | head::tail -> makePairsForRow head b@(pairwise tail b)

let rec analyse_arithmetic (ari:arithmetic) (m1:AbstractMem) (m2:AbstractMem) : Signs =

    let analyse_arithmetic_op (S1:Signs) (S2:Signs) (op:SignOp) : Signs =
        let signEvaluator = match op with | P -> sign_add | S -> sign_sub | T -> sign_times | D -> sign_divide | POW -> sign_pow
        match (S1, S2) with
        | (ASigns(signs1), ASigns(signs2)) -> ASigns( Set.unionMany (
                                                    Seq.ofList (
                                                        List.map 
                                                            (fun (s1,s2) -> match signEvaluator s1 s2 with | ASigns(evaluatedSigns) -> evaluatedSigns | _ -> failwith "Can only evaulate to arithmetic signs") 
                                                            (pairwise (Set.toList signs1) (Set.toList signs2))
                                                     )
                                                 )
                                            )

    match ari with
    | Num(f) -> ASigns(Set.ofList [ sign (int(f)) ])
    | Str(s) -> m1.Item s
    | ArrayAccess(s,a) -> m1.Item s
    | TimesExpr(a,b) -> analyse_arithmetic_op (analyse_arithmetic a m1 m2) (analyse_arithmetic b m1 m2) T
    | DivExpr(a,b) -> analyse_arithmetic_op (analyse_arithmetic a m1 m2) (analyse_arithmetic b m1 m2) D
    | PlusExpr(a,b) -> analyse_arithmetic_op (analyse_arithmetic a m1 m2) (analyse_arithmetic b m1 m2) P
    | MinusExpr(a,b) -> analyse_arithmetic_op (analyse_arithmetic a m1 m2) (analyse_arithmetic b m1 m2) S
    | PowExpr(a,b) ->  analyse_arithmetic_op (analyse_arithmetic a m1 m2) (analyse_arithmetic b m1 m2) POW
    //| UPlusExpr(a) -> match eval_arithmetic mem a with | Some(i) -> Some(abs(i)) | None -> None
    //| UMinusExpr(a) -> match eval_arithmetic mem a with | Some(i) -> Some(-abs(i)) | None -> None

let rec sign_analyse_pg (initialMem:AbstractMem) (pg:ProgramGraph) : SignAnalysis =
    match pg with
    | (e1, ast, e2)::tail -> []
    | _ -> []


let sign_analyse_abstract_mem (initialMem:Mem) : AbstractMem = Map.map (fun _ v -> ASigns(Set.ofList [sign v])) initialMem

let sign_analyse_pg_mem (initialMem:Mem) (pg:ProgramGraph) : SignAnalysis = sign_analyse_pg (sign_analyse_abstract_mem initialMem) pg

//let print_sign_analysis (a:SignAnalysis) : string =
//    let (ast, node, mem) = es
//    sprintf "Action: %s - Node: %s - Memory: %s" (match ast with | Some(a) -> print_ast_expression a | None -> "N/A") (print_node node) (Newtonsoft.Json.JsonConvert.SerializeObject mem)

    