using FluentValidation.Results;

namespace ImageFileValidation.Validators
{
    public class FileSizeValidation : IFileValidator
    {
        private readonly int maxSize;
        public FileSizeValidation(int maxSize)
        {
            this.maxSize = maxSize;
        }
        public async Task<ValidationResult> ValidateAsync(IFormFile file)
        {
            var validationResult = new ValidationResult();
            if (file.Length > maxSize)
            {
                validationResult.Errors.Add(new ValidationFailure("File", "File exceeds the allowed file size."));
            }
            return validationResult;
        }
    }
}
