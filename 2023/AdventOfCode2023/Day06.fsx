open System

// let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/06.txt")
let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/06.txt")

let ToIntArray(string:String) = 
    string.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..]
    |> Array.map int
let times = ToIntArray input[0]
let dists = ToIntArray input[1]
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

let ToFloat(string:String) =
    string.Split(':')[1]
    |> Seq.filter(fun (c:char) -> not(c = ' '))
    |> String.Concat
    |> float
let SolveQuadratic a b c =
  let D = b*b-4.*a*c in
  [(+);(-)] |> List.map (fun f -> (f -b (sqrt D))/2./a)

let solutions = 
    SolveQuadratic -1 (input[0] |> ToFloat) -(input[1] |> ToFloat)
    |> List.map floor
    |> List.map int

(-) (solutions|> List.max) (solutions |> List.min)
|> printfn "Part 2: %i"