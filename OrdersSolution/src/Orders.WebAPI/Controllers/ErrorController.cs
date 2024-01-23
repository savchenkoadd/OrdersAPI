using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Orders.WebAPI.Controllers
{
	[Route("error")]
	[ApiController]
	public class ErrorController : ControllerBase
	{
		public IActionResult Error()
		{
			var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
			var exception = context?.Error;

			if (exception is ArgumentException || exception is ArgumentNullException)
			{
				return Problem(
						detail: exception.Message,
						title: "Argument Error",
						statusCode: 400
					);
			}
			else
			{
				return Problem(
						detail: exception?.Message,
						title: "Server Error",
						statusCode: 500
					);
			}
		}
	}
}
