using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderCountDto : IDto
    {
        public int UserId { get; set; }
        //public string AgentCode { get; set; }

    }
}
