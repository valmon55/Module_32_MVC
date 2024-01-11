using System.Threading.Tasks;

namespace MVC.StartApp.Models.Db
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
