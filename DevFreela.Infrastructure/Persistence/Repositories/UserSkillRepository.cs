using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserSkillRepository : IUserSkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserSkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserSkill(UserSkill userSkill)
        {
            await _dbContext.UserSkills.AddAsync(userSkill);
            await _dbContext.SaveChangesAsync();
        }
    }
}
