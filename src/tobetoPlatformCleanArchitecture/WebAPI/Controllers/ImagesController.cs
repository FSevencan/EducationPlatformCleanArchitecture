using Application.Services.ImageService;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : BaseController
{
    private readonly ImageServiceBase _imageService;

    public ImagesController(ImageServiceBase imageService)
    {
        _imageService = imageService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Upload request must contain a file.");
        }

        var imageUrl = await _imageService.UploadAsync(file);
        return Ok(new { imageUrl });
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(string imageUrl)
    {
        await _imageService.DeleteAsync(imageUrl);
        return NoContent();
    }


}
