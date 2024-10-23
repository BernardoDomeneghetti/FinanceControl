using AutoMapper;
using FinanceControl.Domain.Models.Business;
using FinanceControl.Domain.Models.DTOs.Reponses;
using FinanceControl.Domain.Models.DTOs.Requests;

namespace FinanceControl.Domain.Models.DTOs;

public class DtosMappingProfile : Profile
{
    public DtosMappingProfile()
    {

        #region Requests
        CreateMap<AccountRequest, Account>();

        CreateMap<TransactionRequest, Transaction>()
            .ForMember(dest => dest.OriginAccount, opt => opt.MapFrom(src => new Account { Id = src.OriginAccountId }));
        
        CreateMap<ExpenseRequest, Expense>()
            .IncludeBase<TransactionRequest, Transaction>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }));

        CreateMap<ReceiveRequest, Receive>()
            .IncludeBase<TransactionRequest, Transaction>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }));
        
        CreateMap<TransferRequest, Transfer>()
            .IncludeBase<TransactionRequest, Transaction>()
            .ForMember(dest => dest.TargetAccount, opt => opt.MapFrom(src => new Account { Id = src.TargetAccountId }));
        #endregion

        #region Responses
        CreateMap<Account, AccountResponse>();

        CreateMap<Transaction, TransactionResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId));            

        CreateMap<Expense, ExpenseResponse>()
            .IncludeBase<Transaction, TransactionResponse>();            

        CreateMap<Receive, ReceiveResponse>()
            .IncludeBase<Transaction, TransactionResponse>();

        CreateMap<Transfer, TransferResponse>()
            .IncludeBase<Transaction, TransactionResponse>();
        #endregion
    }
}
