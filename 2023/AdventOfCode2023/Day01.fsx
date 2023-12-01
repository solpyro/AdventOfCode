open System
open System.Text.RegularExpressions

let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/01.txt")

let firstDigit line =
    Seq.find(fun i -> Char.IsDigit(i)) line 
    
let lastDigit line =
    Seq.rev(line) 
    |> firstDigit

input
|> Array.sumBy(fun line -> $"{firstDigit line}{lastDigit line}" |> int)
|> printfn "Part 1: %i"