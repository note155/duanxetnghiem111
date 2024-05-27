using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using duanxetnghiem.Data.Model;
using Shared.form;
using Shared.Model;

namespace Shared.ketnoi
{
    public interface IDonXetNghiem
    {
        Task<DonXetNghiem> addAsync(DonXetNghiem DonXetNghiem);
        Task<DonXetNghiem> updateAsync(DonXetNghiem DonXetNghiem);
        Task<DonXetNghiem> deleteAsync(int id);
        Task<List<DonXetNghiem>> getallAsync();
        Task<List<DonXetNghiem>> ListDXNBS(int id);
        Task<List<DonXetNghiem>> ListDXNBSHoanThanh(int id);
        Task<List<DonXetNghiem>> getallbyiduserAsync(int id);
        Task<DonXetNghiem> getbyid(int Id);
        Task<DXNandGXN> addnew(DXNandGXN a);
        Task<List<DXNandGXN>> getallGXNAsync(int idDXN);
        Task<List<DXNandGXN>> getmaubyidbs(int idbs);
        Task<DXNandGXN> getOngNghiem(int Id);
        Task<DXNandGXN> SuaOngNghiem(DXNandGXN a);
        Task<DXNandGXN> deletegxnAsync(int id);
        Task<gmail> guiemailxacnhan(gmail gm);
    }
}
