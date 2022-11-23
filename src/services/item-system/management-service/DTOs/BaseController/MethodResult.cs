namespace ManagementService.DTOs.BaseController
{
    public class MethodResult
    {
        public MethodResult(bool isSuccessful, string successMessage = null, string error = null)
        {
            this.IsSuccessful = isSuccessful;
            this.SuccessMessage = successMessage;
            this.Error = error;
        }

        public bool IsSuccessful { get; init; }

        public string SuccessMessage { get; set; }

        public string Error { get; set; }
    }
}
