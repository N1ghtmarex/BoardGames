namespace Application.Middlewares
{
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
