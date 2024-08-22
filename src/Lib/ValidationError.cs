
using FluentValidation.Results;

namespace FlintSoft.Result.FluentValidation;

public class ValidationError : IError
{
    public string Code { get; set; } = "";

    public string Description { get; set; } = "";

    public ValidationError(ValidationResult validationResult, string code = "")
    {
        if(validationResult.Errors.Any()) {
            Code = code;
            Description = validationResult.Errors.Select(x => x.ToString()).Aggregate((c, n) => $"{c}; {n}");
        }
    }
}
