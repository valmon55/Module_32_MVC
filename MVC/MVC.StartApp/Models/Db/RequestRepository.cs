using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MVC.StartApp.Models.Db
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;
        public RequestRepository(BlogContext context) 
        { 
            _context = context;
        }
        public async Task Log(Request request)
        {
            request.Date = DateTime.Now;
            request.Id= Guid.NewGuid();

            var entry = _context.Entry(request);
            if(entry.State == EntityState.Detached) 
            { 
                await _context.Requests.AddAsync(request);
            }
            await _context.SaveChangesAsync();
        }
    }
}
