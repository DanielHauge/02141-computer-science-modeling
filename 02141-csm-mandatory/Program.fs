// Learn more about F# at http://fsharp.org

module main

open System
open FSharp.Text.Lexing
open ASTPrettyPrinter
open AST
open PGCompiler
open PGPrinter


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
    let pgStr = print_program_graph pg
    let pgFileName = extensionLessFileName+".gv"

    // Write the .ast and .gv file
    System.IO.File.WriteAllText(astFileName, visualASTFormat)
    System.IO.File.WriteAllText(pgFileName, (pgStr |> List.fold (fun a b -> a+"\n"+b) ""))

    printf "\n Program is accepted as a valid GCL program. The following output can be used at: http://jimblackler.net/treefun/ to generate a visual AST, it is also written to %s \n\n" astFileName
    printf "%s\n" visualASTFormat
    printf "\nProgram graph edges:\n"
    Seq.iter (fun x -> printfn "%s" x) pgStr
    
    printf "\n The edges are also written to: %s\n" pgFileName

    Console.ReadLine()

    0

    
