using System.Net;

namespace Shared.ErrorModels;

public class ValidationErrorToReturn
{
    public int StatusCode { get; set; } =(int) HttpStatusCode.BadRequest;
    public string ErrorMessage { get; set; } = "Validation Failed";
    public IEnumerable<ValidationErrors> ValidationErrors { get; set; } = [];
}
