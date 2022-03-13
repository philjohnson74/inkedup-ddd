using System.Threading.Tasks;

namespace InkedUp.Framework
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}