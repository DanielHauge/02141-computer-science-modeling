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
open SignAnalyser
open Security
open SecurityInit


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
    printf "Press 'y' for non-Deterministic: "
    let nondeterministic = Console.ReadKey().KeyChar = 'y'
    printf " | Deterministic program-graph: %b\n" (not nondeterministic)

    printf "Write file path or press enter for the test program:"
    let consoleInput = (Console.ReadLine())
    let fileName = if consoleInput.Length > 4 then consoleInput else "E:\\repo\\02141-computer-science-modeling\\02141-csm-mandatory\\test.gcl" 
    let extensionLessFileName = fileName.Substring(0, fileName.Length-4)
    let fileAsString = System.IO.File.ReadAllText fileName
    
    // Parse GCL program.
    let ast = C(parse fileAsString)
    let astFileName = extensionLessFileName+".ast"
    System.IO.File.WriteAllText(astFileName, print_ast (ast) 0)

    // Compiles program graph for ast
    let pg = compile_pg (not nondeterministic) ast
    let pgFileName = extensionLessFileName+".gv"
    System.IO.File.WriteAllText(pgFileName, format_program_graph_graphiz pg)

    // Execution
    let initMem = Newtonsoft.Json.JsonConvert.DeserializeObject<PGMemory> (System.IO.File.ReadAllText (extensionLessFileName+".mem"))
    let (executionSteps, status) = interpret_pg initMem pg
    let (ast,node,mem) = if executionSteps.IsEmpty then (None,InitialNode,initMem) else executionSteps.Head

    printfn "\nStatus: %A\nNode: %s\nLast action:%s\nFinal Memory:%s\n" status (print_node node) (match ast with | Some(a) -> print_ast_expression a | None -> "N/A") (Newtonsoft.Json.JsonConvert.SerializeObject mem)
    Seq.iter (fun es -> printfn "%s" (print_execution_step es) ) (List.rev executionSteps)

    
    // Sign analysis
    let signAnalysis = sign_analyse_pg_mem initMem pg
    let signAnalysisString = (print_sign_analysis (Map.toList signAnalysis))
    let signAnalysisFile = extensionLessFileName+".sign"
    System.IO.File.WriteAllText(signAnalysisFile, signAnalysisString)

    // Security analysis
    let securityPolicy = Newtonsoft.Json.JsonConvert.DeserializeObject<SecurityConfig> (System.IO.File.ReadAllText (extensionLessFileName+".sp"))
    let allowedFlows = allowed_flows securityPolicy
    let actualFlows = security_analysis pg
    let violations = evaluate_security_violations actualFlows allowedFlows

    let securityFile = extensionLessFileName+".sa"
    System.IO.File.WriteAllText(securityFile, "Actual flows:\n")
    System.IO.File.AppendAllText(securityFile, format_security_flows actualFlows)
    System.IO.File.AppendAllText(securityFile, "Allowed flows:\n")
    System.IO.File.AppendAllText(securityFile, format_security_flows allowedFlows)
    System.IO.File.AppendAllText(securityFile, "Violated flows:\n")
    System.IO.File.AppendAllText(securityFile, format_security_flows violations)


    printfn "\nProgram accepted. See files: \n\t - AST: %s | http://jimblackler.net/treefun/ \n\t - Program Graph: %s\n\t - Sign analysis: %s\n\t - Security analysis: %s" astFileName pgFileName signAnalysisFile securityFile

    Console.ReadLine()

    0

    
