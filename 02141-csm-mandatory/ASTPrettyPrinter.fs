module ASTPrettyPrinter
open AST

[<Literal>] 
let newline = "\n"
let indent i = (String.replicate i " ")

let rec print_ast (ast:AST) i = 

    let print_cmd cmd =
        match cmd with
        | VarAssign(s,a) -> ":=" + newline + (print_ast (S(s)) (i+1)) + newline + (print_ast (A(a)) (i+1))
        | ArrayAssign(s,a,b) ->  "[]:=" + newline +  (print_ast (S(s)) (i+1)) + newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | Skip ->  "Skip"
        | Next(c1,c2) ->  ";" + newline + (print_ast (C(c1)) (i+1)) + newline + (print_ast (C(c2)) (i+1))
        | If(guardedcmd) -> "if x fi" + newline + (print_ast (GC(guardedcmd)) (i+1))
        | Do(guardedcmd) -> "do x od" + newline + (print_ast (GC(guardedcmd)) (i+1))


    let print_ari ari =
        match ari with
        | Num(f) ->  string(f)
        | Str(s) ->  s
        | TimesExpr(a,b) -> "*" + newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | DivExpr(a,b) -> "/" + newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | PlusExpr(a,b) -> "+" + newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | MinusExpr(a,b) -> "- "+ newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | PowExpr(a,b) -> "^" + newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | UMinusExpr(a) -> "-" + newline + (print_ast (A(a)) (i+1))
        | UPlusExpr(a) -> "+" + newline + (print_ast (A(a)) (i+1))
        | ArrayAccess(s,a) -> "[]" + newline + (print_ast (S(s)) (i+1)) + newline + (print_ast (A(a)) (i+1))
        | arithmetic.Par(a) -> (print_ast (A(a)) (i))


    let print_bools bools = 
        match bools with
        | True -> "true"
        | False -> "false"
        | And(a,b) -> "&" + newline + (print_ast (B(a)) (i+1)) + newline + (print_ast (B(b)) (i+1))
        | Or(a,b) -> "|" + newline + (print_ast (B(a)) (i+1)) + newline + (print_ast (B(b)) (i+1))
        | AndAnd(a,b) -> "&&" + newline + (print_ast (B(a)) (i+1)) + newline + (print_ast (B(b)) (i+1))
        | OrOr(a,b) -> "||" + newline + (print_ast (B(a)) (i+1)) + newline + (print_ast (B(b)) (i+1))
        | Negate(a) -> "!" + newline + (print_ast (B(a)) (i+1))
        | Equal(a,b) -> "=" + newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | NEqual(a,b) -> "!=" + newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | Gt(a,b) -> ">" + newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | Gte(a,b) -> ">=" + newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | Lt(a,b) -> "<" + newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | Lte(a,b) -> "<=" + newline + (print_ast (A(a)) (i+1)) + newline + (print_ast (A(b)) (i+1))
        | Par(a) -> (print_ast (B(a)) (i))

    let print_gcmd gcmd = 
        match gcmd with
        | Else(a,b) -> "[]" + newline + (print_ast (GC(a)) (i+1)) + newline + (print_ast (GC(b)) (i+1))
        | Cond(b,c) -> "->" + newline + (print_ast (B(b)) (i+1)) + newline + (print_ast (C(c)) (i+1))

    match ast with
    | S(s) -> (indent i) + s
    | A(a) -> (indent i) + print_ari a
    | B(b) -> (indent i) + print_bools b
    | C(c) -> (indent i) + print_cmd c
    | GC(gc) -> (indent i) + print_gcmd gc







