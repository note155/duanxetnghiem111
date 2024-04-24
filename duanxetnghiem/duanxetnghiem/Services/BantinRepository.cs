using duanxetnghiem.Data;
using duanxetnghiem.Data.Model;
using Microsoft.EntityFrameworkCore;
using Shared.ketnoi;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace duanxetnghiem.Services
{
    public class BantinRepository : IBantin
    {
        private readonly ApplicationDbContext _context;

        public BantinRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Bantin> addAsync(Bantin btin)
        {
            if (btin == null)
                return null;

            var newBantin = _context.Bantins.Add(btin).Entity;
            await _context.SaveChangesAsync();

            return newBantin;
        }

        public async Task<Bantin> deleteAsync(int id)
        {
            var bantinToDelete = await _context.Bantins.FindAsync(id);
            if (bantinToDelete != null)
            {
                _context.Bantins.Remove(bantinToDelete);
                await _context.SaveChangesAsync();
                return bantinToDelete;
            }
            return null;
        }

        public async Task<List<Bantin>> getallAsync()
        {
            return await _context.Bantins.ToListAsync();
        }

        public async Task<Bantin> getbyid(int Id)
        {
            return await _context.Bantins.FindAsync(Id);
        }

        public async Task<Bantin> updateAsync(Bantin btin)
        {
            if (btin == null)
                return null;

            var updatedBantin = _context.Bantins.Update(btin).Entity;
            await _context.SaveChangesAsync();

            return updatedBantin;
        }
    }
}
