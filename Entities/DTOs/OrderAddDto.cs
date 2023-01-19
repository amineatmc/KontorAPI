using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderAddDto : IDto
    {
       // public int? UserId { get; set; }
        //public int? ProductId { get; set; }
        //public decimal? UnitPrice { get; set; }
        //public string? PaymentType { get; set; }
        //public int? Quantity { get; set; }
        //public decimal Total { get; set; }
        //public string? Description { get; set; }       
        public int InvoiceId { get; set; }
        public int PaymentTypeId { get; set; }
    }
}
