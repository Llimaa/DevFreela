using DevFreela.Core.Entities;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRoleRepository
    {
        Task AddAsync(UserRole userRole);
    }
}
