namespace RecogZiAPI.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Domain.DataSet
open Training.Operations


[<ApiController>]
[<Route("[controller]")>]
type PredictController (logger : ILogger<PredictController>) =
    inherit ControllerBase()
    
    [<HttpGet>]
    member this.Get()  =
        let query = this.Request.Query        
        let inline charToInt c = int c - int '0'
        //https://localhost:44333/Predict?data=10010
        let pixels = query.["data"].ToString() |>  Seq.map  charToInt|> Seq.toArray      
        let euclidianPrediction = Training.Operations.euclidianClassifier pixels        
        ActionResult<string>(euclidianPrediction)


