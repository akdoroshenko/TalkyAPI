using Talky.Common.Core.Results;

namespace Talky.Common.Core.Results;

public readonly ref struct Error
{
    public Error(IError error)
    {
        Message = error.Message;
        Code = error.Code;
        Exception = error.Exception;
        InnerError = error.InnerError;
    }

    public Error(string message, ErrorCode? code = ErrorCode.Unknown, Exception? exception = null, IError? innerError = null)
    {
        Message = message;
        Code = code!.Value;
        Exception = exception;
        InnerError = innerError;
    }

    public ErrorCode Code { get; }

    public string Message { get; }

    public Exception? Exception { get; }

    public IError? InnerError { get; }
}