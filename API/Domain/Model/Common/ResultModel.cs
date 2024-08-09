namespace API.Domain.Model.Common
{
    public class ResultModel
    {
        public ResultModel(string message = "", bool isSuccess = true)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }

        public static ResultModel Success() => new();

        public static ResultModel Error(string message) => new(message, false);
    }
}
