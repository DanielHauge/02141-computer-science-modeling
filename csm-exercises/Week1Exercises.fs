module Week1Exercises


type Symbol = | Tea | Coffee | Chocolate | Kr5 | Kr10 | Kr20

type State = | S0 | S5 | S10 | S15 | S20 | Error

let TransitionFunc (sym:Symbol) (state:State) : State =
    match (state, sym) with 
    | (S0, Kr5) -> S5
    | (S0, Kr10) -> S10
    | (S0, Kr20) -> S20
    | (S0, Coffee) -> Error
    | (S0, Tea) -> Error
    | (S0, Chocolate) -> Error

    | (S5, Kr5) -> S10
    | (S5, Kr10) -> S15
    | (S5, Kr20) -> Error
    | (S5, Coffee) -> Error
    | (S5, Tea) -> Error
    | (S5, Chocolate) -> Error

    | (S10, Kr5) -> S15
    | (S10, Kr10) -> S20
    | (S10, Kr20) -> Error
    | (S10, Tea) -> S0
    | (S10, Coffee) -> Error
    | (S10, Chocolate) -> Error

    | (S15, Kr5) -> S20
    | (S15, Kr10) -> Error
    | (S20, Kr20) -> Error
    | (S15, Coffee) -> S0
    | (S15, Tea) -> Error
    | (S15, Chocolate) -> Error

    | (S20, Chocolate) -> S0
    | (S20, _) -> Error

    | (Error,_) -> Error
    

let rec run state input =
    match input with
    | [] -> state
    | symbol::more -> run (TransitionFunc symbol state) more

let go =
    printfn " Running ...\nFinished at state %A" (run S0 ( Kr5 :: Kr10 :: Coffee ::[]))
