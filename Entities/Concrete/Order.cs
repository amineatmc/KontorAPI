using Core.Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order :IEntity
    {
        public int OrderId { get; set; }
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
      //  public string AgentCode { get; set; }
        public int ProductId { get; set; }
        public int PaymentTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
