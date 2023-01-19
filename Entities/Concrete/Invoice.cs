using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Invoice : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
       // public string AgentCode { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
       // public int PaymentTypeId { get; set; }
        public string Description { get; set; }
        public bool PaymentStatus { get; set; }
        public bool AppStatus { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime DoDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } =DateTime.Now;
    }
}
