using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.UI.Infra;

namespace ShortUrl.UI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }

        protected IActionResult ErrorModelState()
        {
            return BadRequest(Envelope.Error(string.Join(";", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))));
        }

        protected IActionResult FromResult(Result result)
        {
            return result.IsSuccess ? Ok() : Error(result.Error);
        }

        protected IActionResult FromResult<T>(Result<T> result)
        {
            return result.IsSuccess ? Ok(result.Value) : Error(result.Error);
        }
    }
}
