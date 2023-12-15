open System

// let input = System.IO.File.ReadAllText("2023/AdventOfCode2023/tests/15.2.txt").Split(',')
let input = System.IO.File.ReadAllText("2023/AdventOfCode2023/inputs/15.txt").Split(',')

let HASH (str:string) = Seq.fold (fun i c -> ((i + (int c))*17)%256) 0 str

input
|> Array.sumBy HASH
|> printfn "Part 1: %i"

// input
// |> printfn "Part 2: %i"
