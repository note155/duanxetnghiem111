using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ketnoi;
using Shared.Model;

namespace duanxetnghiem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BantinController : ControllerBase
    {
        private readonly IBantin _BantinRepository;
        public BantinController(IBantin BantinRepository)
        {
            this._BantinRepository = BantinRepository;
        }
        [HttpGet("All-News")]
        public async Task<ActionResult<List<Bantin>>> GetAllNewsAsync()
        {
            var news = await _BantinRepository.getallAsync();
            return Ok(news);
        }

        [HttpGet("Single-News/{id}")]
        public async Task<ActionResult<Bantin>> GetSingleNewsAsync(int id)
        {
            var newsItem = await _BantinRepository.getbyid(id);
            if (newsItem == null)
            {
                return NotFound();
            }
            return Ok(newsItem);
        }

        [HttpPost("Add-News")]
        public async Task<ActionResult<Bantin>> AddNewNewsAsync(Bantin newsItem)
        {
            var newNewsItem = await _BantinRepository.addAsync(newsItem);
            return Ok(newNewsItem);
        }

        [HttpDelete("Delete-News/{id}")]
        public async Task<ActionResult<Bantin>> DeleteNewsAsync(int id)
        {
            var deletedNewsItem = await _BantinRepository.deleteAsync(id);
            if (deletedNewsItem == null)
            {
                return NotFound();
            }
            return Ok(deletedNewsItem);
        }

        [HttpPost("Update-News")]
        public async Task<ActionResult<Bantin>> UpdateNewsAsync(Bantin newsItem)
        {
            var updatedNewsItem = await _BantinRepository.updateAsync(newsItem);
            return Ok(updatedNewsItem);
        }
    }
}
