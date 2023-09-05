namespace Core.Utilities.Results.Concrete;

public class ErrorResult : Result
{
    public ErrorResult(bool success) : base(false)
    {
    }
    public ErrorResult(bool success, string message) : base(false, message)
    {

    }
}
