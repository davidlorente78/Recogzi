open System
open System.IO

type Observation = {Label : String ; Pixels : int []}
type Distance = int[] * int [] -> int

[<EntryPoint>]
let main argv =
    let toObservation (csvData : string) = 
        let columns = csvData.Split(',')
        let label = columns.[0]
        let pixels = columns.[1..] |>  Array.map int
        {Label = label; Pixels = pixels}

    let reader path =
        let data = File.ReadAllLines path
        data.[0..]
        |>Array.map toObservation

    let datasetPath = @"C:\Users\dlorente\Desktop\Recogzi\dataset.csv"

    let croppedPath = @"C:\Users\dlorente\Desktop\Recogzi\Cropped.csv"
     
    let data = reader datasetPath      

    let croppedData = reader croppedPath
   
    
    let m = data.Length

    printfn "m = %i" m

    let zi = data.[1].Label


    let cropCount = croppedData.Length
    
    printfn "Cropped Data = %i" cropCount

    //Separate data in training data and validation data

    let trainingdata = data.[0..m-1]

    //let validationdata = data.[4901..4998]   

    let manhattanDistance (pixels1 : int [], pixels2 : int []) = 
        Array.zip pixels1 pixels2
        |> Array.map (fun (x,y) -> abs (x-y))
        |> Array.sum

    let euclidianDistance (pixels1 : int [], pixels2 : int []) = 
        Array.zip pixels1 pixels2
        |> Array.map (fun (x,y) -> pown (x-y) 2)
        |> Array.sum    
        
    let train (trainingset : Observation []) (dist : Distance) =
        let classify (pixels : int []) = 
            trainingset
            |> Array.minBy(fun x-> dist (x.Pixels, pixels))
            |> fun x -> x.Label
        classify
        
    let manhattanClassifier = train trainingdata manhattanDistance

    let euclidianClassifier = train trainingdata euclidianDistance

    //Return Methods
    let euclidianTest0 = euclidianClassifier croppedData.[0].Pixels
    let manhattanTest0= manhattanClassifier croppedData.[0].Pixels
    let euclidianTest1 = euclidianClassifier croppedData.[1].Pixels
    let manhattanTest1 = manhattanClassifier croppedData.[1].Pixels
    let euclidianTest2 = euclidianClassifier croppedData.[2].Pixels
    let manhattanTest2 = manhattanClassifier croppedData.[2].Pixels

  
    0 // return an integer exit code
