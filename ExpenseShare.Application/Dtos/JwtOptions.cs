using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Dtos
{
    public class JwtOptions
    {
        public string Issuer { get; set; } // = string.Empty;

        public Int16 DurationInMinutes { get; set; } // = 0;

        public string Secret { get; set; } // = string.Empty;
    }
}
