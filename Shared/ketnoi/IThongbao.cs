using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;

namespace Shared.ketnoi
{
    public interface IThongbao
    {
        Task<Thongbao> addAsync(Thongbao tbao);
        Task<List<Thongbao>> getall();
        Task<List<Thongbao>> getbyid(int id);
        Task<Thongbao> updateAsync(Thongbao tbao);
    }
}
