let findSmallestMultipleWithOnesSeq n =
    let rec findSmallestMultipleWithOnesSeq' remainder length =
        match remainder with
        | 0 -> length
        | _ -> 
            let nextRemainder = (remainder * 10 + 1) % n
            findSmallestMultipleWithOnesSeq' nextRemainder (length + 1)
    findSmallestMultipleWithOnesSeq' 1 1

let inputLines = System.IO.File.ReadAllLines("input.txt")
let outputLines = 
    inputLines
    |> Array.map int
    |> Array.map findSmallestMultipleWithOnesSeq
    |> Array.map string
System.IO.File.WriteAllLines("output.txt", outputLines)