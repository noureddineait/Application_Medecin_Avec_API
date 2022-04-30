using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_pour_medecin.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string DateExp { get; set; }
    }
}
