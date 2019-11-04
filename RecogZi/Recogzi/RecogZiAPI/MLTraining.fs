namespace RecogZiAPI

open System.IO

type Observation = {Label : string ; Pixels : int []}
type Distance = int[] * int [] -> int

type MLTraining ()=
          
   let datasetPath = @"C:\Users\dlorente\Desktop\Recogzi\dataset.csv"

   let croppedPath = @"C:\Users\dlorente\Desktop\Recogzi\Cropped.csv"

   let toObservation (csvData : string) = 
         let columns = csvData.Split(',')
         let label = columns.[0]
         let pixels = columns.[1..] |>  Array.map int
         {Label = label; Pixels = pixels}

   let reader path =
        let data = File.ReadAllLines path
        data.[0..]
        |>Array.map toObservation

   let data = reader datasetPath      

   let croppedData = reader croppedPath

   let m = data.Length
   let trainingdata = data.[0..m-1]

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

   member this.EuclidianPrediction =
        euclidianClassifier croppedData.[0].Pixels

   member this.ManhattanPrediction =
        manhattanClassifier croppedData.[0].Pixels
   
   member this.NumberOfTrainingSamples = m