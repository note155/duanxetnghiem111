using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class Bantin
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title không được để trống")]
        public string title { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn ảnh")]
        public string img { get; set; }
        public DateTime ngayviet { get; set; }
        public string noidung { get; set; }
    }
}
