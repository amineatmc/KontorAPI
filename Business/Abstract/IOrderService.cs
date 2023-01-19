using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<PagedModel<List<Order>>> GetAllByInfoQuery(OrderDetailDto orderDetailDto);        
        IDataResult<int> GetOrdersCount(OrderCountDto orderCountDto);

        IResult Add(OrderAddDto orderAddDto, string userName);
        //IResult AddCredit(Order order, string userName);
        IDataResult<Order> GetByOrderId(int id);
        //IDataResult<List<Order>> GetByAgentCode(string agentCode);
        IDataResult<List<Order>> GetByUserId(int id);

        
    }
}
