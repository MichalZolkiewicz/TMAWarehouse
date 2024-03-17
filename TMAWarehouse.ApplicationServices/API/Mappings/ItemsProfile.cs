using AutoMapper;
using TMAWarehouse.ApplicationServices.API.Domain.Item;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.ApplicationServices.API.Mappings;

public class ItemsProfile : Profile
{
    public ItemsProfile()
    {
        this.CreateMap<Item, ItemDto>()
             .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
             .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
             .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
             .ForMember(x => x.StorageLocation, y => y.MapFrom(z => z.StorageLocation));
    }
}
