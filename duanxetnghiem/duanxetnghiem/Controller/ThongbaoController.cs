using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ketnoi;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace duanxetnghiem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongbaoController : ControllerBase
    {
        private readonly IThongbao _thongbaoRepository;

        public ThongbaoController(IThongbao thongbaoRepository)
        {
            _thongbaoRepository = thongbaoRepository;
        }

        [HttpPost("Add_Thongbao")]
        public async Task<IActionResult> Create(Thongbao thongbao)
        {
            try
            {
                var newThongbao = await _thongbaoRepository.addAsync(thongbao);
                return Ok(newThongbao);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("All_TB")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var thongbaos = await _thongbaoRepository.getall();
                return Ok(thongbaos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("Getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var thongbaos = await _thongbaoRepository.getbyid(id);
                return Ok(thongbaos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("Update-Thongbao")]
        public async Task<IActionResult> Update(Thongbao thongbao)
        {
            try
            {
                var updatedThongbao = await _thongbaoRepository.updateAsync(thongbao);
                return Ok(updatedThongbao);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
