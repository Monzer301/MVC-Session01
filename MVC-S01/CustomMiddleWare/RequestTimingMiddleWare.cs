using System.Diagnostics;

namespace MVC_S01.CustomMiddleWare
{
    public class RequestTimingMiddleWare
    {
        private readonly RequestDelegate _next;
        public RequestTimingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var watch=Stopwatch.StartNew();
            await _next.Invoke(context);

            watch.Stop();
            Console.WriteLine($"{context.Request.Path} - {watch.ElapsedMilliseconds} ms ");
        }
    }
}
