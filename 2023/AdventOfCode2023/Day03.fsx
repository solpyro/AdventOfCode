
let lines = System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/03test.txt")

let schematic = 
    lines 
    |> Array.map Seq.toArray
    |> array2D
let height = Array2D.length1(schematic)-1
let width = Array2D.length2(schematic)-1

let neighbourValues(y, x, schematic:char[,]) =
    [if y > 0 && x > 0 then yield (schematic[y-1, x-1] |> int)
     if y > 0 then yield (schematic[y-1, x] |> int)
     if y > 0 && x < width then yield (schematic[y-1, x+1] |> int)
     if x < width then yield (schematic[y,x+1] |> int)
     if y < height && x < width then yield (schematic[y+1,x+1] |> int)
     if y < height then yield (schematic[y+1,x] |> int)
     if y < height && x > 0 then yield (schematic[y+1,x-1] |> int)
     if x > 0 then yield (schematic[y,x-1] |> int)]

List.allPairs [0..height] [0..width]
|> List.sumBy (fun (y, x) ->
    match schematic[x,y] with
    | '.' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' -> 0
    | _ -> neighbourValues(y,x,schematic)  |> List.sum
)
|> printfn "Part 1: %i"
