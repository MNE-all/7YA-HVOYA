using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using _7YA_HVOYA.API.Models;
using _7YA_HVOYA.API.Models.Enums;
using _7YA_HVOYA.API.ModelsRequest.Storage;
using _7YA_HVOYA.API.ModelsRequest.Accommodation;
using _7YA_HVOYA.API.ModelsRequest.Cart ;
using _7YA_HVOYA.API.ModelsRequest.Client;
using _7YA_HVOYA.API.ModelsRequest.Order;
using _7YA_HVOYA.API.ModelsRequest.Thing;
using _7YA_HVOYA.Services.Contracts.Models;
using _7YA_HVOYA.Services.Contracts.Emuns;
using _7YA_HVOYA.Services.Contracts.ModelsRequest;

namespace _7YA_HVOYA.API.Infrastructures
{
    /// <summary>
    /// Профиль маппера АПИшки
    /// </summary>
    public class ApiAutoMapperProfile : Profile
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ApiAutoMapperProfile"/>
        /// </summary>
        public ApiAutoMapperProfile()
        {
            CreateMap<CategoriesModel, CategoriesResponse>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();
            CreateMap<GendersModel, GendersResponse>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<SeasonsModel, SeasonsResponse>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();
            CreateMap<SizesModel, SizesResponse>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<CreateClientRequest, ClientRequestModel>(MemberList.Destination);

            CreateMap<CartModel, CartResponse>(MemberList.Destination)
                .ForMember(x => x.NameThing, opt => opt.MapFrom(x => x.Thing!.Name))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Client!.Email))
                .ForMember(x => x.Size, opt => opt.MapFrom(x => x.Thing!.Size));

            CreateMap<OrderModel, OrderResponse>(MemberList.Destination)
                .ForMember(x => x.NameThing, opt => opt.MapFrom(x => x.Thing!.Name))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Client!.Email))
                .ForMember(x => x.Size, opt => opt.MapFrom(x => x.Thing!.Size));

            CreateMap<AccommodationModel, AccommodationResponse>(MemberList.Destination)
                .ForMember(x => x.NameThing, opt => opt.MapFrom(x => x.Thing!.Name))
                .ForMember(x => x.NameStorage, opt => opt.MapFrom(x => x.Storage!.Name))
                .ForMember(x => x.Size, opt => opt.MapFrom(x => x.Thing!.Size));

            CreateMap<ClientModel, ClientResponse>(MemberList.Destination);

            CreateMap<ThingModel, ThingResponse>(MemberList.Destination);

            CreateMap<StorageModel, StorageResponse>(MemberList.Destination);
        }
    }

}
