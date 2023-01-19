using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class InvoiceDetailDto : IDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public bool PaymentStatus { get; set; }
        public int UserId { get; set; }
       //public string AgentCode { get; set; }
        public PaginationDto? Pagination { get; set; }



    }
}
