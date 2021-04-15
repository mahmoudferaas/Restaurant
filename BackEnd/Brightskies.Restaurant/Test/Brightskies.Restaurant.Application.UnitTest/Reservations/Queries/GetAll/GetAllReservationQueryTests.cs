using AutoFixture;
using Brightskies.Restaurant.Application.Reservations.Dtos;
using Brightskies.Restaurant.Application.Reservations.Queries.GetAll;
using Brightskies.Restaurant.Application.UnitTest.Common;
using Brightskies.Restaurant.Domain.Entities;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Brightskies.Restaurant.Application.UnitTest.Reservations.Queries.GetAll
{
    public class GetAllReservationQueryTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public GetAllReservationQueryTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Theory]
        [NoRecursion]
        public async Task Handle_GetAllQuery_ShouldReturnEntriesSuccessfully(List<ReservationDto> output)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<List<ReservationDto>>(It.IsAny<List<Reservation>>())).Returns(output);

            var sut = new GetAllReservationQueryHandler(_context, _mapperMock.Object);

            var temUser = _fixture.Create<Reservation>();

            // Act
            await ContextOperation.CreateEntity(_context, temUser);

            var result = await sut.Handle(new GetAllReservationQuery(), CancellationToken.None);

            // Assert
            result.Count().ShouldBeGreaterThan(0);
        }
    }
}