open System
open System.Collections.Generic

let lines = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/02.txt")



//parse
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
// - games into rounds by ;
    |> Array.map(fun game -> {
        id= game[0] |> int; 
        rounds = mapRounds game[1..]
    }) 

//part 1
// - sum games that are possible if there are 12 red, 13 green, 14 blue
games
|> Array.where(fun game -> 
    Array.TrueForAll(
        game.rounds, 
        fun round -> 
            match round.TryGetValue("red") with
            | true, value -> value <= 12
            | false, _ -> true
            &&
            match round.TryGetValue("green") with
            | true, value -> value <= 13
            | false, _ -> true
            &&
            match round.TryGetValue("blue") with
            | true, value -> value <= 14
            | false, _ -> true
    )
)
|> Array.sumBy(fun game -> game.id)
|> printfn "Part 1: %i"