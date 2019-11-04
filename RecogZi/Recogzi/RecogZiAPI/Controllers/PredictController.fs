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
        
        //https://localhost:44333/Predict?data=10010
        let data = query.["data"] 
        
        let pixels = [|1;0;0;1;0|]
        let euclidianPrediction = Training.Operations.euclidianClassifier pixels    
    
        ActionResult<string>(euclidianPrediction)


