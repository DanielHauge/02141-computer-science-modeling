module SignEvaluator
open AST
open PGCompiler
open PGEvaluator

type Var = string
type SignA = PLUS | MINUS | ZERO
type SignB = TT | FF
type Sign = ASign of SignA | BSign of SignB
type Signs = Set<Sign>
type AbstractMem = Map<Var,Signs> 
type SignAnalysis = Map<Node,AbstractMem>


let sign i : SignA = 
    if (i > 0) then PLUS 
    elif (i < 0) then MINUS 
    else ZERO 

let map_to_generic_asigns (a:Set<SignA>) : Signs = Set.map (fun v -> ASign(v) ) a
let map_to_generic_bsigns (a:Set<SignB>) : Signs = Set.map (fun v -> BSign(v) ) a
let bsigns_from_list (l:SignB list) : Signs = map_to_generic_bsigns (Set.ofList l)
let asigns_from_list (l:SignA list) : Signs = map_to_generic_asigns (Set.ofList l)

// SIGN ARITHMETIC ANALYSIS


let sign_add (s1:SignA) (s2:SignA) : Signs =
    map_to_generic_asigns (
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
     ))

let sign_sub (s1:SignA) (s2:SignA) : Signs =
    map_to_generic_asigns(
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
    ))

let sign_times (s1:SignA) (s2:SignA) : Signs =
    map_to_generic_asigns(
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
    ))

let sign_divide (s1:SignA) (s2:SignA) : Signs =
    map_to_generic_asigns(
        Set.ofList (
            match (s1,s2) with
            | (MINUS, MINUS) -> [PLUS]
            | (MINUS, ZERO) -> failwith "Cannot divide by zero"
            | (MINUS, PLUS) -> [MINUS]
            | (ZERO, MINUS) -> [ZERO]
            | (ZERO, ZERO) -> failwith "Cannot divide by zero"
            | (ZERO, PLUS) -> [ZERO] 
            | (PLUS, MINUS) -> [MINUS]
            | (PLUS, ZERO) -> failwith "Cannot divide by zero"
            | (PLUS, PLUS) -> [PLUS] 
    ))

let sign_pow (s1:SignA) (s2:SignA) : Signs =
    map_to_generic_asigns(
        Set.ofList (
            match (s1,s2) with
            | (MINUS, MINUS) -> [MINUS]
            | (MINUS, ZERO) -> [MINUS]
            | (MINUS, PLUS) -> [MINUS]
            | (ZERO, MINUS) -> failwith "zero to the power of anything minus, is the same as dividing by 0. No good."
            | (ZERO, ZERO) -> [PLUS]
            | (ZERO, PLUS) ->[ZERO] 
            | (PLUS, MINUS) -> [PLUS]
            | (PLUS, ZERO) -> [PLUS]
            | (PLUS, PLUS) -> [PLUS] 
    ))

// SIGN BOOLEAN ANALYSIS

let sign_equals (s1:SignA) (s2:SignA) : Signs = // =
    map_to_generic_bsigns(
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

let sign_gt (s1:SignA) (s2:SignA) : Signs = // GT
    map_to_generic_bsigns( 
        Set.ofList (
            match (s1,s2) with
            | (MINUS, MINUS) -> [TT; FF]
            | (MINUS, ZERO) -> [FF]
            | (MINUS, PLUS) -> [FF]
            | (ZERO, MINUS) -> [TT]
            | (ZERO, ZERO) -> [FF]
            | (ZERO, PLUS) -> [FF] 
            | (PLUS, MINUS) -> [TT]
            | (PLUS, ZERO) -> [TT]
            | (PLUS, PLUS) -> [TT;FF] 
    ))


let sign_gte (s1:SignA) (s2:SignA) : Signs = // GTE
    map_to_generic_bsigns(
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
    ))

let sign_conjunction (s1:SignB) (s2:SignB) : Signs = // AND
    map_to_generic_bsigns(
        Set.ofList (
            match (s1,s2) with
            | (TT, TT) ->  [TT]
            | (TT, FF) -> [FF]
            | (FF, TT) -> [FF]
            | (FF, FF) -> [TT]
    ))

let sign_disjunction (s1:SignB) (s2:SignB) : Signs = // OR
    map_to_generic_bsigns(
        Set.ofList (
            match (s1,s2) with
            | (TT, TT) ->  [TT]
            | (TT, FF) -> [TT]
            | (FF, TT) -> [TT]
            | (FF, FF) -> [FF]
    ))

let sign_negate (s:SignB) : SignB =
    match (s) with
    | TT ->  FF
    | FF -> TT

    
