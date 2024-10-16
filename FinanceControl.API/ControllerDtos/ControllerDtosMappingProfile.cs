using AutoMapper;
using FinanceControl.Domain.Models.Business;

namespace FinanceControl.API.ControllerDtos;

public class ControllerDtosMappingProfile : Profile
{
    public ControllerDtosMappingProfile()
    {
        CreateMap<ExpenseDto, Expense>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }))
                .ReverseMap()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id));

        CreateMap<TransactionDto, Transaction>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.OriginAccount, opt => opt.MapFrom(src => new Account { Id = src.OriginAccountId }))
            .ReverseMap()
            .ForMember(dest => dest.OriginAccountId, opt => opt.MapFrom(src => src.OriginAccount.Id));

        CreateMap<TransferDto, Transfer>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.TargetAccount, opt => opt.MapFrom(src => new Account { Id = src.TargetAccountId }))
            .ReverseMap()
            .ForMember(dest => dest.TargetAccountId, opt => opt.MapFrom(src => src.TargetAccount.Id));

        CreateMap<ReceiveDto, Receive>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }))
            .ReverseMap()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id));
    }
}
