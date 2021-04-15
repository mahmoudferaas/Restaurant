using AutoMapper;
using Brightskies.Restaurant.Application.Common.Mappings;
using Brightskies.Restaurant.Persistence;
using System;
using Xunit;

namespace Brightskies.Restaurant.Application.UnitTest.Common
{
    public class QueryTestFixture : IDisposable
    {
        public RestaurantDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = ContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}