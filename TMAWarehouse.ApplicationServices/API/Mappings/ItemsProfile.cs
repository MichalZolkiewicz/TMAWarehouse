using AutoMapper;
using TMAWarehouse.ApplicationServices.API.Domain.Item;
using TMAWarehouse.ApplicationServices.API.Domain.Item.AddItem;
using TMAWarehouse.ApplicationServices.API.Domain.Item.UpdateItemQuantity;
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

        this.CreateMap<UpdateItemQuantityRequest, Item>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Quantity, y => y.MapFrom(z => z.ItemQuantity));

        this.CreateMap<AddItemRequest, Item>()
             .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
             .ForMember(x => x.ItemGroup, y => y.MapFrom(z => z.ItemGroup))
             .ForMember(x => x.UnitOfMeasurement, y => y.MapFrom(z => z.UnitOfMeasurement))
             .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
             .ForMember(x => x.NetPrice, y => y.MapFrom(z => z.NetPrice))
             .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
             .ForMember(x => x.StorageLocation, y => y.MapFrom(z => z.StorageLocation))
             .ForMember(x => x.ContactPerson, y => y.MapFrom(z => z.ContactPerson));

    }
}
