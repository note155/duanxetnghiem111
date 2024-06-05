using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.form
{
    public class CheckCardResponse
    {
        public string statusCode { get; set; }
        public string message { get; set; }
        public string data { get; set; }
        public string success { get; set; }
        public object quantity { get; set; }
        public object doctor { get; set; }
    }

}
