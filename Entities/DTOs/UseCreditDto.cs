using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UseCreditDto :IDto
    {
        public string Plate { get; set; }
        public string SerialNo { get; set; }
        public string AgentCode { get; set; }      
        public PaginationDto? Pagination { get; set; }

    }
}
