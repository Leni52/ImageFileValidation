using ImageFileValidation.Models;
using ImageFileValidation.Validators;
using Microsoft.AspNetCore.Mvc;

namespace ImageFileValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadModel model)
        {
            if (model == null || model.File == null)
                return BadRequest("Invalid file.");

            //validate using COR 
            var validationChain = new FileValidationChain();
            var validationResult = await validationChain.ValidateAsync(model.File);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            return Ok("File uploaded successfully");

        }
    }
}
