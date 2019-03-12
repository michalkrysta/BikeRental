using AutoMapper;
using BikeRental.Core.Domain;
using BikeRental.Infrastructure.DTO;

namespace BikeRental.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Customer, CustomerDto>();
                    cfg.CreateMap<User, UserDto>();
                })
                .CreateMapper();
    }
}