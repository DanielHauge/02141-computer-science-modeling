// Learn more about F# at http://fsharp.org

module main

open System
open FSharp.Text.Lexing
open ASTPrettyPrinter
open AST


[<EntryPoint>]
let main argv =

    let parse input =
        let lexbuf = LexBuffer<char>.FromString input
        let res = try Parser.start Lexer.tokenize lexbuf with e -> 
                                                            let p = lexbuf.EndPos
                                                            (printf "Failed to parse at line: %d - at %d chars in. Could not parse because of: %s" (p.Line-1) p.Column e.Message)
                                                            exit 1
        res


    let fileAsString = System.IO.File.ReadAllText "E:\\repo\\02141-computer-science-modeling\\02141-csm-mandatory\\test.gcl"

    let gg = parse fileAsString
    
    let ast = print_ast (C(gg)) 0
    
    // http://jimblackler.net/treefun/

    System.IO.File.WriteAllText("E:\\repo\\02141-computer-science-modeling\\02141-csm-mandatory\\test.ast", ast)

    printfn "http://jimblackler.net/treefun/"
    Console.ReadKey()

    0

    
