module Security
open AST
open Auxliary


let rec fv_ari (ari:arithmetic) : Set<Var> =
    let unionFunc a b = Set.union (fv_ari a) (fv_ari b)
    match ari with
    | Num(f) -> Set.empty
    | Str(s) -> Set.empty.Add(s)
    | ArrayAccess(s,a) -> (Set.union (Set.empty.Add(s)) (fv_ari a))
    | TimesExpr(a,b) -> unionFunc a b
    | DivExpr(a,b) -> unionFunc a b
    | PlusExpr(a,b) -> unionFunc a b
    | MinusExpr(a,b) ->unionFunc a b 
    | PowExpr(a,b) ->  unionFunc a b
    | UPlusExpr(a) -> fv_ari a
    | UMinusExpr(a) -> fv_ari a


let rec fv_bool (b:bools) : Set<Var> =
    let fv_aries a b = Set.union (fv_ari a) (fv_ari b)
    let fv_bools a b = Set.union (fv_bool a) (fv_bool b)

    match b with
    | True -> Set.empty
    | False -> Set.empty
    | And(a,b) -> fv_bools a b
    | Or(a,b) -> fv_bools a b
    | AndAnd(a,b) -> fv_bools a b
    | OrOr(a,b) -> fv_bools a b
    | Negate(a) -> fv_bool a
    | Equal(a,b) -> fv_aries a b
    | NEqual(a,b) -> fv_aries a b
    | Gt(a,b) -> fv_aries a b
    | Gte(a,b) -> fv_aries a b
    | Lt(a,b) -> fv_aries a b
    | Lte(a,b) -> fv_aries a b
    | Par(a) -> fv_bool a

let rec fv (ast:AST) : Set<Var> =
    match ast with
    | A(a) -> fv_ari a
    | B(b) -> fv_bool b


let flow_relation (X:Set<Var>) (Y:Set<Var>) : Set<Flow> =
    let pairs = pairwise (Set.toList X) (Set.toList Y)
    Set.ofList pairs

let check_flow_relation (X:Set<Var>) (Y:Set<Var>) (validFlows:Set<Flow>) : bool =
    Set.forall (fun v -> Set.contains v validFlows) (flow_relation X Y)


let rec sec (n1:Node) (n2:Node) (ast:AST) (implicitFlows:Set<Var>) : SecurityFlows = 

    let rec sec_gcmd (gcmd:guardedcmd) (d:bools) (implicitFlows:Set<Var>)  : (SecurityFlows*bools)=
        match gcmd with
        | Cond(b, cmd) -> let w = sec n1 n2 (C(cmd)) (Set.unionMany [implicitFlows; (fv (B(b))); (fv (B(d)))])
                          (w, Or(b,d))
        | Else(gcmd1, gcmd2) -> 
                            let (w1,d1) = sec_gcmd gcmd1 d implicitFlows
                            let (w2,d2) = sec_gcmd gcmd2 d1 implicitFlows
                            (Set.union w1 w2, d2)

    let rec sec_cmd (cmd:cmd) (implicitFlows:Set<Var>)  : SecurityFlows =
        match cmd with
        | VarAssign(s, a) -> flow_relation (Set.union implicitFlows (fv (A(a)))) (Set.empty.Add(s))
        | ArrayAssign(_) -> failwith "Array access NS for now"
        | Skip -> Set.empty
        | Next(c1,c2) -> Set.union (sec n1 n2 (C(c1)) implicitFlows) (sec n1 n2 (C(c2)) implicitFlows)
        | If(gcmd) -> let (w,_) = sec_gcmd gcmd False implicitFlows
                      w
        | Do(gcmd) -> let (w,_) = sec_gcmd gcmd False implicitFlows
                      w

    

    match ast with
    | C(cmd) -> sec_cmd cmd implicitFlows
    | GC(gcmd) -> fst (sec_gcmd gcmd False implicitFlows)
    | _ -> failwith "That doesn't make sense"