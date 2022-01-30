using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillQueryHandlerTests
    {
        [Fact]
        public async Task ThreeSkillExist_Executed_ReturnThreeSkillViewModels()
        {
            var skills = new List<Skill>
            {
                new Skill("C#"),
                new Skill("Agile"),
                new Skill("Performance")
            };

            var skillRepositoryMock = new Mock<ISkillRepository>();
            skillRepositoryMock.Setup(sr => sr.GetAllAsync().Result).Returns(skills);

            var getAllSkillQuery = new GetAllSkillQuery();
            var getAllSkillQueryHandler = new GetAllSkillQueryHandler(skillRepositoryMock.Object);

            var skikViewModelList = await getAllSkillQueryHandler.Handle(getAllSkillQuery, new CancellationToken());

            Assert.NotNull(skikViewModelList);
            Assert.NotEmpty(skikViewModelList);
            skillRepositoryMock.Verify(sr => sr.GetAllAsync().Result, Times.Once());
        }
    }
}
