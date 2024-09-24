namespace ContactManagerClassLibrary.Domain.Models
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }

        public Result(bool isSuccess, string? error = null)
        {
            IsSuccess = isSuccess;
            error ??= string.Empty;
            Error = error;
        }
    }
}
