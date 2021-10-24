using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class CreateSessionPostRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
