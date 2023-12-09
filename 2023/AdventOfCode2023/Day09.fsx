open System

// let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/09.txt")
let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/09.txt")

let histories =
    input
    |> Array.map (fun line -> line.Split(' ') |> Array.map int64)
 
let rec Extrapolate (history:Int64[]) =
    if (history |> Array.forall (fun n -> n=0)) then
        0L
    else 
        let projection = 
            history
            |> Array.pairwise
            |> Array.map (fun (a, b) -> b-a)
        (Array.last history) + (Extrapolate projection)

histories
|> Array.sumBy Extrapolate
|> printfn "Part 1: %i"

// input
// |> printfn "Part 2: %i"
