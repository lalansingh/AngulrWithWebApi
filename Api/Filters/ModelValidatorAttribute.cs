using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Api.Filters
{
    public class ModelValidatorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext httpActionContext)
        {
            if (!httpActionContext.ModelState.IsValid)
            {
                httpActionContext.Response =
                    httpActionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                        httpActionContext.ModelState);
            }
        }
    }
}