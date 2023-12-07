open System

let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/04.txt")

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
let calculateScore card =
    let isWinner = card.winners |> inList
    let count = card.numbers |> Array.filter(fun n -> isWinner n) |> Array.length
    pown 2 (count-1)

cards
|> Array.sumBy calculateScore
|> printfn "Part 1: %i"

// cards
// |> printfn "Part 2: %i"
// TODO - Day 4 Part 2

// Somehow I should have step through an array of cards that I can also keep adding cards to
// each card will append a certain number of cards from the original `cards` array 
// then the current card would be discarded and a counter would be incremented
// once the array was empry again, the counter would be the total number of won cards; our solution
// Possibly Array.collect would help