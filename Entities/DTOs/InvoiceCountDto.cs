using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class InvoiceCountDto :IDto
    {
        //public int Id { get; set; }
        //public string AgentCode { get; set; }
        public int UserId { get; set; }
    }
}
