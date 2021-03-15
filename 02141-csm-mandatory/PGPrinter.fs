module PGPrinter
open AST
open PGCompiler


let rec print_arithmetic_exp (ari:arithmetic) : string =
    let print_arithmetic_exp_a s a b = sprintf "%s%s%s" (print_arithmetic_exp a) s (print_arithmetic_exp b)
    match ari with
    | Num(i) -> string(i)
    | Str(s) -> s
    | TimesExpr(a,b) -> print_arithmetic_exp_a "*" a b
    | DivExpr(a,b) -> print_arithmetic_exp_a "/" a b
    | PlusExpr(a,b) -> print_arithmetic_exp_a "+" a b
    | MinusExpr(a,b) -> print_arithmetic_exp_a "-" a b
    | PowExpr(a,b) -> print_arithmetic_exp_a "^" a b
    | UPlusExpr(a) -> sprintf "+%s" (print_arithmetic_exp a)
    | UMinusExpr(a) -> sprintf "-%s" (print_arithmetic_exp a)
    | ArrayAccess(s,b) -> sprintf "%s[%s]" s (print_arithmetic_exp b)
    | arithmetic.Par(a) -> sprintf "(%s)" (print_arithmetic_exp a)



let rec print_boolean_exp (bools:bools) : string = 
    let print_boolean_exp_b s a b = sprintf "(%s)%s(%s)" (print_boolean_exp a) s (print_boolean_exp b)
    let print_boolean_exp_a s a b = sprintf "%s%s%s" (print_arithmetic_exp a) s (print_arithmetic_exp b)
    match bools with
    | True -> "true"
    | False -> "false"
    | And(a,b) -> print_boolean_exp_b "&" a b
    | Or(a,b) -> print_boolean_exp_b "|" a b
    | AndAnd(a,b) -> print_boolean_exp_b "&&" a b
    | OrOr(a,b) -> print_boolean_exp_b "||" a b
    | Negate(a) -> sprintf "!(%s)" (print_boolean_exp a)
    | Equal(a,b) -> print_boolean_exp_a "=" a b
    | NEqual(a,b) -> print_boolean_exp_a "!=" a b
    | Gt(a,b) -> print_boolean_exp_a ">" a b
    | Gte(a,b) -> print_boolean_exp_a ">=" a b
    | Lt(a,b) -> print_boolean_exp_a "<" a b
    | Lte(a,b) -> print_boolean_exp_a "<=" a b
    | Par(a) -> sprintf "(%s)" (print_boolean_exp a)


let print_command_exp (cmd:cmd) : string = 
    match cmd with
    | VarAssign(s, a) -> sprintf "%s:=%s" s (print_arithmetic_exp a)
    | ArrayAssign(s, a1, a2) -> sprintf "%s[%s]:=%s" s (print_arithmetic_exp a1) (print_arithmetic_exp a2)
    | Skip -> "skip"
    | _ -> failwith "cannot print type of cmd"


let print_guardedcommand_exp (gcmd:guardedcmd) : string = failwith "cannot print guarded command, it should have been made into states and edges etc."

let print_ast_expression (ast:AST) : string =
    match ast with
    | C(cmd) -> print_command_exp cmd
    | GC(gcmd) -> print_guardedcommand_exp gcmd
    | S(s) -> s
    | A(a) -> print_arithmetic_exp a
    | B(b) -> print_boolean_exp b 

let print_node (node:Node) : string =
    match node with
    | I(i) -> string(i)
    | F(f) -> f

let print_edge (edge:Edge) =
    let (a, ast, b) = edge
    sprintf "q%s -> q%s [%s]" (print_node a) (print_node b) (print_ast_expression ast)

let rec print_program_graph (edges:ProgramGraph) : string list =
    match edges with
    | head::tail -> sprintf "%s" (print_edge head)::print_program_graph tail
    | _ -> []

