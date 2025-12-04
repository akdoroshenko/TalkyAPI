namespace Talky.Common.Core.Results;

public class UnwrapResult<TValue>(TValue value, ErrorResult<TValue> error)
{
    public TValue Value { get; } = value;

    public ErrorResult<TValue> Error { get; } = error;

    public void Deconstruct(out TValue value, out ErrorResult<TValue> error)
    {
        value = Value;
        error = Error;
    }
}