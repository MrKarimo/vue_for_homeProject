using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Project.Model.Dto;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;   

namespace Project.MiddleWare
{
    public class HandlerExceptionMiddleWare
    {
        private readonly ILogger<HandlerExceptionMiddleWare> _logger;
        private readonly RequestDelegate _next;

        public HandlerExceptionMiddleWare(RequestDelegate next,
            ILogger<HandlerExceptionMiddleWare> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsunc(httpContext,
                    ex, 
                    HttpStatusCode.NotFound, 
                    "Atantion");
            }
        }

        private async Task HandleExceptionAsunc(HttpContext httpContext,
            Exception ex,
            HttpStatusCode code,
            string message)
        {
            _logger.LogError(ex.Message);
            _logger.LogError(ex.StackTrace);

            HttpResponse httpResponse = httpContext.Response;
            httpResponse.ContentType = "application/json";
            httpResponse.StatusCode = (int)code;

            ErrorDto errorDto = new ErrorDto((int)code, message);
            string result = JsonSerializer.Serialize(errorDto);

            await httpResponse.WriteAsync(result);
        }

    }
}
