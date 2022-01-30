using DevFreela.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using DevFreela.Infrastructure.Persistence.Context;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IDB _db;
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(IDB db, DevFreelaDbContext dbContext)
        {
            _db = db;
            _dbContext = dbContext;
        }

        public async Task AddSkill(Skill skill)
        {
            await _dbContext.Skills.AddAsync(skill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<Skill>> GetAllAsync()
        {
            using (var sqlConnection = await _db.GetConAsync())
            {

                var query = "SELECT Id, Description FROM Skills";

                var skills = await sqlConnection.QueryAsync<Skill>(query);

                return skills.ToList();
            }
        }
    }
}
