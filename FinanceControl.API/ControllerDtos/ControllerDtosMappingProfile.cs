using System;
using AutoMapper;
using FinanceControl.Domain.Models.Business;

namespace FinanceControl.API.ControllerDtos;

public class ControllerDtosMappingProfile : Profile
{
    public ControllerDtosMappingProfile()
    {
        CreateMap<ExpenseDto, Expense>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())//TODO: remover
                .ForMember(dest => dest.ExternalId, opt => opt.Condition(src => src.Id != Guid.Empty))//TODO: remover
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id))//TODO: remover
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }))
                .ForMember(dest => dest.OriginAccount, opt => opt.MapFrom(src => new Account { Id = src.OriginAccountId }))//TODO: remover
                .ReverseMap()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId));

        CreateMap<TransactionDto, Transaction>()
            // .ForMember(dest => dest.Id, opt => opt.Ignore())
            // .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.OriginAccount, opt => opt.MapFrom(src => new Account { Id = src.OriginAccountId }))
            .ReverseMap()
            .ForMember(dest => dest.OriginAccountId, opt => opt.MapFrom(src => src.OriginAccount.Id))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId));
 
        CreateMap<TransferDto, Transfer>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.TargetAccount, opt => opt.MapFrom(src => new Account { Id = src.TargetAccountId }))
            .ReverseMap()
            .ForMember(dest => dest.TargetAccountId, opt => opt.MapFrom(src => src.TargetAccount.Id));

        CreateMap<ReceiveDto, Receive>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())//TODO: remover
            .ForMember(dest => dest.ExternalId, opt => opt.Ignore())//TODO: remover
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }))
            .ForMember(dest => dest.OriginAccount, opt => opt.MapFrom(src => new Account { Id = src.OriginAccountId }))//TODO: remover
            .ReverseMap()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId));
    }
}
