using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;

namespace Shared.ketnoi
{
    public interface IBantin
    {
        Task<List<Bantin>> getallAsync();
        Task<Bantin> addAsync(Bantin btin);
        Task<Bantin> updateAsync(Bantin btin);
        Task<Bantin> deleteAsync(int id);
        Task<Bantin> getbyid(int Id);
    }
}
