﻿open System

// let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/08.2.txt")
let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/08.txt")

let path = input[0]
type Node = { Left:string; Right:string; }
let map = 
    input[2..]
    |> Array.map (fun line -> line.Split([|" = (";", ";")"|], StringSplitOptions.RemoveEmptyEntries))
    |> Array.map (fun line -> (line[0],{Left = line[1];Right = line[2]}))
    |> Map.ofArray

let NextPathPointer pathPointer = 
    if pathPointer < path.Length-1 then
        pathPointer + 1
    else
        0
let NextMapPointer mapPointer pathPointer = 
    match path[pathPointer] with
    | 'L' -> map[mapPointer].Left
    | 'R' -> map[mapPointer].Right
let rec NextNode pathPointer mapPointer depth =
    match mapPointer with
    | "ZZZ" -> depth
    | _ -> NextNode (NextPathPointer pathPointer) (NextMapPointer mapPointer pathPointer) depth+1

NextNode 0 "AAA" 0
|> printfn "Part 1: %i"

// input
// |> printfn "Part 2: %i"
