using FluentValidation;

namespace ImageFileValidation.Models
{
    public class FileUploadModel
    {
        public IFormFile File { get; set; }

    }
    public class FileUploadModelValidator : AbstractValidator<FileUploadModel>
    {
        public FileUploadModelValidator()
        {
            RuleFor(x => x.File)
                .NotNull()
                .WithMessage("File is required.");
        }
    }


}
