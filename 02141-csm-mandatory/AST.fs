module AST



type arithmetic =
    | Num of float
    | Str of string
    | TimesExpr of (arithmetic * arithmetic)
    | DivExpr of (arithmetic * arithmetic)
    | PlusExpr of (arithmetic * arithmetic)
    | MinusExpr of (arithmetic * arithmetic)
    | PowExpr of (arithmetic * arithmetic)
    | UPlusExpr of (arithmetic)
    | UMinusExpr of (arithmetic)
    | ArrayAccess of (string*arithmetic)
    | Par of arithmetic


type bools =
    | True 
    | False
    | And of (bools * bools)
    | Or of (bools * bools)
    | AndAnd of (bools * bools)
    | OrOr of (bools * bools)
    | Negate of (bools)
    | Equal of (arithmetic * arithmetic)
    | NEqual of (arithmetic * arithmetic)
    | Gt of (arithmetic * arithmetic)
    | Gte of (arithmetic * arithmetic)
    | Lt of (arithmetic * arithmetic)
    | Lte of (arithmetic * arithmetic)
    | Par of bools

type cmd =
    | VarAssign of (string*arithmetic)
    | ArrayAssign of (string*arithmetic*arithmetic)
    | Skip
    | Next of (cmd * cmd)
    | If of guardedcmd
    | Do of guardedcmd

and guardedcmd = 
    | Else of (guardedcmd * guardedcmd)
    | Cond of (bools * cmd)



type AST = 
    | S of string
    | A of arithmetic
    | B of bools
    | C of cmd
    | GC of guardedcmd


    
type Var = string
type Flow = Var*Var
type Node = I of int | F of string
type Edge = Node*AST*Node*Set<Var>
type ProgramGraph = Edge list
type SecurityFlows = Set<Flow>
type Mem = Map<Var,int>
type PGMemory = Mem