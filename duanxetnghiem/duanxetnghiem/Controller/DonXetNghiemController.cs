using duanxetnghiem.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.form;
using Shared.ketnoi;
using Shared.Model;

namespace duanxetnghiem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonXetNghiemController : ControllerBase
    {
        private readonly IDonXetNghiem _DXNRepository;
        public DonXetNghiemController(IDonXetNghiem DXNRepository)
        {
            this._DXNRepository = DXNRepository;
        }
        [HttpGet("All-DXN")]
        public async Task<ActionResult<List<DonXetNghiem>>> GetAllStudentsAsync()
        {
            var users = await _DXNRepository.getallAsync();
            return Ok(users);
        }

        [HttpGet("All-DXNbyiduser/{id}")]
        public async Task<ActionResult<List<DonXetNghiem>>> GetAllbyiduserAsync(int id)
        {
            var users = await _DXNRepository.getallbyiduserAsync(id);
            return Ok(users);
        }
        [HttpPost("gui-XNemail")]
        public async Task<IActionResult> guiXNEmail([FromBody] gmail gm)
        {
            var newStudent = await _DXNRepository.guiemailxacnhan(gm);
            return Ok(newStudent);
        }
        [HttpGet("All-DXNbyidbs/{id}")]
        public async Task<ActionResult<List<DonXetNghiem>>> GetAllbyidbsAsync(int id)
        {
            var users = await _DXNRepository.ListDXNBS(id);
            return Ok(users);
        }

        [HttpGet("All-DXNbyidbsHoanthanh/{id}")]
        public async Task<ActionResult<List<DonXetNghiem>>> GetAllbyidbshoanthanhAsync(int id)
        {
            var users = await _DXNRepository.ListDXNBSHoanThanh(id);
            return Ok(users);
        }

        [HttpGet("All-DXNandGXN/{idDXN}")]
        public async Task<ActionResult<List<DXNandGXN>>> GetAllDXNAsync(int idDXN)
        {
            var users = await _DXNRepository.getallGXNAsync(idDXN);
            return Ok(users);
        }

        [HttpGet("All-getmaubybs/{idbs}")]
        public async Task<ActionResult<List<DXNandGXN>>> GetAllmauAsync(int idbs)
        {
            var users = await _DXNRepository.getmaubyidbs(idbs);
            return Ok(users);
        }

        [HttpGet("Single-DXN/{id}")]
        public async Task<ActionResult<DonXetNghiem>> GetSingleStudentAsync(int id)
        {
            var student = await _DXNRepository.getbyid(id);

            return Ok(student);
        }

        [HttpGet("Single-OngNghiem/{id}")]
        public async Task<ActionResult<DXNandGXN>> GetSingleongnghiemAsync(int id)
        {
            var student = await _DXNRepository.getOngNghiem(id);

            return Ok(student);
        }

        [HttpPost("Add-DXN")]
        public async Task<ActionResult<DonXetNghiem>> AddNewStudentAsync(DonXetNghiem user)
        {
            var newstudent = await _DXNRepository.addAsync(user);

            return Ok(newstudent);
        }


        [HttpDelete("Delete-DXN/{id}")]
        public async Task<ActionResult<DonXetNghiem>> DeleteStudentAsync(int id)
        {
            var deletestudent = await _DXNRepository.deleteAsync(id);

            return Ok(deletestudent);
        }

        [HttpDelete("Delete-DXNGXN/{id}")]
        public async Task<ActionResult<DXNandGXN>> DeleteDXNGXNAsync(int id)
        {
            var deletestudent = await _DXNRepository.deletegxnAsync(id);
            if(deletestudent!=null) return Ok(deletestudent);
            else return BadRequest();
        }

        [HttpPost("Update-DXN")]
        public async Task<ActionResult<DonXetNghiem>> UpdateStudentAsync(DonXetNghiem user)
        {
            var updatestudent = await _DXNRepository.updateAsync(user);
            return Ok(updatestudent);
        }

        [HttpPost("Update-OngNghiem")]
        public async Task<ActionResult<DXNandGXN>> UpdateongnghiemAsync(DXNandGXN user)
        {
            var updatestudent = await _DXNRepository.SuaOngNghiem(user);
            return Ok(updatestudent);
        }

        [HttpPost("Add-DXNandGXN")]
        public async Task<ActionResult<DonXetNghiem>> addnew(DXNandGXN user)
        {
            var updatestudent = await _DXNRepository.addnew(user);
            return Ok(updatestudent);
        }
    }

}
