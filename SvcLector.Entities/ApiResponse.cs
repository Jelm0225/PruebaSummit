using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvcLector.Entities
{
    public class ApiResponse
    {
        public int MessageCode { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
    }
}
