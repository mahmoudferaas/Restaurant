using AutoMapper;
namespace Brightskies.Restaurant.Application.Common.Mappings
{
	public interface IMapFrom<T>
	{
		void Mapping(Profile profile);
	}
}