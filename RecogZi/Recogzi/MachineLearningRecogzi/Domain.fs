namespace Domain 

open System.IO

module DataSet =    

    type Observation = {Label : string; Pixels : int []}
    type Distance = int[] * int [] -> int

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
    
    let zi = data.[1].Label
    
    let cropCount = croppedData.Length
    
    let trainingdata = data.[0..m-1]
       
    