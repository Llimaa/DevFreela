using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly IDB _db;
        public ProjectRepository(DevFreelaDbContext dbContext, IDB db)
        {
            _dbContext = dbContext;
            _db = db;
        }

        public async Task<IList<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }


        public async Task<Project> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Projects
               .Include(p => p.Client)
               .Include(p => p.Freelancer)
               .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CancelAsync(Project project)
        {
            using (var sqlConnection = await _db.GetConAsync())
            {
                sqlConnection.Open();
                var query = "UPDATE [dbo].[Projects] SET Status = @Status, StartedAt = @StartedAt WHERE Id = @Id";

                await sqlConnection.QueryAsync(query, new
                {
                    Status = project.Status,
                    StartedAt = project.StartedAt,
                    Id = project.Id

                });
            }
        }

        public async Task FinishAsync(Project project)
        {
            using (var sqlConnection =  await _db.GetConAsync())
            {
                sqlConnection.Open();
                var query = "UPDATE [dbo].[Projects] SET Status = @Status, FinishedAt = @FinishedAt WHERE Id = @Id";

                await sqlConnection.QueryAsync(query, new
                {
                    Status = project.Status,
                    FinishedAt = project.FinishedAt,
                    Id = project.Id

                });
            }
        }

        public async Task StartAsync(Project project)
        {
            using (var sqlConnection = await _db.GetConAsync())
            {
                sqlConnection.Open();
                var query = "UPDATE [dbo].[Projects] SET Status = @Status, StartedAt = @StartedAt WHERE Id = @Id";

                await sqlConnection.QueryAsync(query, new
                {
                    Status = project.Status,
                    StartedAt = project.StartedAt,
                    Id = project.Id

                });
            }
        }

        public async Task AddCommentAsync(ProjectComment projectComment)
        {
            await _dbContext.ProjectComment.AddAsync(projectComment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
