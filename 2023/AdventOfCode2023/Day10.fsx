open System

let input = 
    System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/10.1.txt")
    // System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/10.txt")
    |> Array.map Seq.toArray

let s = 
    input
    |> Array.mapi (fun i row ->
        Array.tryFindIndex((=) 'S') row
        |> Option.map (fun j -> i, j))
    |> Seq.pick id

// walk the loop back to S
    // find a direction that connects to s
    // recursively follow that trail 
    // knowing where you came from and the shape will tell you where to go
    // match will help you there
    // return the list of coords that is the path
// return half the path length (including the S)
// |> printfn "Part 1: %i"

// input
// |> printfn "Part 2: %i"
