using DevFreela.Core.Entities;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserSkillRepository
    {
        Task AddUserSkill(UserSkill userSkill);
    }
}
