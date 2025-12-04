namespace Talky.Common.Core.Results;

public enum ErrorCode
{
    Unknown = 0,
    NotFound = 1,
    NotUnique = 2
}

public static class ErrorCodeExtensions
{
    public static string Format(this ErrorCode errorCode) => errorCode switch
    {
        ErrorCode.Unknown => "Unknown error",
        ErrorCode.NotFound => "Not found",
        ErrorCode.NotUnique => "Not unique",
        _ => "Unknown error"
    };
}