using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DiscountGroup: IEntity
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public decimal Discount { get; set; }
    }
}
