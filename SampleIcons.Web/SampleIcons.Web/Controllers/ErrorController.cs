using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace SampleIcons.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/404")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult PageNotFound()
        {
            Response.Clear();
            Response.StatusCode = StatusCodes.Status404NotFound;
            return View("PageNotFound");
        }

        [Route("error/{code}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index(int code)
        {
            Response.Clear();
            Response.StatusCode = code;
            return View("GenericError", Response.StatusCode);
        }

        [Route("error/handle-exception")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult HandleException()
        {
            // log error
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (feature != null)
            {
                //_logger.LogException(feature.Error);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Route("error/unhandled-exception")]
        public IActionResult TestNotImplementedException() => throw new NotImplementedException();
    }
}