namespace WebAppMVC
{
    public static class ErrorLoggingExtensions
    {
        public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorLogging>();
        }
    }
    public class ErrorLogging
    {
        private readonly RequestDelegate _next;
        public ErrorLogging(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                if(context.Response.StatusCode != 200)
                {
                    context.Request.Path = "/Home/Error";
                }
                await _next(context);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {e.Message}");
                context.Request.Path = "/Home/Error";
                throw;
            }
        }
    }
}
