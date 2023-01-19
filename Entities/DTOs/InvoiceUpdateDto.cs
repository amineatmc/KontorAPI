using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class InvoiceUpdateDto :IDto
    {
        public int Id { get; set; }
        public bool PaymentStatus { get; set; }
        public DateTime DoDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
