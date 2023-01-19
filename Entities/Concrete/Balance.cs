using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Balance : IEntity
    {
        
        public int Id { get; set; }
        public string DeclareUserName { get; set; }
        public string ReceiveUserName { get; set; }
        public int PaymentTypeId { get; set; }
        public int Count { get; set; }      
        public DateTime CreateDate { get; set; } = DateTime.Now;

 
    }
}
