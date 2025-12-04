using System;
using Talky.Common.Core.Results;

namespace Talky.Common.Core.Results
{
    public static class Result
    {
        public static Result<T> Success<T>(T value)
        {
            return new SuccessResult<T>(value);
        }

        public static Result<Unit> Success()
        {
            return new SuccessResult<Unit>(Unit.Default);
        }

        public static Result<Unit> Error(Error error)
        {
            return new ErrorResult<Unit>(error);
        }

        public static Result<T> Error<T>(Error error)
        {
            return new ErrorResult<T>(error);
        }

        public static Result<T> Error<T>(string message, ErrorCode? code, Exception? exception = null)
        {
            return new ErrorResult<T>(new Error(message, code, exception));
        }
    }

    public abstract class Result<TValue>
    {
        public static implicit operator Result<TValue>(TValue value)
            => new SuccessResult<TValue>(value);

        public static implicit operator Result<TValue>(Error error)
            => new ErrorResult<TValue>(error);

        public UnwrapResult<TValue> Unwrap()
        {
            if (this is ErrorResult<TValue> error)
            {
                return new UnwrapResult<TValue>(default!, error);
            }

            var success = (SuccessResult<TValue>)this;
            return new UnwrapResult<TValue>(success.Value, default!);
        }
    }

    public class SuccessResult<TValue> : Result<TValue>
    {
        public SuccessResult(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; }
    }

    public class ErrorResult<TValue> : Result<TValue>, IError
    {
        public ErrorResult(Error error)
        {
            Code = error.Code;
            Message = error.Message;
            Exception = error.Exception;
        }

        private ErrorResult()
        {
            Code = ErrorCode.Unknown;
            Message = string.Empty;
        }

        public static ErrorResult<TValue> NonError { get; } = new();

        public ErrorCode Code { get; }

        public string Message { get; }

        public Exception? Exception { get; }

        public IError? InnerError { get; set; }

        public static implicit operator bool(ErrorResult<TValue>? errorResult)
            => errorResult != null && errorResult != NonError;

        public static implicit operator Error(ErrorResult<TValue> errorResult)
            => new(errorResult.Message, errorResult.Code, errorResult.Exception);

        public override string ToString()
        {
            return $"Error: [{Code.Format()}] - {Message}";
        }
    }
}