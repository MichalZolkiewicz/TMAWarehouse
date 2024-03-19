using AutoMapper;
using TMAWarehouse.ApplicationServices.API.Domain.User;
using TMAWarehouse.ApplicationServices.API.Domain.User.AddUser;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.ApplicationServices.API.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        this.CreateMap<AddUserRequest, User>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
            .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
            .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
            .ForMember(x => x.PositionType, y => y.MapFrom(z => z.PositionType));

        this.CreateMap<User, UserDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Surname, y => y.MapFrom(z => z.Name));
    }
}
