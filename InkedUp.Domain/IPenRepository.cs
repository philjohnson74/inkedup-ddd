using System.Threading.Tasks;

namespace InkedUp.Domain
{
    public interface IPenRepository
    {
        Task<bool> Exists(PenId id);

        Task<Pen> Load(PenId id);

        Task Save(Pen entity);
    }
}