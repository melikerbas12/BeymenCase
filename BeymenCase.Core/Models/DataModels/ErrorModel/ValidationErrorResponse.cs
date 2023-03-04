namespace BeymenCase.Core.Models.DataModels.ErrorModel
{
    public class ValidationErrorResponse
    {
        public List<ValidationErrorModel> Errors { get; set; } = new List<ValidationErrorModel>();
    }
}