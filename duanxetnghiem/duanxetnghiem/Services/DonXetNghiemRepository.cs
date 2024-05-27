using System.Net.Mail;
using System.Net;
using duanxetnghiem.Client.Pages.Admin.GoiXetNghiem;
using duanxetnghiem.Data;
using duanxetnghiem.Data.Model;
using Microsoft.EntityFrameworkCore;
using Shared.form;
using Shared.ketnoi;
using Shared.Model;

namespace duanxetnghiem.Services
{
    public class DonXetNghiemRepository : IDonXetNghiem
    {
        private readonly ApplicationDbContext _context;

        public DonXetNghiemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DonXetNghiem> addAsync(DonXetNghiem donXetNghiem)
        {
            if (donXetNghiem == null) return null;
            var newstudent = _context.DonXetNghiems.Add(donXetNghiem).Entity;
            await _context.SaveChangesAsync();

            return newstudent;
        }

        public async Task<DXNandGXN> addnew(DXNandGXN a)
        {
            if (a == null) return null;
            var newstudent = _context.DXNandGXNs.Add(a).Entity;
            await _context.SaveChangesAsync();

            return newstudent;
        }
        public async Task<gmail> guiemailxacnhan(gmail gm)
        {
            string fromMail = "dolaamphu111@gmail.com";
            string fromPassword = "rxzyfffqavivksfs";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Thông báo đặt lịch xét nghiệm thành công";
            message.To.Add(new MailAddress(gm.email));
            message.Body = $@"
        <html>
        <body>
            <p>Kính gửi {gm.hoten},</p> 
            <p>Đơn xét nghiệm của bạn đã được xét duyệt thành công.</p>
            <p>{gm.ketqua}</p>
            <p>Bạn có thể xem chi tiết bằng cách nhấp vào đường link sau: <a href='https://localhost:7199/XCTDon/{gm.iddon}'>Link Đơn xét nghiệm</a>.</p>
            <p>Kết quả sẽ được gửi đến bạn trong thời gian sớm nhất khi đã hoàn tất quá trình xét nghiệm.</p>
            <p>Nếu bạn có bất kỳ câu hỏi hoặc cần thêm thông tin, đừng ngần ngại liên hệ với chúng tôi. Đội ngũ chăm sóc khách hàng của chúng tôi luôn sẵn sàng hỗ trợ bạn.</p>
            <p>Cảm ơn bạn đã tin tưởng và sử dụng dịch vụ của chúng tôi.</p>
            <p>Trân trọng,</p>
            <p>CÔNG TY TNHH GIẢI PHÁP PHẦN MỀM ÂU LẠC</p>
        </body>
        </html>";
            message.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
            return gm;
        }
        public async Task<DonXetNghiem> deleteAsync(int id)
        {
            var donXetNghiemToDelete = await _context.DonXetNghiems.FindAsync(id);
            if (donXetNghiemToDelete != null)
            {
                _context.DonXetNghiems.Remove(donXetNghiemToDelete);
                await _context.SaveChangesAsync();
                return donXetNghiemToDelete;
            }
            return null;
        }

        public async Task<DXNandGXN> deletegxnAsync(int id)
        {
            var donXetNghiemToDelete = await _context.DXNandGXNs.FindAsync(id);
            if (donXetNghiemToDelete != null)
            {
                _context.DXNandGXNs.Remove(donXetNghiemToDelete);
                await _context.SaveChangesAsync();
                return donXetNghiemToDelete;
            }
            return null;
        }

        public async Task<List<DonXetNghiem>> getallAsync()
        {
            return await _context.DonXetNghiems.ToListAsync();
        }

        public async Task<List<DonXetNghiem>> getallbyiduserAsync(int id)
        {
            var gioHangs = await _context.DonXetNghiems.Where(g => g.UserId == id).ToListAsync();
            return gioHangs;
        }

        public async Task<List<DXNandGXN>> getallGXNAsync(int idDXN)
        {
            var gioHangs = await _context.DXNandGXNs.Where(g => g.DonXetNghiemId == idDXN).ToListAsync();
            return gioHangs;
        }

        public async Task<DonXetNghiem> getbyid(int Id)
        {
            return await _context.DonXetNghiems.FindAsync(Id);
        }

        public async Task<List<DXNandGXN>> getmaubyidbs(int idbs) 
        {
            // Sử dụng LINQ để truy vấn danh sách DXNandGXN dựa trên BacSiId
            var dxnandgxnList = await _context.DXNandGXNs
                                .Include(dxn => dxn.DonXetNghiem) // Đảm bảo rằng đối tượng DonXetNghiem được kết nối
                                .Where(dxn => dxn.DonXetNghiem.BacSiId == idbs && dxn.DonXetNghiem.Trangthai != "Chờ lấy mẫu") // Lọc theo BacSiId và Trangthai
                                .ToListAsync();

            return dxnandgxnList;
        }


        public async Task<DXNandGXN> getOngNghiem(int Id)
        {
            return await _context.DXNandGXNs.FindAsync(Id);
        }

        public async Task<List<DonXetNghiem>> ListDXNBS(int id)
        {
            var gioHangs = await _context.DonXetNghiems.Where(g => g.BacSiId == id && g.Trangthai== "Chờ lấy mẫu").ToListAsync();
            return gioHangs;
        }

        public async Task<List<DonXetNghiem>> ListDXNBSHoanThanh(int id)
        {
            var gioHangs = await _context.DonXetNghiems.Where(g => g.BacSiId == id && g.Trangthai != "Chờ lấy mẫu").ToListAsync();
            return gioHangs;
        }

        public async Task<DXNandGXN> SuaOngNghiem(DXNandGXN a)
        {
            if (a == null) return null;

            var updateuser = _context.DXNandGXNs.Update(a).Entity;

            await _context.SaveChangesAsync();

            return a;
        }

        public async Task<DonXetNghiem> updateAsync(DonXetNghiem donXetNghiem)
        {
            if (donXetNghiem == null) return null;

            var updateuser = _context.DonXetNghiems.Update(donXetNghiem).Entity;

            await _context.SaveChangesAsync();

            return updateuser;
        }
    }
}
