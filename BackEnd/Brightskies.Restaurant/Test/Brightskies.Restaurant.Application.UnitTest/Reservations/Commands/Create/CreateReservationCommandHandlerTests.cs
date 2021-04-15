using Brightskies.Restaurant.Application.Reservations.Commands.Create;
using Brightskies.Restaurant.Application.UnitTest.Common;
using Brightskies.Restaurant.Domain.Entities;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Brightskies.Restaurant.Application.UnitTest.Reservations.Commands.Create
{
    public class CreateReservationCommandHandlerTests : CommandTestBase
    {
        [Theory]
        [NoRecursion]
        public async Task Handle_ValidCommand_ShouldSaveEntriesSuccessfully(Reservation Reservation)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<Reservation>(It.IsAny<CreateReservationCommand>())).Returns(Reservation); 

            var sut = new CreateReservationCommandHandler(_context, _mapperMock.Object); // creating system under test

            // Act
            await sut.Handle(new CreateReservationCommand(), CancellationToken.None);

            // Assert
            _context.Reservations.Count().ShouldBe(1);
        }
    }
}