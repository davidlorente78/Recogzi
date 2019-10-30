namespace RecogZiAPI.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

[<ApiController>]
[<Route("[controller]")>]
type IndexController (logger : ILogger<IndexController>) =
    inherit ControllerBase()
    
    [<HttpGet>]
       member __.Get() : String =
           let zi = "我在这里"
           zi
