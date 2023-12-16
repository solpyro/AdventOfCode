open System

let grid = 
    // System.IO.File.ReadAllLines("2023/AdventOfCode2023/tests/16.txt")
    System.IO.File.ReadAllLines("2023/AdventOfCode2023/inputs/16.txt")
    |> array2D

type Direction =
    | North
    | East
    | South
    | West
type Beam = { Cell:int*int; Direction:Direction }

let mutable allBeams = [||]
let mutable beams = [|{ Cell=(0,0); Direction=East }|]
let energised = Array2D.init (grid.GetLength 0) (grid.GetLength 1) (fun _ _ -> false)

let Energise energised (x,y) = Array2D.set energised y x true
let MoveInDir (x,y) dir =
    match dir with
    | North -> (x, y-1)
    | West -> (x-1, y)
    | South -> (x, y+1)
    | East -> (x+1, y)
let IsInRange (x, y) = x >= 0 && y >= 0 && x < grid.GetLength(1) && y < grid.GetLength(0)
let NewBeams (grid:char[,]) beam =
    let (x,y) = beam.Cell
    let dirs = 
        match grid[y,x], beam.Direction with
        | '.', North | '/', East | '\\', West | '|', North -> [| North |]
        | '.', East | '/', North | '\\', South | '-', East -> [| East |]
        | '.', South | '/', West | '\\', East | '|', South -> [| South |]
        | '.', West | '/', South | '\\', North | '-', West -> [| West |]
        | '|', West | '|', East -> [| North; South |]
        | '-', North | '-', South -> [| West; East |]
        | _ -> [||]
    dirs
    |> Array.allPairs [|beam.Cell|]
    |> Array.map (fun (coord, dir) -> { Cell = (MoveInDir coord dir); Direction = dir})
    |> Array.filter (fun beam -> (beam.Cell |> IsInRange) && not(allBeams |> Array.exists (fun oldBeam -> (oldBeam.Cell = beam.Cell) && (oldBeam.Direction = beam.Direction))))

while beams.Length > 0 do
    beams <- beams
    |> Array.collect (fun beam ->
        ignore(Energise energised beam.Cell)
        ignore(allBeams <- Array.append allBeams [| beam |])
        NewBeams grid beam)

let CalculateEnergy (energised:bool[,]) = 
    [|
        for x in [0..(energised.GetLength 1)-1] do
            for y in [0..(energised.GetLength 0)-1] do
                yield energised.[y,x]
    |]
    |> Array.sumBy (fun b -> if b then 1 else 0)

energised
|> CalculateEnergy
|> printfn "Part 1: %i"

// grid
// |> printfn "Part 2: %i"
