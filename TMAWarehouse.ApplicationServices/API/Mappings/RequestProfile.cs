using AutoMapper;
using TMAWarehouse.ApplicationServices.API.Domain.Request;
using TMAWarehouse.ApplicationServices.API.Domain.Request.AddRequest;
using TMAWarehouse.ApplicationServices.API.Domain.Request.UpdateRequest;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.ApplicationServices.API.Mappings;

public class RequestProfile : Profile
{
    public RequestProfile()
    {
        this.CreateMap<Request, RequestDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName));


        this.CreateMap<AddRequestRequest, Request>()
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
            .ForMember(x => x.ItemId, y => y.MapFrom(z => z.ItemId))
            .ForMember(x => x.UnitOfMeasurement, y => y.MapFrom(z => z.UnitOfMeasurement))
            .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
            .ForMember(x => x.NetPrice, y => y.MapFrom(z => z.NetPrice))
            .ForMember(x => x.Comment, y => y.MapFrom(z => z.Comment));

        this.CreateMap<UpdateRequestRequest, Request>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.RequestId))
            .ForMember(x => x.Status, y => y.MapFrom(z => z.Status));
    }
}
