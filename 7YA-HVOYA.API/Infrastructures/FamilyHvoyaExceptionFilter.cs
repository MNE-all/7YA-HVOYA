using _7YA_HVOYA.API.Models.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using _7YA_HVOYA.Services.Contracts.Exceptions;

namespace _7YA_HVOYA.API.Infrastructures
{
    public class FamilyHvoyaExceptionFilter : IExceptionFilter
    {
        /// <inheritdoc/>
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception as FamilyHvoyaException;
            if (exception == null)
            {
                return;
            }

            switch (exception)
            {
                case FamilyHvoyaValidationException ex:
                    SetDataToContext(
                        new ConflictObjectResult(new ApiValidationExceptionDetail
                        {
                            Errors = ex.Errors,
                        }),
                        context);
                    break;

                case FamilyHvoyaInvalidOperationException ex:
                    SetDataToContext(
                        new BadRequestObjectResult(new ApiExceptionDetail { Message = ex.Message, })
                        {
                            StatusCode = StatusCodes.Status406NotAcceptable,
                        },
                        context);
                    break;

                case FamilyHvoyaNotFoundException ex:
                    SetDataToContext(new NotFoundObjectResult(new ApiExceptionDetail
                    {
                        Message = ex.Message,
                    }), context);
                    break;

                default:
                    SetDataToContext(new BadRequestObjectResult(new ApiExceptionDetail
                    {
                        Message = exception.Message,
                    }), context);
                    break;
            }
        }

        /// <summary>
        /// Определяет контекст ответа
        /// </summary>
        static protected void SetDataToContext(ObjectResult data, ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.StatusCode = data.StatusCode ?? StatusCodes.Status400BadRequest;
            context.Result = data;
        }
    }
}
