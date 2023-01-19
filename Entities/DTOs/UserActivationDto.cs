using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserActivationDto : IDto
    {
        public int Id { get; set; }
        public string AgentCode { get; set; }
        public bool Status { get; set; }
    }
}
