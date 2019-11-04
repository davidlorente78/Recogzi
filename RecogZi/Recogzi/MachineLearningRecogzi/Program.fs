
open Domain
open Training.Operations

[<EntryPoint>]
let main argv =
        
    let manhattanClassifier = train DataSet.trainingdata manhattanDistance
    let euclidianClassifier = train DataSet.trainingdata euclidianDistance

    //Return Methods
    let euclidianTest0 = euclidianClassifier DataSet.croppedData.[0].Pixels
    let manhattanTest0= manhattanClassifier DataSet.croppedData.[0].Pixels
    let euclidianTest1 = euclidianClassifier DataSet.croppedData.[1].Pixels
    let manhattanTest1 = manhattanClassifier DataSet.croppedData.[1].Pixels
    let euclidianTest2 = euclidianClassifier DataSet.croppedData.[2].Pixels
    let manhattanTest2 = manhattanClassifier DataSet.croppedData.[2].Pixels
  
    0 // return an integer exit code
