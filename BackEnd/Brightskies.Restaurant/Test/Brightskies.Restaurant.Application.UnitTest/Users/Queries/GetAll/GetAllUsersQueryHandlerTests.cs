using AutoFixture;
using Brightskies.Restaurant.Application.UnitTest.Common;
using Brightskies.Restaurant.Application.Users.Comands.Dtos;
using Brightskies.Restaurant.Application.Users.Queries.GetAll;
using Brightskies.Restaurant.Domain.Entities;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Brightskies.Restaurant.Application.UnitTest.Users.Queries.GetAll
{
    public class GetAllUsersQueryHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public GetAllUsersQueryHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Theory]
        [NoRecursion]
        public async Task Handle_GetAllQuery_ShouldReturnEntriesSuccessfully(List<UserOutput> output)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<List<UserOutput>>(It.IsAny<List<User>>())).Returns(output); // AutoMapper setup

            var sut = new GetAllUsersQueryHandler(_context, _mapperMock.Object); // creating system under test

            var temUser = _fixture.Create<User>();

            // Act
            await ContextOperation.CreateEntity(_context, temUser);

            var result = await sut.Handle(new GetAllUsersQuery(), CancellationToken.None);

            // Assert
            result.Count().ShouldBeGreaterThan(0);
        }
    }
}