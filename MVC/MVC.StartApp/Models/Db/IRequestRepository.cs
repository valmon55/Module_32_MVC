using System.Threading.Tasks;

namespace MVC.StartApp.Models.Db
{
    public interface IRequestRepository
    {
        Task Log(Request request);
    }
}
