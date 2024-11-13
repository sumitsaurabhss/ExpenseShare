using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Dtos
{
    public class ResponseDto
    {
        public String Message { get; set; }

        public ResponseDto()
        {
            Message = String.Empty;
        }

        public ResponseDto(String message)
        {
            Message= message;
        }
    }
}
