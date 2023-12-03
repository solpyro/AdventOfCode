open System
open System.Collections.Generic

let lines = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/02.txt")

type Game = {id:int;rounds:IDictionary<string, int>[]}
let mapRounds(rounds:string[]) =
    rounds
    |> Array.map(fun round  -> 
        round.Split(", ")
        |> Array.map(fun colour -> colour.Split(' ')[1], colour.Split(' ')[0] |> int)
        |> dict 
    )
let games = 
    lines 
    |> Array.map(fun line -> line.Split([|"Game ";": ";"; "|], StringSplitOptions.RemoveEmptyEntries))
    |> Array.map(fun game -> {
        id= game[0] |> int; 
        rounds = mapRounds game[1..]
    }) 

let IsLessThan(round:IDictionary<string,int>, key:string, target:int) = 
    match round.TryGetValue(key) with
    | true, value -> value <= target
    | _ -> true

games
|> Array.where(fun game -> 
    Array.TrueForAll(game.rounds, fun round -> 
        IsLessThan(round,"red",12) && 
        IsLessThan(round,"green",13) && 
        IsLessThan(round, "blue",14)
    )
)
|> Array.sumBy(fun game -> game.id)
|> printfn "Part 1: %i"
