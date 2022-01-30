using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                  .HasOne(p => p.Project)
                  .WithMany(p => p.Comments)
                  .HasForeignKey(x => x.IdProject);

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(x => x.IdUser);
        }
    }
}
