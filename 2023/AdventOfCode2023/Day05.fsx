open System

let input = System.IO.File.ReadAllText("2023/AdventOfCode2023/inputs/05test.txt").Split("\r\n\r\n")

let seeds = 
    input[0].Split(" ")[1..]
    |> Array.map int

type Mapper = {sourceStart:int;destinationStart:int;length:int}
let mappers =
    input[1..]
    |> Array.map(fun block ->
        block.Split('\n')[1..]
        |> Array.map(fun mapping ->
            mapping.Split(' ')
            |> Array.map int)
        |> Array.map(fun list -> {
            sourceStart = list[0];
            destinationStart = list[1];
            length = list[2]
        }))

//someone at work mentioned there should be a way to collapse the mappers so it's just seeds->location, idk