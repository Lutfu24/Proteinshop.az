using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete;

public class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult(bool success) : base(default, false)
    {
    }
    public ErrorDataResult(T data, bool success) : base(data, false)
    {
    }
    public ErrorDataResult(string message) : base(default, false, message)
    {
    }
    public ErrorDataResult(T data, string message) : base(data, false, message)
    {
    }
}
