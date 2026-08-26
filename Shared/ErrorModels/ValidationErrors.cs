namespace Shared.ErrorModels;
public class ValidationErrors
{
    public string Field { get; set; } = default!;
    public IEnumerable<string> Errors { get; set; } = [];
}
