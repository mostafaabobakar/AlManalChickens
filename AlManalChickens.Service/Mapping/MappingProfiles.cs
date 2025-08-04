using AutoMapper;
using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Entities.AdditionalTables;
using AlManalChickens.Domain.Entities.SettingTables;
using AlManalChickens.Domain.Entities.UserTables;
using AlManalChickens.Services.DTO.AppClientDTO.AboutUsClientDto;
using AlManalChickens.Services.DTO.AppClientDTO.CondtionsClientDto;
using AlManalChickens.Services.DTO.AppClientDTO.ContactUsClientDto;
using AlManalChickens.Services.DTO.AppProviderDTO.AboutUsProviderDto;
using AlManalChickens.Services.DTO.AppProviderDTO.CondtionsProviderDto;
using AlManalChickens.Services.DTO.AppProviderDTO.ContactUsProviderDto;
using AlManalChickens.Services.DTO.AuthApiDTO;
using AlManalChickens.Services.DTO.OrderDTO;
using AlManalChickens.Services.DTO.SettingDTO;

namespace AlManalChickens.Services.Mapping
{
    internal class MappingProfiles : Profile
    {
        #region App

        public static MapperConfiguration SettingsProfile(string lang)
        {
            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<Setting, SettingDto>()
                        .ForMember(dto => dto.phone, conf => conf.MapFrom(ol => ol.Phone))
                        .ForMember(dto => dto.aboutUs, conf => conf.MapFrom(ol => ol.ChangeLangAboutUsClient(lang)))
                        .ForMember(dto => dto.aboutUsProvider,
                            conf => conf.MapFrom(ol => ol.ChangeLangAboutUsProvider(lang)))
                        .ForMember(dto => dto.condtions, conf => conf.MapFrom(ol => ol.ChangeLangCondtionClient(lang)))
                        .ForMember(dto => dto.condtionsProvider,
                            conf => conf.MapFrom(ol => ol.ChangeLangCondtionProvider(lang)))
            );
            return configuration;
        }

