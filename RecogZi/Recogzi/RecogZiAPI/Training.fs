namespace Training

open Domain.DataSet

module Operations = 

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