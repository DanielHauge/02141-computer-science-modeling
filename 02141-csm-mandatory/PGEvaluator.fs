module PGEvaluator
open AST
open PGCompiler

type Var = string
type Mem = Map<Var,int>
type PGMemory = Mem


// Actual computational evaluation. Based on semanthics (very trivial, + should plus values together and times should times etc.)
let rec eval_arithmetic (mem:Mem) (a:arithmetic) :  int option =
    
    let eval_arith_with_op (a:arithmetic) (b:arithmetic) op : int option =
        let evaledA = eval_arithmetic mem a
        let evaledB = eval_arithmetic mem b
        if (evaledA.IsNone || evaledB.IsNone) then None else Some(op evaledA.Value evaledB.Value)

    match a with
    | Num(f) -> Some(int(f))
    | Str(s) -> mem.TryFind s
    | ArrayAccess(s,a) -> mem.TryFind s
    | TimesExpr(a,b) -> eval_arith_with_op a b (*)
    | DivExpr(a,b) -> eval_arith_with_op a b (/)
    | PlusExpr(a,b) -> eval_arith_with_op a b (+)
    | MinusExpr(a,b) ->eval_arith_with_op a b (-)
    | PowExpr(a,b) -> eval_arith_with_op a b pown
    | UPlusExpr(a) -> match eval_arithmetic mem a with | Some(i) -> Some(abs(i)) | None -> None
    | UMinusExpr(a) -> match eval_arithmetic mem a with | Some(i) -> Some(-abs(i)) | None -> None


// Actual computational evaluation. Based on semanthics (very trivial, and should return true if both evaluated to true etc.)
let rec eval_boolean (mem:Mem) (b:bools) : bool option =
    
    let eval_bool_with_op (a:bools) (b:bools) op : bool option =
        let evaledA = eval_boolean mem a
        let evaledB = eval_boolean mem b
        if (evaledA.IsNone || evaledB.IsNone) then None else Some(op evaledA.Value evaledB.Value)

    let eval_arith_with_op (a:arithmetic) (b:arithmetic) op : bool option =
        let evaledA = eval_arithmetic mem a
        let evaledB = eval_arithmetic mem b
        if (evaledA.IsNone || evaledB.IsNone) then None else Some(op evaledA.Value evaledB.Value)

    match b with
    | True -> Some true
    | False -> Some false
    | And(a,b) -> eval_bool_with_op a b (&)
    | Or(a,b) -> eval_bool_with_op a b (||)
    | AndAnd(a,b) -> eval_bool_with_op a b (&&)
    | OrOr(a,b) -> eval_bool_with_op a b (||)
    | Negate(a) -> match eval_boolean mem a with | Some(b) -> Some(not b) | None -> None 
    | Equal(a,b) -> eval_arith_with_op a b (=)
    | NEqual(a,b) -> match (eval_arith_with_op a b (=)) with | Some(b) -> Some(not b) | None -> None 
    | Gt(a,b) -> eval_arith_with_op a b (>)
    | Gte(a,b) -> eval_arith_with_op a b (>=)
    | Lt(a,b) -> eval_arith_with_op a b (<)
    | Lte(a,b) -> eval_arith_with_op a b (<=)
    | Par(a) -> eval_boolean mem a


let evaluate_action (ast:AST) (mem:Mem) : Mem option =

    match ast with
    | B(b) -> match eval_boolean mem b with | Some(boolean) -> (if boolean then Some(mem) else None) | None -> None
    | C(Skip) -> Some(mem)
    | C(VarAssign(s,a)) when mem.ContainsKey s -> match (eval_arithmetic mem a) with | Some(i) -> Some(mem.Add(s, i)) | None -> None
    | C(ArrayAssign(s,a,b)) when mem.ContainsKey s -> 
                    let index = eval_arithmetic mem a
                    let value = eval_arithmetic mem b
                    if index.IsNone || value.IsNone then None else Some(mem.Add(sprintf "%s[%s]" s (string(index.Value)), value.Value))
    | _ -> None

