using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserCreditAddDto : IDto
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        //public string AgentCode { get; set; }
        public int Credit { get; set; }
    }
}
