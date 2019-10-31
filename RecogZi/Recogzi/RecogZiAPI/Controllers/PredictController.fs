namespace RecogZiAPI.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open RecogZiAPI

[<ApiController>]
[<Route("[controller]")>]
type PredictController (logger : ILogger<PredictController>) =
    inherit ControllerBase()
    

    [<HttpGet>]
    member __.Get() : Char =
        let zi = '你'       
        zi

    [<HttpGet("{id}")>]
    member __.Predict(id) =
        let s = "你好"  
        s
