﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using duanxetnghiem.Data.Model;

namespace Shared.Model
{
    public class TBDaDoc
    {
       [Key]
       public int Id { get; set; }
       public int Iduser { get; set; }
       public int Idthongbao { get; set; }
    }
}
