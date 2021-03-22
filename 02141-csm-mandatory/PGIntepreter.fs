module PGIntepreter
open AST
open PGCompiler
open PGEvaluator
open PGPrinter


type ExecutionStep = AST option*Node*Mem
type ProgramStatus = Stuck | Terminated with override this.ToString() = match this with | Stuck -> "stuck" | Terminated -> "Terminated"

let rec tryFindNextExecution (aavailableEdgese:ProgramGraph) (mem:Mem) : ExecutionStep option =
        match aavailableEdgese with 
        | (_,ast,n2)::tail -> 
            match evaluate_action ast mem with 
            | Some(newMemory) -> Some (Some(ast), n2, newMemory)
            | None -> tryFindNextExecution tail mem
        | _ -> None

let interpret_pg (initialMem:Mem) (pg:ProgramGraph) : (ExecutionStep list*ProgramStatus) =

    let rec interpret_pg_rec (cur:Node) (mem:Mem) (acc:ExecutionStep list) : (ExecutionStep list*ProgramStatus) =
        if cur = FinalNode then (acc,Terminated) else
        let availableEdges = List.filter (fun (n1,_,_) -> n1=cur) pg
        match tryFindNextExecution availableEdges mem with
        | Some((ast,newNode,newMem)) -> interpret_pg_rec newNode newMem ((ast,newNode,newMem)::acc)
        | None -> (acc, Stuck)

    interpret_pg_rec InitialNode initialMem []

let print_execution_step (es:ExecutionStep) : string =
    let (ast, node, mem) = es
    sprintf "Action: %s - Node: %s - Memory: %s" (match ast with | Some(a) -> print_ast_expression a | None -> "N/A") (print_node node) (Newtonsoft.Json.JsonConvert.SerializeObject mem)

    