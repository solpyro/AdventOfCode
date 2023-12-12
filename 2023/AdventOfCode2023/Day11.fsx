open System

let lines = System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/11.txt")
// let lines = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/11.txt")

let image = 
    lines 
    |> Array.map Seq.toArray
    |> array2D

let ToCols (arr:char[,]) =
    [
        let height = arr.GetLength 1
        for col in 0..height-1 do
        yield arr.[*,col] |> List.ofArray
    ]
let Expand (arr:list<list<char>>) =
    [
        for row in arr do
            if (row |> List.contains '#') then
                yield row
            else
                yield row
                yield row
    ]
    |> array2D
    
let expanded = 
    image
    |> ToCols
    |> Expand
    |> ToCols
    |> Expand

// list of all galaxy coords
// generate all pair combinations
// calculate distance between them
// sum distances
// |> printfn "Part 1: %i"

// input
// |> printfn "Part 2: %i"
