// Learn more about F# at http://fsharp.org

module main

open System
open FSharp.Text.Lexing
open ASTPrettyPrinter
open AST


[<EntryPoint>]
let main argv =

    // Parsing logic (Use lexer with parser to generate AST, if fail then hint with lexer position).
    let parse input =
        let lexbuf = LexBuffer<char>.FromString input
        let res = try Parser.start Lexer.tokenize lexbuf with e -> 
                                                            let p = lexbuf.EndPos
                                                            (printf "Failed to parse at line: %d - at %d chars in. Could not parse because of: %s" (p.Line-1) p.Column e.Message)
                                                            exit 1
        res


    // Program logic. (Ask for filepath and parse content of file)
    printf "Write filename:"
    let fileName = (Console.ReadLine())
    let newFile = fileName.Substring(0, fileName.Length-4) + ".ast"
    let fileAsString = System.IO.File.ReadAllText fileName
    
    // Parse GCL program.
    let ast = print_ast (C(parse fileAsString)) 0
   

    // Write the .ast file
    System.IO.File.WriteAllText(newFile, ast)


    printf "\n Program is accepted as a valid GCL program. The following output can be used at: http://jimblackler.net/treefun/ to generate a visual AST, it is also written to %s \n\n" newFile
    printf "%s" ast
    Console.ReadLine()

    0

    
