using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BalanceDto :IDto
    {
       // public int Id { get; set; }
        public string DeclareUserName { get; set; }
        public string ReceiveUserName { get; set; }
        public int PaymentTypeId { get; set; }
        public PaginationDto? Pagination { get; set; }

    }
}
