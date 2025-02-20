namespace JobCode.Infrastructure.CrossCutting.Results
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public string Message { get; private set; }
        public T Results { get; private set; }

        private Result(T results, bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Results = results;
            Message = message;
        }

        public static Result<T?> Success(T? results)
            => new Result<T?>(results, true, string.Empty);

        public static Result<T> Failure(string errorMessage)
            => new Result<T>(default!, false, errorMessage);
    }
}
