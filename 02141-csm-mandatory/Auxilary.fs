module Auxliary



let rec pairwise a b =
    let rec makePairsForRow c l =
        match l with
        | [] -> []
        | head::tail -> (c,head)::(makePairsForRow c tail)

    match a with
    | [] -> []
    | head::tail -> makePairsForRow head b@(pairwise tail b)
