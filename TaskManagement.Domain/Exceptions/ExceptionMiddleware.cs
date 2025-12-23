using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskManagement.Common.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var errorResult = new ErrorResult()
                {
                    success = false,
                    Message = exception.Message,
                };
                var response = context.Response;
                if (!response.HasStarted)
                {
                    response.ContentType = "application/json";
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await response.WriteAsync(JsonConvert.SerializeObject(errorResult));
                }

            }
           
        }
    }
}
