

using FluentValidation.Results;

namespace FlintSoft.Result.FluentValidation;

public static class Extensions
{
    public static Error? FromValidationResult(this ValidationResult validationResult, string code = "") {
        Error? ret = null;
        
        foreach(var e in validationResult.Errors) {
            if(ret is null) {
                ret = new Error(code, validationResult.Errors[0].ErrorMessage);
                continue;
            }

            ret.InnerError = new Error(code, validationResult.Errors[0].ErrorMessage);
        }

        return ret;
    }
}
