using System;
using System.Collections.Generic;

namespace Talky.Common.Core.Results
{
    public interface IError
    {
        ErrorCode Code { get; }

        string Message { get; }

        Exception? Exception { get; }

        IError? InnerError { get; set; }
    }
    
    public interface IErrorContainer
    {
        IError Error { get; }
    }

    public interface IApiException
    {
        public int StatusCode { get; }

        public string Response { get; }

        public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; }
    }
}