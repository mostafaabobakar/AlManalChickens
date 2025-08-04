using AlManalChickens.Domain.Common.Helpers.Localization;
using AlManalChickens.Domain.Constants;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Text.Json.Serialization;

namespace AlManalChickens.Services.DTO
{

    #region Generic Result
    public class Result<T>
    {
        [JsonIgnore]
        public bool IsSuccess { get; set; }

        [JsonIgnore]
        public string PropertyName { get; set; }

        public int StatusCode { get; }
        public string Key { get; set; }
        public string? Message { get; }
        public T? Data { get; set; }

        private Result(bool isSuccess, int statusCode, string key, string? message, T? data)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Key = key;
            Message = message;
            Data = data;
        }

        public static Result<T> Success(T data, string? successMessageKey = null)
        {
            return CreateResult(true, StatusCodes.Status200OK, ResponseKey.Success, data, successMessageKey);
        }

        public static Result<T> Fail(string errorMessageKey, int statusCode = StatusCodes.Status400BadRequest, string key = ResponseKey.Failure)
        {
            return CreateResult(false, statusCode, key, default, errorMessageKey);
        }

        public static Result<T> ValidationErrors(string errorMessage, int statusCode = StatusCodes.Status400BadRequest, string key = ResponseKey.InvalidParameters)
        {
            return new Result<T>(false, statusCode, key, errorMessage, default);
        }


        private static Result<T> CreateResult(bool isSuccess, int statusCode, string key, T? data, string? messageKey)
        {
            var lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            //var propName =  FluentValidationHelper.GetDisplayName(,);
            var localizedMessage = string.IsNullOrEmpty(messageKey) ? null : LocalizerHelper.LocalizeMessage(messageKey, lang, DefaultPath.GeneralLocalizationPath);
            return new Result<T>(isSuccess, statusCode, key, localizedMessage, data);
        }
    }



    #endregion

}