        public static MapperConfiguration AboutUsClientProfile(string lang)
        {
            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<Setting, AboutUsClientDto>()
                        .ForMember(dto => dto.aboutUs, conf => conf.MapFrom(ol => ol.ChangeLangAboutUsClient(lang)))
            );
            return configuration;
        }

        public static MapperConfiguration ContactUsClientProfile()
        {
            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<ContactUs, ContactUsClientListDto>()
                        .ForMember(dto => dto.email, conf => conf.MapFrom(ol => ol.Email))
                        .ForMember(dto => dto.id, conf => conf.MapFrom(ol => ol.Id))
                        .ForMember(dto => dto.msg, conf => conf.MapFrom(ol => ol.Msg))
                        .ForMember(dto => dto.userName, conf => conf.MapFrom(ol => ol.UserName))
            );
            return configuration;
        }

        public static MapperConfiguration CondtionClientProfile(string lang)
        {
            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<Setting, CondtionsClientDto>()
                        .ForMember(dto => dto.condtions, conf => conf.MapFrom(ol => ol.ChangeLangCondtionClient(lang)))
            );
            return configuration;
        }


        public static MapperConfiguration AboutUsProviderProfile(string lang)
        {
            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<Setting, AboutUsProviderDto>()
                        .ForMember(dto => dto.aboutUs, conf => conf.MapFrom(ol => ol.ChangeLangAboutUsProvider(lang)))
            );
            return configuration;
        }

        public static MapperConfiguration ContactUsProviderProfile()
        {
            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<ContactUs, ContactUsProviderListDto>()
                        .ForMember(dto => dto.email, conf => conf.MapFrom(ol => ol.Email))
                        .ForMember(dto => dto.id, conf => conf.MapFrom(ol => ol.Id))
                        .ForMember(dto => dto.msg, conf => conf.MapFrom(ol => ol.Msg))
                        .ForMember(dto => dto.userName, conf => conf.MapFrom(ol => ol.UserName))
            );
            return configuration;
        }

        public static MapperConfiguration CondtionProviderProfile(string lang)
        {
            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<Setting, CondtionsProviderDto>()
                        .ForMember(dto => dto.condtions,
                            conf => conf.MapFrom(ol => ol.ChangeLangCondtionProvider(lang)))
            );
            return configuration;
        }

        #endregion

        #region Logic

        public static MapperConfiguration OrdersProviderMapping(string lang)
        {
            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<Order, OrderListDto>()
                        .ForMember(dto => dto.date,
                            conf => conf.MapFrom(ol => ol.DateTime.ToString("dd/MM/yyyy HH:mm")))
                        .ForMember(dto => dto.location, conf => conf.MapFrom(ol => ol.User.Location))
                        .ForMember(dto => dto.name, conf => conf.MapFrom(ol => ol.User.FullName))
                        .ForMember(dto => dto.orderId, conf => conf.MapFrom(ol => ol.Id))
                        .ForMember(dto => dto.stutes, conf => conf.MapFrom(ol => Helper.StatusText(ol.Stutes, lang))));
            return configuration;
        }

        public static MapperConfiguration OrdersUserMapping(string lang)
        {
            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<Order, OrderListDto>()
                        .ForMember(dto => dto.date,
                            conf => conf.MapFrom(ol => ol.DateTime.ToString("dd/MM/yyyy HH:mm")))
                        .ForMember(dto => dto.location, conf => conf.MapFrom(ol => ol.User.Location))
                        .ForMember(dto => dto.name, conf => conf.MapFrom(ol => ol.Provider.FullName))
                        .ForMember(dto => dto.orderId, conf => conf.MapFrom(ol => ol.Id))
                        .ForMember(dto => dto.stutes, conf => conf.MapFrom(ol => Helper.StatusText(ol.Stutes, lang))));
            return configuration;
        }

        #endregion


        #region User

        public static MapperConfiguration UserInfo(string token)
        {
            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<ApplicationDbUser, UserInfoDto>()
                        .ForMember(dest => dest.Id, src => src.MapFrom(u => u.Id))
                        .ForMember(dest => dest.FullName, src => src.MapFrom(u => u.FullName))
                        .ForMember(dest => dest.Email, src => src.MapFrom(u => u.Email))
                        .ForMember(dest => dest.PhoneNumber, src => src.MapFrom(u => u.PhoneNumber))
                        .ForMember(dest => dest.UserType, src => src.MapFrom(u => u.Type))
                        .ForMember(dest => dest.ProfilePicture,
                            src => src.MapFrom(u => $"{DefaultPath.DomainUrl}{u.ProfilePicture}"))
                        .ForMember(dest => dest.AllowNotify, src => src.MapFrom(u => u.AllowNotify))
                        .ForMember(dest => dest.Token, src => src.MapFrom(u => token))
                        .ForMember(dest => dest.Lat, src => src.MapFrom(u => u.Lat))
                        .ForMember(dest => dest.Lng, src => src.MapFrom(u => u.Lng))
                        .ForMember(dest => dest.Location, src => src.MapFrom(u => u.Location)));
            return configuration;
        }

        public static MapperConfiguration ProviderInfo(string token)
        {
            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<ApplicationDbUser, UserInfoDto>()
                        .ForMember(dto => dto.Id, conf => conf.MapFrom(ol => ol.Id))
                        .ForMember(dto => dto.ProfilePicture,
                            conf => conf.MapFrom(ol => DefaultPath.DomainUrl + ol.ProfilePicture))
                        .ForMember(dto => dto.FullName, conf => conf.MapFrom(ol => ol.FullName))
                        .ForMember(dto => dto.PhoneNumber, conf => conf.MapFrom(ol => ol.PhoneNumber))
                        .ForMember(dto => dto.UserType, conf => conf.MapFrom(ol => ol.Type))
                        .ForMember(dto => dto.Email, conf => conf.MapFrom(ol => ol.Email))
                        .ForMember(dto => dto.Token, conf => conf.MapFrom(ol => token))
                        .ForMember(dto => dto.AllowNotify, conf => conf.MapFrom(ol => ol.AllowNotify))
            );
            return configuration;
        }

        #endregion
    }
}