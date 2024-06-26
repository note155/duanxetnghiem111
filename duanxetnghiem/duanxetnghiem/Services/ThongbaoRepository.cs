﻿using duanxetnghiem.Data;
using Shared.ketnoi;
using Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace duanxetnghiem.Services
{
    public class ThongbaoRepository : IThongbao
    {
        private readonly ApplicationDbContext _context;

        public ThongbaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Thongbao> addAsync(Thongbao tbao)
        {
            if (tbao == null) return null;
            var newtbao = _context.Thongbaos.Add(tbao).Entity;
            await _context.SaveChangesAsync();
            return newtbao;
        }

        public async Task<TBDaDoc> adddaDoc(TBDaDoc tbao)
        {
            if (tbao == null) return null;
            var newtbao = _context.TBDaDocs.Add(tbao).Entity;
            await _context.SaveChangesAsync();
            return newtbao;
        }

        public async Task<List<Thongbao>> getall()
        {
            return await _context.Thongbaos.Where(t => t.iduser == null).ToListAsync();
        }

        public async Task<List<Thongbao>> getbyid(int id)
        {
            return await _context.Thongbaos.Where(t => t.iduser == id || t.iduser == null).ToListAsync();
        }

        public async Task<List<TBDaDoc>> getTBDD(int iduser)
        {
            return await _context.TBDaDocs.Where(t => t.Iduser == iduser).ToListAsync();
        }

        public async Task<int> sltbchuadoc(int iduser)
        {
            var count = await _context.Thongbaos
                            .Where(tb => tb.iduser == null &&
                                         (!_context.TBDaDocs.Any(dd => dd.Iduser == iduser && dd.Idthongbao == tb.Id)))
                            .CountAsync();
            return count;
        }

        public async Task<Thongbao> updateAsync(Thongbao tbao)
        {
            if (tbao == null) return null;

            var existingThongbao = await _context.Thongbaos.FindAsync(tbao.Id);
            if (existingThongbao == null)
            {
                throw new InvalidOperationException("Thongbao not found.");
            }

            _context.Entry(existingThongbao).CurrentValues.SetValues(tbao);
            await _context.SaveChangesAsync();

            return existingThongbao;
        }
    }
}
