using AutoMapper;
using Brightskies.Restaurant.Persistence;
using Moq;
using System;

namespace Brightskies.Restaurant.Application.UnitTest.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly RestaurantDbContext _context;
        protected readonly Mock<IMapper> _mapperMock;

        public CommandTestBase()
        {
            _context = ContextFactory.Create();
            _mapperMock = new Mock<IMapper>();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(_context);
        }
    }
}