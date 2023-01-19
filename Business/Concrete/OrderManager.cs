using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IUserService _userService;
        private readonly IUserDal _userDal;
        private readonly IInvoiceDal _invoiceDal;
        private readonly IProductService productService;
        private readonly IAuthService _authService;
        private readonly IBalanceDal _balanceDal;
        private readonly IUserService userService;
        private readonly IInvoiceService _invoiceService;

        public OrderManager(IOrderDal orderDal, IProductService productService, IUserService userService,
            IInvoiceDal invoiceDal, IAuthService authService, IUserDal userDal, IBalanceDal balanceDal, IInvoiceService invoiceService)
        {
            _orderDal = orderDal;
            _userDal = userDal;
            this.productService = productService;
            _userService = userService;
            _invoiceDal = invoiceDal;
            _authService = authService;
            _balanceDal = balanceDal;
            _invoiceService = invoiceService;           
        }

        [SecuredOperation("user,admin")]
        public IResult Add(OrderAddDto orderAddDto, string userName)
        {
            var invoiceState = _invoiceService.GetByInvoiceId(orderAddDto.InvoiceId);
            if (invoiceState.Data.PaymentStatus == true && invoiceState.Data.AppStatus==false)
            {
                Order order = new Order()
                {
                    Total = invoiceState.Data.Total,
                    InvoiceId = orderAddDto.InvoiceId,
                    UserId = invoiceState.Data.UserId,
                    //AgentCode=invoiceState.Data.AgentCode,
                    ProductId = invoiceState.Data.ProductId,
                    Quantity = invoiceState.Data.Quantity,
                    Description = invoiceState.Data.Description,
                    PaymentTypeId=orderAddDto.PaymentTypeId,
                    OrderDate=DateTime.Now,

            };            
                _orderDal.Add(order);

                var invoice = _invoiceService.GetByInvoiceId(order.InvoiceId);
                {
                    invoice.Data.AppStatus = true;
                };
                _invoiceDal.Update(invoice.Data);

                Balance balance = new Balance()
                {
                    PaymentTypeId = order.PaymentTypeId,
                    Count = order.Quantity,
                    DeclareUserName = userName,
                    ReceiveUserName = (order.UserId).ToString(),
                    CreateDate = order.OrderDate
                };
                _balanceDal.Add(balance);

                var user = _userService.GetByUserId(order.UserId);
                {
                    user.Data.Credits += order.Quantity;
                };
                _userDal.Update(user.Data);         
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        [SecuredOperation("user,admin")]
        public IDataResult<Order> GetByOrderId(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o => o.OrderId == id));
        }

        [SecuredOperation("user,admin")]
        public IDataResult<List<Order>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.UserId == id));
        }
        
        [SecuredOperation("user,admin")]
        public IDataResult<PagedModel<List<Order>>> GetAllByInfoQuery(OrderDetailDto orderDetailDto)
        {
            int pageNumber = (int)(orderDetailDto?.Pagination?.PageNumber != null ? orderDetailDto.Pagination.PageNumber : 1);
            int pageSize = (int)(orderDetailDto?.Pagination?.PageSize != null ? orderDetailDto.Pagination.PageSize : 10);
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 10;
            int start = (int)((pageNumber - 1) * pageSize);

            var orders = _orderDal.GetAllByInfoQuery(orderDetailDto).Skip(start).Take(pageSize).ToList();
            var totalRecords = _orderDal.GetAllByInfoQuery(orderDetailDto).Count();

            if (totalRecords == 0)
            {
                return new SuccessDataResult<PagedModel<List<Order>>>();
            }
            else if (orders.Count == 0)
            {
                return new ErrorDataResult<PagedModel<List<Order>>>();
            }
            return new SuccessDataResult<PagedModel<List<Order>>>(new PagedModel<List<Order>>(orders, totalRecords, pageNumber, pageSize));
        }
        public IDataResult<int> GetOrdersCount(OrderCountDto orderCountDto)
        {
            return new SuccessDataResult<int>(_orderDal.GetOrderCount(orderCountDto));
        }

        //public IDataResult<List<Order>> GetByAgentCode(string agentCode)
        //{
        //    return new SuccessDataResult<List<Order>>(_orderDal.GetAll(x => x.AgentCode == agentCode));
        //}
    }
}
