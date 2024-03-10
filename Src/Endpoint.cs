using Microsoft.AspNetCore.Mvc;
using RichillCapital.SharedKernel;

namespace RichillCapital.Identity.Api;

[ApiController]
public abstract class Endpoint : ControllerBase
{
    protected virtual ActionResult HandleError(Error error) =>
        error.Type switch
        {
            ErrorType.Validation => BadRequest(error),
            ErrorType.NotFound => NotFound(error),
            ErrorType.Conflict => Conflict(error),
            _ => Problem(),
        };
}