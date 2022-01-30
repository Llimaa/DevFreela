using DevFreela.Application.Queries.GetUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetUserQueryHandlerTests
    {
        [Fact]
        public async void GivenUserById_Executed_ReturnOneUserViewModels()
        {
            var user = new User("Marcos Lima", "lima@gmail.com", DateTime.Now, "aadlslds");

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(ur => ur.GetByIdAsync(0).Result).Returns(user);

            var getUserQuery = new GetUserQuery(0);
            var getUserQueryHandler = new GetUserQueryHandler(userRepositoryMock.Object);

            var userViewModel = await userRepositoryMock.Object.GetByIdAsync(0);

            Assert.NotNull(userViewModel);
            userRepositoryMock.Verify(pr => pr.GetByIdAsync(It.IsAny<int>()).Result, Times.Once());
        }
    }
}
