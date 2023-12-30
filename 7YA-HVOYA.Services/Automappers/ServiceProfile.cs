using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Serilog;
using _7YA_HVOYA.Context.Contracts.Emuns;
using _7YA_HVOYA.Context.Contracts.Models;
using _7YA_HVOYA.Services.Contracts.Models;
using _7YA_HVOYA.Services.Contracts;
using _7YA_HVOYA.Services.Contracts.Emuns;

namespace _7YA_HVOYA.Services.Automappers
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Seasons, SeasonsModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<Categories, CategoriesModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<Genders, GendersModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<Sizes, SizesModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<Thing, ThingModel>(MemberList.Destination);

            CreateMap<Client, ClientModel>(MemberList.Destination);

            CreateMap<Cart, CartModel>(MemberList.Destination);

            CreateMap<Accommodation, AccommodationModel>(MemberList.Destination);

            CreateMap<Storage, StorageModel>(MemberList.Destination);

            CreateMap<Order, OrderModel>(MemberList.Destination);
            /*
            CreateMap<Group, GroupModel>(MemberList.Destination)
                .ForMember(x => x.Students, next => next.Ignore())
                .ForMember(x => x.ClassroomTeacher, next => next.Ignore());

            CreateMap<TimeTableItem, TimeTableItemModel>(MemberList.Destination)
                .ForMember(x => x.Group, next => next.Ignore())
                .ForMember(x => x.Discipline, next => next.Ignore())
                .ForMember(x => x.Teacher, next => next.Ignore());
            */
            Log.Information("Инициализирован Mapper в классе ServiceProfile");
        }
    }
}
