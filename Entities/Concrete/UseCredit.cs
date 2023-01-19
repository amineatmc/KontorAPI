using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UseCredit : IEntity
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string SerialNo { get; set; }
        public string Date { get; set; }
        public string AgentCode { get; set; }
        public string Token { get; set; }
    }
}
