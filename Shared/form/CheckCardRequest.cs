using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.form
{
    public class CheckCardRequest
    {
        public string fullname { get; set; }
        public DateTime birthday { get; set; }
        public string insuranceNumber { get; set; }
    }
}
