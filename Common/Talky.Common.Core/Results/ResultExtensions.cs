using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talky.Common.Core.Results;

namespace Talky.Common.Core.Results;

public static class ResultExtensions
{
    public static Error Wrap(this IError error)
    {
        return new Error(error);
    }

    public static Error Wrap(this ICollection<IError> errors)
    {
        return new Error(errors.First());
    }

    public static async Task<UnwrapResult<TValue>> Unwrap<TValue>(this Task<Result<TValue>> task)
    {
        try
        {
            var result = await task;
            return result.Unwrap();
        }
        catch (Exception e)
        {
#if DEBUG
            throw;
#endif

#pragma warning disable CS0162
            return new UnwrapResult<TValue>(
                default,
                new ErrorResult<TValue>(new Error("UNKNOWN_ERROR", e.Message, e)));
#pragma warning restore CS0162
        }
    }

    public static async Task<ErrorResult<Unit>> Unwrap(this Task<Result<Unit>> task)
    {
        try
        {
            var (result, error) = await task.Unwrap<Unit>();
            if (error)
            {
                return error;
            }

            return ErrorResult<Unit>.NonError;
        }
        catch (Exception e)
        {
#if DEBUG
            throw;
#endif

#pragma warning disable CS0162

            // ReSharper disable once HeuristicUnreachableCode
            return new ErrorResult<Unit>(new Error("UNKNOWN_ERROR", e.Message, e));
#pragma warning restore CS0162
        }
    }

    public static async ValueTask<UnwrapResult<TValue>> Unwrap<TValue>(this ValueTask<Result<TValue>> task)
    {
        try
        {
            var result = await task;
            return result.Unwrap();
        }
        catch (Exception e)
        {
#if DEBUG
            throw;
#endif

#pragma warning disable CS0162
            return new UnwrapResult<TValue>(
                default,
                new ErrorResult<TValue>(new Error("UNKNOWN_ERROR", e.Message, e)));
#pragma warning restore CS0162
        }
    }

    public static async ValueTask<ErrorResult<Unit>> Unwrap(this ValueTask<Result<Unit>> task)
    {
        try
        {
            var (result, error) = await task.Unwrap<Unit>();
            if (error)
            {
                return error;
            }

            return null!;
        }
        catch (Exception e)
        {
#if DEBUG
            throw;
#endif

#pragma warning disable CS0162

            // ReSharper disable once HeuristicUnreachableCode
            return new ErrorResult<Unit>(new Error("UNKNOWN_ERROR", e.Message, e));
#pragma warning restore CS0162
        }
    }

    public static Result<TResult> Select<TValue, TResult>(this Result<TValue> result, Func<TValue, TResult> selector)
    {
        var (value, error) = result.Unwrap();
        if (error)
        {
            return error.Wrap();
        }

        return selector(value!);
    }

    public static async Task<Result<TResult>> Select<TValue, TResult>(
        this Task<Result<TValue>> result,
        Func<TValue, TResult> selector)
    {
        var (value, error) = await result.Unwrap();
        if (error)
        {
            return error.Wrap();
        }

        return selector(value!);
    }
}