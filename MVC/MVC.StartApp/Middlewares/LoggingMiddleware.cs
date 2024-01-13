using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.IO;
using MVC.StartApp.Models.Db;

namespace ASP.StartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RequestRepository _repo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, RequestRepository requestRepository)
        {
            _next = next;
            _repo = requestRepository;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            string url = context.Request.Host.Value + context.Request.Path;
            Log(url);
            //Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
            await _next?.Invoke(context);
        }
        private async void Log(string url)
        {
            if (_repo != null) 
            { 
                await _repo.Log(new Request() { Url = url });
            }
            Console.WriteLine($"LOG:  [{DateTime.Now}]: New request to http://{url}");
        }
    }
}
