// Learn more about F# at http://fsharp.org

module main

open System
open FSharp.Text.Lexing
open ASTPrettyPrinter
open AST
open PGCompiler
open PGPrinter
open PGEvaluator
open PGIntepreter


[<EntryPoint>]
let main argv =

    // Parsing logic (Use lexer with parser to generate AST, if fail then hint with lexer position).
    let parse input =
        let lexbuf = LexBuffer<char>.FromString input
        let res = try Parser.start Lexer.tokenize lexbuf with e -> 
                                                            let p = lexbuf.EndPos
                                                            (printf "Failed to parse at line: %d - at %d chars in. Could not parse because of: %s - the char which was problematic was around: (%s)" (p.Line-1)  p.Column e.Message (new System.String(lexbuf.Lexeme)))
                                                            exit 1
        res


    // Program logic. (Ask for filepath and parse content of file)
    printf "Should the resulting program graph be deterministic? press 'y' otherwise press anything else for non-deterministic key\n"
    let deterministic = Console.ReadKey().KeyChar = 'y'
    printf "Deterministic program-graph: %b\n" deterministic

    printf "Write file path or press enter for the test program:"
    let consoleInput = (Console.ReadLine())
    let fileName = if consoleInput.Length > 4 then consoleInput else "E:\\repo\\02141-computer-science-modeling\\02141-csm-mandatory\\test.gcl" 
    let extensionLessFileName = fileName.Substring(0, fileName.Length-4)
    let fileAsString = System.IO.File.ReadAllText fileName
    
    // Parse GCL program.
    let ast = C(parse fileAsString)
    let visualASTFormat = print_ast (ast) 0
    let astFileName = extensionLessFileName+".ast"

    // Compiles program graph for ast
    let pg = compile_pg deterministic ast
    let pgFileName = extensionLessFileName+".gv"

    // Write the .ast and .gv file
    System.IO.File.WriteAllText(astFileName, visualASTFormat)
    System.IO.File.WriteAllText(pgFileName, format_program_graph_graphiz pg)

    printf "\n Program is accepted as a valid GCL program. The following output can be used at: http://jimblackler.net/treefun/ to generate a visual AST, it is also written to %s \n\n" astFileName
    printf "%s\n" visualASTFormat
    printf "\nProgram graph edges:\n"
    Seq.iter (fun x -> printfn "%s" x) (print_program_graph pg)
    
    printf "\n The edges are also written to: %s\n" pgFileName

    printf "\nInterpreting program with initial memory:"
    let initMem = Newtonsoft.Json.JsonConvert.DeserializeObject<PGMemory> (System.IO.File.ReadAllText (extensionLessFileName+".mem"))
    printfn "%s" (Newtonsoft.Json.JsonConvert.SerializeObject initMem)

    let (executionSteps, status) = interpret_pg initMem pg
    let (ast,node,mem) = if executionSteps.IsEmpty then (None,InitialNode,initMem) else executionSteps.Head
    
    printfn "Status: %A\nNode: %s\nLast action:%s\nFinal Memory:%s\n\n" status (print_node node) (match ast with | Some(a) -> print_ast_expression a | None -> "N/A") (Newtonsoft.Json.JsonConvert.SerializeObject mem)
    Seq.iter (fun es-> printfn "%s" (print_execution_step es) ) (List.rev executionSteps)


    Console.ReadLine()

    0

    
