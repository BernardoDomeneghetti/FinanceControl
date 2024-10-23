using FinanceControl.Domain.Models.DTOs;
using FinanceControl.Domain.Models.DTOs.BaseDtos;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControl.API.Controllers;

public class BaseCustomController : ControllerBase
{
    private readonly Dictionary<ResponseHttpCode, Func<object, ActionResult>> _payloadResponseHandlers;
    private readonly Dictionary<ResponseHttpCode, Func< ActionResult>> _emptyResponseHandlers;
    private const string NotHandledResponseHttpCode = "Response code not handled";

    public BaseCustomController()
    {
        _payloadResponseHandlers = new(){
            {ResponseHttpCode.Ok, Ok},
            //{ResponseHttpCode.Created, Created},
            //{ResponseHttpCode.NoContent, NoContent},
            {ResponseHttpCode.BadRequest, BadRequest},
            {ResponseHttpCode.Unauthorized, Unauthorized},
            //{ResponseHttpCode.Forbidden, Forbidden},
            {ResponseHttpCode.NotFound, NotFound},
            //{ResponseHttpCode.InternalServerError, Problem}
        };

        _emptyResponseHandlers = new(){
            {ResponseHttpCode.Ok, Ok},
            {ResponseHttpCode.Created, Created},
            {ResponseHttpCode.NoContent, NoContent},
            {ResponseHttpCode.BadRequest, BadRequest},
            {ResponseHttpCode.Unauthorized, Unauthorized},
            //{ResponseHttpCode.Forbidden, Forbidden},
            {ResponseHttpCode.NotFound, NotFound},
            //{ResponseHttpCode.InternalServerError, Problem}
        };
    }

    

    protected ActionResult HandleResponse<TResponse>(Response<TResponse> response)
    {
        if (response.Payload is null)
        {
            if( _emptyResponseHandlers.TryGetValue(response.Code, out var noArgumentFunc) ) 
            {
                return noArgumentFunc.Invoke();
            } 
        }
        
        if( _payloadResponseHandlers.TryGetValue(response.Code, out var func) ) 
        {
            return func.Invoke(response.Payload);
        }

        throw new ArgumentException(NotHandledResponseHttpCode);
    }
}
