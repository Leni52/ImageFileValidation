using FluentValidation.Results;

namespace ImageFileValidation
{
    public interface IFileValidator
    {
        Task<ValidationResult> ValidateAsync(IFormFile file);
    }
}
