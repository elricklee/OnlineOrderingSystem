using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace OnlineOrdering.API.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            int statusCode;
            string message;

            switch (exception)
            {
                case KeyNotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
                case InvalidOperationException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                case UnauthorizedAccessException:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    message = "未授权访问";
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    message = "服务器内部错误，请稍后重试";
                    _logger.LogError(exception, "未处理的异常");
                    break;
            }

            var response = new
            {
                StatusCode = statusCode,
                Message = message
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsync(
                JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = false }),
                cancellationToken
            );

            return true;
        }
    }
}
