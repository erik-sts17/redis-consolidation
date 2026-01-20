namespace Back.Redis.Business.Models.V1.Erro
{
    public class ErrorResult(object? message)
    {
        public object? Message { get; set; } = message;
    }
}