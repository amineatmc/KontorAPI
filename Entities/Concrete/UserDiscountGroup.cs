using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserDiscountGroup : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        //public string AgentCode { get; set; }
       public int DiscountGroupId { get; set; }
    }
}
