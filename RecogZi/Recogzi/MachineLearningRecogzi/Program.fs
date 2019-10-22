open System
open System.IO

type Observation = {Label : String ; Pixels : float []}
type Distance = float[] * float [] -> float

[<EntryPoint>]
let main argv =
    let toObservation (csvData : string) = 
        let columns = csvData.Split(',')
        let label = columns.[0]
        let pixels = columns.[1..] |>  Array.map float
        {Label = label; Pixels = pixels}

    let reader path =
        let data = File.ReadAllLines path
        data.[1..]
        |>Array.map toObservation

    let datasetPath = @"C:\Users\dlorente\Desktop\Recogzi\dataset.csv"
     
    let data = reader datasetPath      
   
    
    let m = data.Length

    printfn "m = %i" m

    let zi = data.[34].Label

    //Separate data in training data and validation data

    let trainingdata = data.[0..m-1]

    let validationdata = data.[4901..4998]   

    let manhattanDistance (pixels1 : float [], pixels2 : float []) = 
        Array.zip pixels1 pixels2
        |> Array.map (fun (x,y) -> abs (x-y))
        |> Array.sum

    let euclidianDistance (pixels1 : float [], pixels2 : float []) = 
        Array.zip pixels1 pixels2
        |> Array.map (fun (x,y) -> pown (x-y) 2)
        |> Array.sum    
        
    let train (trainingset : Observation []) (dist : Distance) =
        let classify (pixels : float []) = 
            trainingset
            |> Array.minBy(fun x-> dist (x.Pixels, pixels))
            |> fun x -> x.Label
        classify
        
    let manhattanClassifier = train trainingdata manhattanDistance

    let euclidianClassifier = train trainingdata euclidianDistance

    let numbertest = euclidianClassifier data.[34].Pixels

    printf "Calculating Accurancy with Manhattan distance\n"
    validationdata
    |> Array.averageBy (fun x-> if manhattanClassifier x.Pixels = x.Label then 100. else 0.)
    |> printfn "manhattanClassifier Correct %.3f "

    printf "Calculating Accurancy with Euclidian distance\n"
    validationdata
    |> Array.averageBy (fun x-> if euclidianClassifier x.Pixels = x.Label then 100. else 0.)
    |> printfn "euclidianClassifier Correct %f "

    printf "Calculating Accurancy using training data. Bad practice!"
    trainingdata
    |> Array.averageBy (fun x-> if euclidianClassifier x.Pixels = x.Label then 100. else 0.)
    |> printfn "Using training data Correct %f "
    
    0 // return an integer exit code
