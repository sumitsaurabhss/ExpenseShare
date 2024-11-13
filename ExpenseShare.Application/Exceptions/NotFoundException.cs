using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException() : base("Requested information was not found.")
        {

        }
    }
}