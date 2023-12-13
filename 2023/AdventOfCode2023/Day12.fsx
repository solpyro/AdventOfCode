open System

let lines = System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/12.txt")
// let lines = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/12.txt")

type Row = { springs:string; counts:int[]}
lines
|> Array.map (fun line ->
    let split = line.Split(' ')
    {
        springs = split[0];
        counts = split[1].Split(',') |> Array.map int
    })

// input
// |> printfn "Part 1: %i"

// input
// |> printfn "Part 2: %i"
