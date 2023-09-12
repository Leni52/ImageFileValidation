using FluentValidation.Results;

namespace ImageFileValidation.Validators
{
    public class FileTypeValidation : IFileValidator
    {
        private readonly string[] allowedExtensions;
        public FileTypeValidation(string[] allowedExtensions)
        {
            this.allowedExtensions = allowedExtensions;
        }
        public Task<ValidationResult> ValidateAsync(IFormFile file)
        {
            var validationResult = new ValidationResult();
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (string.IsNullOrEmpty(fileExtension) || !allowedExtensions.Contains(fileExtension))
            {
                validationResult.Errors.Add(new ValidationFailure("File", "This file type is not allowed."));

            }

            return Task.FromResult(validationResult);
        }
    }
}
