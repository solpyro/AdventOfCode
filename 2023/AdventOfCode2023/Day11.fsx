open System

// let lines = System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/11.txt")
let lines = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/11.txt")

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

let FindGalaxies (image:char[,]) =
    List.allPairs [0..image.GetLength(0)-1] [0..image.GetLength(1)-1]
    |> List.filter (fun (y, x) -> image[y,x] = '#')

let rec AllPairCombinations list =
    if List.length(list) = 2 then
        [(list[0], list[1])]
    else 
        List.append (list.Tail |> (List.allPairs [list.Head])) (list.Tail |> AllPairCombinations)

let pairs =
    expanded
    |> FindGalaxies
    |> AllPairCombinations

let GetDist ((y1,x1), (y2,x2)) =
    abs(y2-y1)+abs(x2-x1)

pairs
|> List.sumBy GetDist
|> printfn "Part 1: %i"

// let MillionExpand (arr:list<list<char>>)
//     [
//         for row in arr do
//             if (row |> List.contains '#') then
//                 yield row
//             else
//                 yield //'M' for row.Length
//     ]
//     |> array2D
// let millionExpanded = 
//     image
//     |> ToCols
//     |> MillionExpand
//     |> ToCols
//     |> MillionExpand

// let millionPairs =
//     millionExpanded
//     |> FindGalaxies
//     |> AllPairCombinations

// let GetMillionDist ((y1,x1), (y2,x2)) =
//     count xDiff  yDiff, adding 1_000_000 for every M also encountered

// millionPairs
// |> List.sumBy GetMillionDist
// |> printfn "Part 2: %i"