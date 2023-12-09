open System

// let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/07.2.txt")
let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/07.txt")

type Hand = {Hand:string;Bid:int}
let hands =
    input
    |> Array.map (fun line -> 
        {
            Hand = line.Split(' ')[0]
            Bid = line.Split(' ')[1] |> int
        })

let HandRank jIsJoker (hand:string) =
    let counts = Seq.countBy id hand |> Map.ofSeq
    let jokers = 
        if jIsJoker then
            Map.tryFind 'J' counts |> Option.defaultValue 0
        else 0
    let mostRepeatedCounts =
        counts
        |> Map.filter (fun key _ -> if jIsJoker then key <> 'J' else true)
        |> Map.values
        |> List.ofSeq
        |> List.sortDescending
        |> function
            | (h :: t) -> (h+jokers) :: t
            | [] -> jokers :: []
    match mostRepeatedCounts with
    | [ 5 ] -> 6
    | 4 :: _ -> 5
    | [ 3; 2 ] -> 4
    | 3 :: _ -> 3
    | 2 :: 2 :: _ -> 2
    | 2 :: _ -> 1
    | _ -> 0
let cardOrder = 
    (['A';'K';'Q';'J';'T']
     @ ([9..-1..1] |> List.map (fun n -> '0' + (char n))))
    |> List.indexed
    |> List.map (fun (i, c) -> c, i)
    |> Map.ofList
let cardOrder_JLast =
    cardOrder
    |> Map.change 'J' (fun _ -> Some cardOrder.Count)

let CardComparator (cardRank:Map<char,int>) (a:string) (b:string) = 
    if a = b then
        0
    else
        Seq.zip a b
        |> Seq.find (fun (c1, c2) -> c1 <> c2)
        |> fun (c1, c2) -> if cardRank[c1] > cardRank[c2] then -1 else 1
let HandComparator jIsJoker (a:Hand) (b:Hand) =
    match (a.Hand, b.Hand) with
    | (a, b) when (a |> HandRank jIsJoker) > (b |> HandRank jIsJoker) -> 1 
    | (a, b) when (a |> HandRank jIsJoker) < (b |> HandRank jIsJoker) -> -1
    | (a, b) -> CardComparator (if  jIsJoker then cardOrder_JLast else cardOrder) a b

let foo = 
    hands
    |> Array.sortWith (HandComparator true)

hands
|> Array.sortWith (HandComparator false)
|> Array.indexed
|> Array.sumBy (fun (i, h) -> (i+1)*h.Bid)
|> printfn "Part 1: %i"

hands
|> Array.sortWith (HandComparator true)
|> Array.indexed
|> Array.sumBy (fun (i, h) -> (i+1)*h.Bid)
|> printfn "Part 2: %i"
