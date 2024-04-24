using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace duanxetnghiem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public ImagesController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("img/{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            // Đường dẫn đến thư mục chứa ảnh
            var imagePath = Path.Combine(_env.ContentRootPath, "wwwroot", "img", imageName);

            if (!System.IO.File.Exists(imagePath))
            {
                // Trả về 404 nếu không tìm thấy ảnh
                return NotFound();
            }

            // Đọc tệp ảnh và trả về dưới dạng FileStreamResult
            var imageFileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            return File(imageFileStream, "image/jpeg");
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty");
            }

            try
            {
                // Tạo đường dẫn lưu trữ hình ảnh trong thư mục wwwroot/img với tên duy nhất
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var imagePath = Path.Combine(_env.WebRootPath, "img", uniqueFileName);

                // Lưu hình ảnh vào đường dẫn mới
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Trả về đường dẫn của hình ảnh mới được tạo
                var imageUrl = Url.Content("/api/Images/img/" + uniqueFileName);
                return Ok(imageUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    }

}
