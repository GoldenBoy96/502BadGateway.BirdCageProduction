using AutoMapper;
using BusinessLogic.Models.Reponse;
using BusinessObject.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        IUnitOfWork _unitOfWork;

        

        public AutoMapperProfile()
        {
            AutoMapping();
        }

        private void AutoMapping()
        {
            CreateMap<AccountReponse, Account>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => Constant.AccountStatus.IndexOf(src.Status)))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => Constant.Role.IndexOf(src.Role)))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Constant.AccountStatus[(int)src.StatusId]))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Constant.Role[(int)src.RoleId]));


            CreateMap<BirdCageReponse, BirdCage>();

            CreateMap<CustomerReponse, Customer>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => Constant.CustomerStatus.IndexOf( src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Constant.CustomerStatus[(int)src.StatusId]));


            CreateMap<OrderReponse, Order>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => Constant.OrderStatus.IndexOf(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Constant.OrderStatus[(int)src.StatusId]));

            CreateMap<OrderDetailReponse, OrderDetail>();
            CreateMap<PartReponse, Part>();
            CreateMap<ProcedureReponse, Procedure>();
            CreateMap<ProgressReponse, Progress>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => Constant.ProgressStatus.IndexOf(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Constant.ProgressStatus[(int)src.StatusId]));


        }
    }

    public class Constant
    {
        public static readonly List<string> AccountStatus = new()
        {
            "Active",
            "Banned"
        };
        public static readonly List<string> CustomerStatus = new()
        {
            "Active",
            "Inactive"
        };
        public static readonly List<string> OrderStatus = new()
        {
            "Pending",
            "Approved",
            "Is producing",
            "Produced",
            "Delivering",
            "Completed"
        };
        public static readonly List<string> ProgressStatus = new()
        {
            "Pending",
            "On Progress",
            "Conpleted"
        };
        public static readonly List<string> Role = new()
        {
            "Undefined",
            "Admin",
            "Manager",
            "Staff"
        };
        public static readonly List<string> Color = new()
        {
            "Undefined",
            "Purple",
            "Pink",
            "Blue",
            "Green",
            "Beige"
        };
    }
}
