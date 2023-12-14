open System


let input = System.IO.File.ReadAllText("2023/AdventOfCode2023/tests/13.txt").Split("\r\n\r\n")
// let input = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/13.txt").Split("\r\n\r\n")

let patterns =
    input
    |> Array.map (fun pattern -> 
        pattern.Split("\r\n")
        |> array2D)

// of course there are red twin res/columns - to know we have the right one, we have to also compare out until we hit a wall  

// patterns
// |> Array.sumBy (fun pattern ->
//     find row -> count rows to left
//     find col -> count rows above * 100)
// |> printfn "Part 1: %i"

// input
// |> printfn "Part 2: %i"
