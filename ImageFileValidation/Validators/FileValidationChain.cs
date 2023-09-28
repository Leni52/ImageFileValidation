using FluentValidation.Results;

namespace ImageFileValidation.Validators
{
    public class FileValidationChain
    {
        private readonly List<IFileValidator> validators = new();
        public FileValidationChain()
        {
            validators.Add(new FileSizeValidation(1024 * 1024)); //1024 * 1024 = 1,048,576 bytes = 1MB 
            validators.Add(new FileTypeValidation(new string[] { ".jpg", ".jpeg", ".png" }));

        }

        public async Task<ValidationResult> ValidateAsync(IFormFile file)
        {
            foreach (var validator in validators)
            {
                var validationResult = await validator.ValidateAsync(file);

                if (!validationResult.IsValid)
                {
                    return validationResult;
                }
            }

            return new ValidationResult();
        }
    }
}
