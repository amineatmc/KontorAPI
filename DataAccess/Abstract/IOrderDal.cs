using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        //List<OrderDetailDto> GetAll();
        //public Invoice CheckIfInvoicePaid(int invoiceId);
        List<Order> GetAllByInfoQuery(OrderDetailDto orderDetailDto);
        public int GetOrderCount(OrderCountDto orderCountDto);



    }
}
