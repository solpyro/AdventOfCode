open System

let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/01.txt")

let firstDigit line =
    Seq.find(fun i -> Char.IsDigit(i)) line 
    
let lastDigit line =
    Seq.rev(line) 
    |> firstDigit

let textToNumber (line: string) =
    line
        .Replace("one", "one1one")
        .Replace("two", "two2two")
        .Replace("three", "three3three")
        .Replace("four", "four4four")
        .Replace("five", "five5five")
        .Replace("six", "six6six")
        .Replace("seven", "seven7seven")
        .Replace("eight", "eight8eight")
        .Replace("nine", "nine9nine")

input
|> Array.sumBy(fun line -> $"{firstDigit line}{lastDigit line}" |> int)
|> printfn "Part 1: %i"

input
|> Array.map textToNumber
|> Array.sumBy(fun line -> $"{firstDigit line}{lastDigit line}" |> int)
|> printfn "Part 2: %i"
