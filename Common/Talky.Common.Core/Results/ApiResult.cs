using Talky.Common.Core.Results;

namespace Talky.Common.Core.Results
{
    public interface IApiErrorResult
    {
        bool Success { get; }

        ApiError[]? Errors { get; }
    }

    public class ApiResult<TValue> : IApiErrorResult
    {
        public ApiResult()
        {
        }

        public ApiResult(TValue? value = default, IError[]? errors = default)
        {
            Value = value;
            Errors = errors?
                .Select(o => new ApiError { Code = o.Code, Message = o.Message })
                .ToArray();

            Success = Errors == null;
        }

        public bool Success { get; }

        public TValue? Value { get; }

        public ApiError[]? Errors { get; }

        public static implicit operator ApiResult<TValue>(Result<TValue> result)
        {
            var (value, error) = result.Unwrap();
            if (error)
            {
                return new ApiResult<TValue>(default, new IError[] { error });
            }

            return new ApiResult<TValue>(value);
        }

        public static implicit operator ApiResult<TValue>(TValue value)
        {
            return new ApiResult<TValue>(value);
        }

        public static implicit operator ApiResult<TValue>(Error error)
        {
            return new ApiResult<TValue>(default, new IError[] { new ErrorResult<TValue>(error) });
        }
    }

    public class ApiError
    {
        public ErrorCode Code { get; set; }

        public string Message { get; set; }
    }
}