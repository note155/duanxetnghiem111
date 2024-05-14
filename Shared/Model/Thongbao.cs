using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class Thongbao
    {
        [Key]
        public int Id { get; set; }
        public string noidung { get; set; }
        public string? link { get; set; }
        public int? iduser { get; set; } 
        public int trangthai { get; set; } 
        public DateTime ngaytao { get; set; }
    }
}
