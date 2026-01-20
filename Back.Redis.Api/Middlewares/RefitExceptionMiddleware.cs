using Back.Redis.Business.Models.V1.Erro;
using Refit;
using System.Net;
using System.Text.Json;

namespace Back.Redis.Api.Middlewares
{
    public class RefitExceptionMiddleware(RequestDelegate next, ILogger<RefitExceptionMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<RefitExceptionMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException apiEx)
            {
                _logger.LogError(apiEx, "Erro na requisição à API externa - TraceId: {TraceId}", context.TraceIdentifier);
                await HandleApiExceptionAsync(context, apiEx);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado - TraceId: {TraceId}", context.TraceIdentifier);
                await HandleUnexpectedExceptionAsync(context);
            }
        }

        private static async Task HandleApiExceptionAsync(HttpContext context, ApiException apiEx)
        {
            context.Response.StatusCode = (int)apiEx.StatusCode;
            context.Response.ContentType = "application/json";

            var content = apiEx.Content ?? "Erro ao obter dados da API";
            object? mensagemErro;

            try
            {
                mensagemErro = JsonSerializer.Deserialize<object>(content);
            }
            catch
            {
                mensagemErro = content;
            }

            await WriteJsonResponseAsync(context, new ErrorResult(mensagemErro));
        }

        private static async Task HandleUnexpectedExceptionAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            await WriteJsonResponseAsync(context, new ErrorResult("Ocorreu um erro interno no servidor."));
        }

        private static async Task WriteJsonResponseAsync(HttpContext context, object responseObj)
        {
            await context.Response.WriteAsync(JsonSerializer.Serialize(responseObj));
        }
    }
}
