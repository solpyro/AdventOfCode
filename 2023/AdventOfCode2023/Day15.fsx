open System

let input = System.IO.File.ReadAllText("2023/AdventOfCode2023/tests/15.2.txt").Split(',')
// let input = System.IO.File.ReadAllText("2023/AdventOfCode2023/inputs/15.txt").Split(',')

let HASH (str:string) = Seq.fold (fun i c -> ((i + (int c))*17)%256) 0 str

input
|> Array.sumBy HASH
|> printfn "Part 1: %i"

type Lens = { Label:string; FocalLength:int } //needs to be mutable
let boxes:Lens[][] = Array.empty //should be initilised to 256 empty arrays 
for instr in input do
    let label = instr.Split([|'=';'-'|], StringSplitOptions.RemoveEmptyEntries)[0]
    let box = HASH label
    let LensWithLabel ele = ele.Label = label
    let LensesWithoutLabel ele = not(LensWithLabel ele)
    if instr.Contains('-') then
        boxes[box] <- Array.filter LensesWithoutLabel boxes[box]
    else
        let focalLength = instr.Split('=')[1] |> int
        if (boxes[box] |> Array.exists LensWithLabel) then
            boxes[box][Array.FindIndex(boxes[box], LensWithLabel)].FocalLength <- focalLength //not sure why the compiler suddenly tells me boxes[box] doesnt exist here
        else
            boxes[box] <- Array.append boxes[box] [|{Label = label; FocalLength = focalLength}|]

boxes
|> Array.mapi (fun i box -> (i+1, box))
|> Array.sumBy (fun (i, box) -> 
    (box 
    |> Array.mapi (fun j lens -> (j, lens))
    |> Array.sumBy (fun (j, lens) -> j*lens.FocalLength)
    ) * i)
|> printfn "Part 2: %i"