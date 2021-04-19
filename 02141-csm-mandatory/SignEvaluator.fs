module SignEvaluator
open AST
open PGCompiler
open PGEvaluator

type Var = string
type SignA = PLUS | MINUS | ZERO
type SignB = TT | FF
type Signs = ASigns of Set<SignA> | BSigns of Set<SignB>
type AbstractMem = Map<Var,Signs>
type SignAnalysis = (Node * AbstractMem) list


let sign i : SignA = 
    if (i > 0) then PLUS 
    elif (i < 0) then MINUS 
    else ZERO 

// SIGN ARITHMETIC ANALYSIS

let sign_add (s1:SignA) (s2:SignA) : Signs =
    ASigns(
        Set.ofList (
            match (s1,s2) with
            | (MINUS, MINUS) -> [MINUS]
            | (MINUS, ZERO) -> [MINUS]
            | (MINUS, PLUS) -> [MINUS; ZERO; PLUS]
            | (ZERO, MINUS) -> [MINUS]
            | (ZERO, ZERO) -> [ZERO]
            | (ZERO, PLUS) -> [PLUS] 
            | (PLUS, MINUS) -> [MINUS; ZERO;PLUS]
            | (PLUS, ZERO) -> [PLUS]
            | (PLUS, PLUS) -> [PLUS] 
            | _ -> failwith "does not expect boolean signs in arithmetic comparisions"
     ))

let sign_sub (s1:SignA) (s2:SignA) : Signs =
    ASigns(
        Set.ofList (
            match (s1,s2) with
            | (MINUS, MINUS) -> [MINUS;ZERO;PLUS]
            | (MINUS, ZERO) -> [MINUS]
            | (MINUS, PLUS) -> [MINUS]
            | (ZERO, MINUS) -> [PLUS]
            | (ZERO, ZERO) -> [ZERO]
            | (ZERO, PLUS) -> [MINUS] 
            | (PLUS, MINUS) -> [PLUS]
            | (PLUS, ZERO) -> [PLUS]
            | (PLUS, PLUS) -> [PLUS; ZERO; MINUS] 
            | _ -> failwith "does not expect boolean signs in arithmetic comparisions"
    ))

let sign_times (s1:SignA) (s2:SignA) : Signs =
    ASigns(
        Set.ofList (
            match (s1,s2) with
            | (MINUS, MINUS) -> [PLUS]
            | (MINUS, ZERO) -> [ZERO]
            | (MINUS, PLUS) -> [MINUS]
            | (ZERO, MINUS) -> [ZERO]
            | (ZERO, ZERO) -> [ZERO]
            | (ZERO, PLUS) -> [ZERO] 
            | (PLUS, MINUS) -> [MINUS]
            | (PLUS, ZERO) -> [ZERO]
            | (PLUS, PLUS) -> [PLUS] 
            | _ -> failwith "does not expect boolean signs in arithmetic comparisions"
    ))

let sign_divide (s1:SignA) (s2:SignA) : Signs =
    ASigns(
        Set.ofList (
            match (s1,s2) with
            | (MINUS, MINUS) -> [PLUS]
            | (MINUS, ZERO) -> []
            | (MINUS, PLUS) -> [MINUS]
            | (ZERO, MINUS) -> [ZERO]
            | (ZERO, ZERO) -> []
            | (ZERO, PLUS) -> [ZERO] 
            | (PLUS, MINUS) -> [MINUS]
            | (PLUS, ZERO) -> []
            | (PLUS, PLUS) -> [PLUS] 
            | _ -> failwith "does not expect boolean signs in arithmetic comparisions"
    ))

let sign_pow (s1:SignA) (s2:SignA) : Signs =
    ASigns(
        Set.ofList (
            match (s1,s2) with
            | (MINUS, MINUS) -> [MINUS]
            | (MINUS, ZERO) -> [MINUS]
            | (MINUS, PLUS) -> [MINUS]
            | (ZERO, MINUS) -> []
            | (ZERO, ZERO) -> [PLUS]
            | (ZERO, PLUS) ->[ZERO] 
            | (PLUS, MINUS) -> [PLUS]
            | (PLUS, ZERO) -> [PLUS]
            | (PLUS, PLUS) -> [PLUS] 
            | _ -> failwith "does not expect boolean signs in arithmetic comparisions"
    ))

// SIGN BOOLEAN ANALYSIS

let sign_equals (s1:SignA) (s2:SignA) : Signs = // =
    BSigns(
        Set.ofList (
            match (s1,s2) with
            | (MINUS, MINUS) -> [TT; FF]
            | (MINUS, ZERO) -> [FF]
            | (MINUS, PLUS) -> [FF]
            | (ZERO, MINUS) -> [FF]
            | (ZERO, ZERO) -> [TT]
            | (ZERO, PLUS) ->[FF] 
            | (PLUS, MINUS) -> [FF]
            | (PLUS, ZERO) -> [FF]
            | (PLUS, PLUS) -> [TT;FF] 
    ))

let sign_gt (s1:SignA) (s2:SignA) : Signs = // GT (NOT DONE)
    BSigns( 
        Set.ofList (
            match (s1,s2) with
            | (MINUS, MINUS) -> [TT; FF]
            | (MINUS, ZERO) -> [TT]
            | (MINUS, PLUS) -> [TT]
            | (ZERO, MINUS) -> [FF]
            | (ZERO, ZERO) -> [TT]
            | (ZERO, PLUS) -> [TT] 
            | (PLUS, MINUS) -> [FF]
            | (PLUS, ZERO) -> [FF]
            | (PLUS, PLUS) -> [TT;FF] 
            | _ -> failwith "does not expect boolean signs in arithmetic comparisions"
    ))


let sign_gte (s1:SignA) (s2:SignA) : Signs = // GTE
    BSigns(
        Set.ofList (
            match (s1,s2) with
            | (MINUS, MINUS) -> [TT; FF]
            | (MINUS, ZERO) ->[TT]
            | (MINUS, PLUS) -> [TT]
            | (ZERO, MINUS) -> [FF]
            | (ZERO, ZERO) -> [TT]
            | (ZERO, PLUS) -> [TT] 
            | (PLUS, MINUS) -> [FF]
            | (PLUS, ZERO) -> [FF]
            | (PLUS, PLUS) -> [TT;FF] 
            | _ -> failwith "does not expect boolean signs in arithmetic comparisions"
    ))

let sign_conjunction (s1:SignB) (s2:SignB) : Signs = // AND
    BSigns(
        Set.ofList (
            match (s1,s2) with
            | (TT, TT) ->  [TT]
            | (TT, FF) -> [FF]
            | (FF, TT) -> [FF]
            | (FF, FF) -> [TT]
            | _ -> failwith "does not expect arithmetic signs in arithmetic comparisions"
    ))

    
