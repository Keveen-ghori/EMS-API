using EMS.Core.Constants;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using System.Runtime.Serialization.Json;

namespace EMS.API.Api.Models.ApiModels
{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public List<ApiMessage> Messages { get; set; } = new List<ApiMessage>();
        public bool Success { get; set; }
        public T Content { get; set; }
    }

    public class ApiMessage
    {
        public static class MessageTypes
        {
            public const string INFORMATION = "Information";
            public const string VALIDATION_ERROR = "Validation";
            public const string EXCEPTION = "Exception";
        }

        public string MessageType { get; set; }
        public string Message { get; set; }
    }

    public static class ApiMessageExtensions
    {
        public static ApiResponse<T> HandleException<T>(this ApiModels.ApiResponse<T> apiResponse, string exceptionMessage)
        {
            apiResponse.Success = false;
            apiResponse.StatusCode = HttpStatusCode.InternalServerError;
            apiResponse.Messages.Add(new ApiMessage()
            {
                MessageType = ApiModels.ApiMessage.MessageTypes.EXCEPTION,
                Message = exceptionMessage,
            });

            return apiResponse;
        }

        public static ApiResponse<T> HandleResponse<T>(this ApiModels.ApiResponse<T> apiResponse, T responseContent)
        {
            var statusCode = (int)apiResponse.StatusCode;
            apiResponse.Success = statusCode <= 400; // if we aren't a 400s or 500s status code consider successful 
            apiResponse.StatusCode = apiResponse.StatusCode;
            apiResponse.Content = responseContent;
            return apiResponse;
        }

        public static ApiResponse<T> HandleModelStateFailure<T>(this ApiResponse<T> apiResponse, ModelStateDictionary modelState)
        {
            var validationErrors = new List<ApiMessage>();

            foreach (var key in modelState.Keys)
            {
                var errors = modelState[key].Errors.Select(e => e.ErrorMessage);
                validationErrors.AddRange((IEnumerable<ApiMessage>)errors);
            }

            apiResponse.StatusCode = HttpStatusCode.BadRequest;
            apiResponse.Success = false;
            apiResponse.Messages = validationErrors;

            return apiResponse;
        }
    }
}
