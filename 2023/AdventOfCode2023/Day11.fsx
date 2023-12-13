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

let galaxies =
    List.allPairs [0..expanded.GetLength(0)-1] [0..expanded.GetLength(1)-1]
    |> List.filter (fun (y, x) -> expanded[y,x] = '#')

let rec AllPairCombinations list =
    if List.length(list) = 2 then
        [(list[0], list[1])]
    else 
        List.append (list.Tail |> (List.allPairs [list.Head])) (list.Tail |> AllPairCombinations)

let pairs =
    galaxies
    |> AllPairCombinations

let GetDist ((y1,x1), (y2,x2)) =
    abs(y2-y1)+abs(x2-x1)

pairs
|> List.sumBy GetDist
|> printfn "Part 1: %i"

// input
// |> printfn "Part 2: %i"
