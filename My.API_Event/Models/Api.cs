using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.API_Event.Models
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class ApiError
    {
        public Error Error { get; set; }
    }
}
