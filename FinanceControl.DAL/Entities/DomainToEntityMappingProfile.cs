using AutoMapper;
using FinanceControl.Domain.Models.Business;

namespace FinanceControl.DAL.Entities;

public class DomainToEntityMappingProfile:Profile
{
    public DomainToEntityMappingProfile()
    {
        CreateMap<Transaction, TransactionEntity>()
                .ForMember(dest => dest.OriginAccountId, opt => opt.MapFrom(src => src.OriginAccount.Id))
                .ReverseMap()
                .ForMember(dest => dest.OriginAccount, opt => opt.MapFrom(src => new Account { Id = src.OriginAccountId }));

            CreateMap<Transfer, TransferEntity>()
                .ForMember(dest => dest.TargetAccountId, opt => opt.MapFrom(src => src.TargetAccount.Id))
                .ReverseMap()
                .ForMember(dest => dest.TargetAccount, opt => opt.MapFrom(src => new Account { Id = src.TargetAccountId }));

            CreateMap<Expense, ExpenseEntity>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ReverseMap()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }));

            CreateMap<Receive, ReceiveEntity>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ReverseMap()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }));

            CreateMap<Account, AccountEntity>().ReverseMap();

            CreateMap<Category, CategoryEntity>().ReverseMap();
    }
}
