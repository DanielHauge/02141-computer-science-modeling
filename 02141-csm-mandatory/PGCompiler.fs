﻿module PGCompiler
open AST
open Security

// Using an incrementing integer to generate fresh state names.
let mutable f = 0

// Evaluates the expression for when the guarded command is no longer satisfied (ie. when the condition is no longer true and needs to get out of iterating construct)
let rec compile_gcmd_done (gcmd:guardedcmd) : bools =
    match gcmd with
    | Else(gcmd1, gcmd2) -> And(compile_gcmd_done gcmd1, compile_gcmd_done gcmd2)
    | Cond(d, _) -> Negate(d)

// compiling ast to program graph recursively.
let rec compile_pg_rec (n1:Node) (n2:Node) (ast:AST) : ProgramGraph = 
    
    // Basically implements the edge construction function for guarded commands from definition 2.7 in the book.
    let rec compile_gcmd (gcmd:guardedcmd) : ProgramGraph=
        match gcmd with
        | Else(gcmd1, gcmd2) -> (compile_pg_rec n1 n2 (GC(gcmd1)))@(compile_pg_rec n1 n2 (GC(gcmd2)))
        | Cond(b, cmd) -> (f<-f+1); (n1, B(b), I(f), Set.empty)::compile_pg_rec (I(f)) n2 (C(cmd))

    // Basically implements the edge construction function for commands from definition 2.7 in the book.
    let rec compile_cmd (cmd:cmd) : ProgramGraph =
        match cmd with
        | VarAssign(_) -> [(n1, C(cmd), n2, Set.empty)]
        | ArrayAssign(_) -> [(n1, C(cmd),n2, Set.empty)]
        | Skip -> [(n1, C(cmd),n2,Set.empty)]
        | Next(c1,c2) -> (f<-f+1); (compile_pg_rec n1 (I(f)) (C(c1)))@(compile_pg_rec (I(f)) n2 (C(c2)))
        | If(gcmd) -> compile_pg_rec n1 n2 (GC(gcmd))
        | Do(gcmd) -> (compile_pg_rec n1 n1 (GC(gcmd)))@[(n1, (B(compile_gcmd_done gcmd)), n2, Set.empty)]

    match ast with
    | C(cmd) -> compile_cmd cmd
    | GC(gcmd) -> compile_gcmd gcmd
    | S(_) -> failwith "cannot compile string to anything meningful, should have been part of expression on the edge"
    | A(_) -> failwith "cannot compile arithmetic expression to anything meningful, should have been part of expression on the edge"
    | B(_) -> failwith "cannot compile boolean expression to anything meningful, should have been part of expression on the edge"
    
// Alternative approach to constructing the program graph, this uses the deterministic approach.
let rec compile_pg_det_rec (n1:Node) (n2:Node) (ast:AST) (implicitFlows:Set<Var>) : ProgramGraph = 

    // Basically implements alternative the edge construction function for guarded commands from definition 2.7 in the book.
    let rec compile_gcmd_det (gcmd:guardedcmd) (d:bools) (dependentVars:Set<Var>)  : (ProgramGraph*bools)=
        match gcmd with
        | Cond(b, cmd) -> 
            (f<-f+1);  
            let e = compile_pg_det_rec (I(f)) n2 (C(cmd)) (Set.unionMany [dependentVars; (fv (B(d)));(fv (B(b)))])
            ((n1, B(And(b, (Negate(d)))), I(f), Set.empty)::e, Or(d, b))
        | Else(gcmd1, gcmd2) -> 
            let (e1,d1) = compile_gcmd_det gcmd1 d dependentVars
            let (e2,d2) = compile_gcmd_det gcmd2 d1 dependentVars
            (e1@e2, d2)
        
    // Basically implements alternative the edge construction function for commands from definition 2.7 in the book.
    let rec compile_cmd_det (cmd:cmd) (implicitFlows:Set<Var>)  : ProgramGraph =
        match cmd with
        | VarAssign(_) -> [(n1, C(cmd), n2, implicitFlows)]
        | ArrayAssign(_) -> [(n1, C(cmd),n2, implicitFlows)]
        | Skip -> [(n1, C(cmd),n2, implicitFlows)]
        | Next(c1,c2) -> (f<-f+1); (compile_pg_det_rec n1 (I(f)) (C(c1)) implicitFlows)@(compile_pg_det_rec (I(f)) n2 (C(c2)) implicitFlows)
        | If(gcmd) -> fst (compile_gcmd_det gcmd False implicitFlows)
        | Do(gcmd) ->
            let (e,d) = compile_gcmd_det gcmd False implicitFlows
            e @ [(n1, B(Negate(d)), n2, implicitFlows)]

    match ast with
    | C(cmd) -> compile_cmd_det cmd implicitFlows
    | GC(gcmd) -> fst (compile_gcmd_det gcmd False implicitFlows)
    | S(_) -> failwith "cannot compile string to anything meningful, should have been part of expression on the edge"
    | A(_) -> failwith "cannot compile arithmetic expression to anything meningful, should have been part of expression on the edge"
    | B(_) -> failwith "cannot compile boolean expression to anything meningful, should have been part of expression on the edge"

    
let FinalNode = F("#")
let InitialNode = I(0)
let compile_pg (det:bool) (ast:AST) : ProgramGraph = if det then compile_pg_det_rec (InitialNode) (FinalNode) ast Set.empty else  compile_pg_rec (InitialNode) (FinalNode) ast


