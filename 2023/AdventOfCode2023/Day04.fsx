open System

let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/04.txt")
// let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/04.txt")

type Card = {id:int;winners:int[];numbers:int[]}
let cards =
    input
    |> Array.map(fun line -> line.Split([|"Card ";": ";" | "|], StringSplitOptions.RemoveEmptyEntries))
    |> Array.map(fun card -> {
        id = card[0] |> int;
        winners = card[1].Split(" ", StringSplitOptions.RemoveEmptyEntries) |> Array.map int;
        numbers = card[2].Split(" ", StringSplitOptions.RemoveEmptyEntries) |> Array.map int
    })

let inList haystack needle =
    haystack
    |> Array.contains needle
let countMatches card = 
    let isWinner = card.winners |> inList
    card.numbers |> Array.filter(fun n -> isWinner n) |> Array.length
let calculateScore card = pown 2 ((countMatches card)-1)

cards
|> Array.sumBy calculateScore
|> printfn "Part 1: %i"

let mutable part2Cards = cards
let mutable cardsToProcess = cards
while cardsToProcess.Length > 0 do
    cardsToProcess <- cardsToProcess
        |> Array.collect (fun card ->
            let score = countMatches card
            if score > 0 then
                cards[card.id..card.id+score-1]
            else [||])
    part2Cards <- Array.append part2Cards cardsToProcess    

part2Cards
|> Array.length
|> printfn "Part 2: %i"