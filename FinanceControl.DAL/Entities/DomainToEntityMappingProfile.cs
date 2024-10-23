using AutoMapper;
using FinanceControl.Domain.Models.Business;

namespace FinanceControl.DAL.Entities;

public class DomainToEntityMappingProfile:Profile
{
    public DomainToEntityMappingProfile()
    {
        CreateMap<Transaction, TransactionEntity>()
                .ForMember(dest => dest.OriginAccount, opt => opt.Ignore())
                .ForMember(dest => dest.OriginAccountId, opt => opt.MapFrom(src => src.OriginAccount.Id))
                .ReverseMap()
                .ForMember(dest => dest.OriginAccount, opt => opt.MapFrom(src => new Account { Id = src.OriginAccountId }));

        CreateMap<Transfer, TransferEntity>()
            .ForMember(dest => dest.OriginAccount, opt => opt.Ignore())//TODO: remover
            .ForMember(dest => dest.OriginAccountId, opt => opt.MapFrom(src => src.OriginAccount.Id))//TODO: remover
            .ForMember(dest => dest.TargetAccount, opt => opt.Ignore())
            .ForMember(dest => dest.TargetAccountId, opt => opt.MapFrom(src => src.TargetAccount.Id))
            .ReverseMap()
            .ForMember(dest => dest.TargetAccount, opt => opt.MapFrom(src => new Account { Id = src.TargetAccountId }))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<Expense, ExpenseEntity>()
            .ForMember(dest => dest.OriginAccount, opt => opt.Ignore())//TODO: remover
            .ForMember(dest => dest.OriginAccountId, opt => opt.MapFrom(src => src.OriginAccount.Id))//TODO: remover
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
            .ReverseMap()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<Receive, ReceiveEntity>()
            .ForMember(dest => dest.OriginAccount, opt => opt.Ignore())//TODO: remover
            .ForMember(dest => dest.OriginAccountId, opt => opt.MapFrom(src => src.OriginAccount.Id))//TODO: remover
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
            .ReverseMap()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<Account, AccountEntity>().ReverseMap();

        CreateMap<Category, CategoryEntity>().ReverseMap();
    }
}
