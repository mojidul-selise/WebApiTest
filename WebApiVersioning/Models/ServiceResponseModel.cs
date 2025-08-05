namespace WebApiVersioning.Models
{
    public class ServiceResponseModel
    {
        public bool IsSuccess { get; set; }
        public string?  Message { get; private set; }
        public dynamic? Data { get; private set; }

        public void SuccessResponse(string? message, dynamic? data) {
            this.IsSuccess = true;
            this.Message = message;
            this.Data = data;
        }
    }
}
