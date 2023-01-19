using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderDetailDto : IDto
    {
        public int? OrderId { get; set; }
        public int? UserId { get; set; }
        //public string? AgentCode { get; set; }
        public int? ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? PaymentType { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }
        public string? Description { get; set; }
       // public DateTime? OrderDate { get; set; }
        public int? InvoiceId { get; set; }
        public PaginationDto? Pagination { get; set; }
    }
}
