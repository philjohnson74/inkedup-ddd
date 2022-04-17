using System.Threading.Tasks;

namespace InkedUp.Domain
{
    public interface IPenRepository
    {
        Task<bool> Exists(string id, string ownerId);

        Task<Pen> Load(string id, string ownerId);

        Task Save(Pen entity);
    }
}