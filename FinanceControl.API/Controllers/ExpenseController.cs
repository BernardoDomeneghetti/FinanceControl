// using AutoMapper;
// using FinanceControl.API.ControllerDtos;
// using FinanceControl.Common.Models;
// using FinanceControl.Domain.Interfaces.Workers;
// using FinanceControl.Domain.Models.Business;
// using FinanceControl.Domain.Models.Responses;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

// namespace FinanceControl.API.Controllers
// {
//     [ApiController]
//     [Route("/api/v1/[Controller]")]
//     public class ExpenseController
//     {
//         private readonly IExpenseWorker _expenseWorker;
//         private readonly IMapper _mapper;


//         public ExpenseController(IExpenseWorker expenseWorker, ILogger<ExpenseController> logger, IMapper mapper) : base(logger)
//         {
//             _expenseWorker = expenseWorker;
//             _mapper = mapper;
//         }

//         [HttpGet]
//         public async Task<ActionResult<ExpenseResponse>> GetExpenseById([FromQuery] Guid id)
//         {
//             try
//             {
//                 await _expenseWorker.GetExpenseById(id);
//             }
//             catch (Exception ex){
                
//             }
//         }

//         [HttpGet("List")]
//         public ActionResult<CollectionResponse<Expense>> ListExpenseInDateRange([FromQuery] DateTime since, DateTime until)
//         {
//             var rangefilter = new DateRangeFilter { Since = since, Until = until };

//             return WrappedOkExecute(_expenseWorker.ListExpensesInRange, rangefilter);
//         } 

//         [HttpPost]
//         public ActionResult<ExpenseResponse> CreateExpense(ExpenseDto expenseDto)
//         {
//             var expense = _mapper.Map<Expense>(expenseDto);
//             return WrappedCreateExecute(_expenseWorker.CreateExpense, expense);
//         }

//         [HttpPut]
//         public ActionResult<ExpenseResponse> UpdateExpense(ExpenseDto expenseDto)
//         {
//             var expense = _mapper.Map<Expense>(expenseDto);
//             return WrappedOkExecute(_expenseWorker.UpdateExpense, expense);
//         }

//         [HttpDelete]
//         public ActionResult<ExpenseResponse> DeleteExpense(Guid id)
//         {
//             return WrappedDeletedExecute(_expenseWorker.DeleteExpense, id);
//         }
//     }
// }