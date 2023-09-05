using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete;

public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult(bool success) : base(default, true)
    {
    }
    public SuccessDataResult(T data, bool success):base(data,true)
    {
    }
    public SuccessDataResult(string message):base(default,true,message)
    {
    }
    public SuccessDataResult(T data, string message) : base(data, true, message)
    {
    }
}
