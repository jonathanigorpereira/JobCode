namespace JobCode.Application.Result;

public class Result<T>
{
    private Result(T results, bool isSuccess = true, string message = "")
    {
        IsSuccess = isSuccess;
        Results = results;
        Message = message;
    }

    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;
    public string Message { get; private set; }
    public T Results { get; private set; }

    public static Result<T?> Success(T? results)
        => new Result<T?>(results, true, string.Empty);

    public static Result<T> Failure(string errorMessage)
        => new Result<T>(default!, false, errorMessage);
}
