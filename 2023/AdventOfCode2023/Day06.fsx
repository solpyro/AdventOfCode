open System

// let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/06.txt")
let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/06.txt")

let ToIntArray(string:String) = 
    string.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..]
    |> Array.map int

let times = ToIntArray(input[0])
let dists = ToIntArray(input[1])
let races = Seq.zip times dists

let BeatsRecord time record chargeTime = 
    chargeTime * (time - chargeTime) > record

let CountWaysToWin(time, distance) =
    let BeatsThisRecord = BeatsRecord time distance
    ([0..time] |> List.where BeatsThisRecord).Length

races
|> Seq.map CountWaysToWin
|> Seq.fold (fun product n -> product * n) 1
|> printfn "Part 1: %i"

// input
// |> printfn "Part 2: %i"
