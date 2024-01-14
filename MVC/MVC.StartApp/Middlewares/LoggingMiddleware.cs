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
        private IRequestRepository _repo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository requestRepository)
        {
            _next = next;
            _repo = requestRepository;
        }
        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            string url = "http://" + context.Request.Host.Value + context.Request.Path;
            await Log(url);
            //Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
            await _next?.Invoke(context);
        }
        private async Task Log(string url)
        {
            if (_repo != null) 
            { 
                await _repo.Log(new Request() { Url = url });
            }
            Console.WriteLine($"LOG:  [{DateTime.Now}]: New request to http://{url}");
        }
    }
}
