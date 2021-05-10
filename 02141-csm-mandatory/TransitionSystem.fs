module TransitionSystem
open PGCompiler
open Auxliary
open AST


// Not done.

type State = Edge
type States = Set<State>


//type TS = { 
//    S: Set<State>
//    I: Set<State>
//    T: Set<State> -> Set<State>
//    AP: Set<string>
//    L: Set<State> -> Set<string>
//}


let pop_first (s:Set<'a>) : ('a*Set<'a>) =
    let listed = Set.toList s
    (listed.Head, s.Remove listed.Head)

let reach_one (s:State) (pg:ProgramGraph) : States =
    let (node,_,_,_) = s
    let avail = List.filter (fun ((n,_,_,_):Edge) -> n = node) pg
    Set.ofList avail

let check_model (pg:ProgramGraph) (initMem:Mem) : States =
    let todo = Set.empty.Add (List.tryFind (fun ((n,_,_,_):Edge) -> if n = I(0) then true else false ) pg).Value

    let rec check_model_rec (visited:States) (toExplore:States) (acc_stuck:States) : States =
        if toExplore.IsEmpty then acc_stuck else 
            let (s,newToexplore) = pop_first toExplore
            if visited.Contains s then check_model_rec visited newToexplore acc_stuck else
                let newVisited = visited.Add s
                let statesReachable = reach_one s pg
                if statesReachable.IsEmpty then check_model_rec newVisited newToexplore (acc_stuck.Add s) else
                    check_model_rec newVisited (Set.union newToexplore statesReachable) acc_stuck

    check_model_rec Set.empty todo Set.empty