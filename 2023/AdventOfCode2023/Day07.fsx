open System

// let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/07.txt")
let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/07.txt")

type Hand = {Hand:string;Bid:int}
let hands =
    input
    |> Array.map (fun line -> 
        {
            Hand = line.Split(' ')[0]
            Bid = line.Split(' ')[1] |> int
        })

let HandRank (hand:string) =
    let mostRepeatedCounts =
        Seq.countBy id hand
        |> Map.ofSeq
        |> Map.values
        |> List.ofSeq
        |> List.sortDescending
    match mostRepeatedCounts with
    | [ 5 ] -> 6
    | 4 :: _ -> 5
    | [ 3; 2 ] -> 4
    | 3 :: _ -> 3
    | 2 :: 2 :: _ -> 2
    | 2 :: _ -> 1
    | _ -> 0
let order = 
    (['A';'K';'Q';'J';'T']
     @ ([9..-1..1] |> List.map (fun n -> '0' + (char n))))
    |> List.indexed
    |> List.map (fun (i, c) -> c, i)
    |> Map.ofList
let CardComparator (a:string) (b:string) = 
    if a = b then
        0
    else
        Seq.zip a b
        |> Seq.find (fun (c1, c2) -> c1 <> c2)
        |> fun (c1, c2) -> if order[c1] > order[c2] then -1 else 1
let HandComparator (a:Hand) (b:Hand) =
    match (a.Hand, b.Hand) with
    | (a, b) when (a |> HandRank) > (b |> HandRank) -> 1 
    | (a, b) when (a |> HandRank) < (b |> HandRank) -> -1
    | (a, b) -> CardComparator a b

let foo = 
    hands
    |> Array.sortWith HandComparator

hands
|> Array.sortWith HandComparator
|> Array.indexed
|> Array.sumBy (fun (i, h) -> (i+1)*h.Bid)
|> printfn "Part 1: %i"

// input
// |> printfn "Part 2: %i"
