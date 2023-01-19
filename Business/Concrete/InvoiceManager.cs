using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using System.Collections;
using WebAPI.Model;

namespace Business.Concrete
{


    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceDal _invoiceDal;
        private readonly IProductService productService;
        private readonly IUserService _userService;
        private readonly IUserDiscountGroupService _userDiscountGroupService;
        private readonly IDiscountGroupService _discountGroupService;





        public InvoiceManager(IInvoiceDal invoiceDal, IProductService productService,IUserService userService,
            IUserDiscountGroupService userDiscountGroupService,IDiscountGroupService discountGroupService)
        {
            _invoiceDal = invoiceDal;
            this.productService = productService;
            _userService = userService;
            _userDiscountGroupService = userDiscountGroupService;
            _discountGroupService = discountGroupService;           
        }

        [SecuredOperation("user,admin")]
        public IDataResult<Invoice> GetByInvoiceId(int id)
        {                     
            return new SuccessDataResult<Invoice>(_invoiceDal.Get(i => i.Id == id));
        }

       [SecuredOperation("user,admin")]
        public IDataResult<Invoice>Add(InvoiceAddDto invoiceAddDto, int userid, string role,string agentCode)
        {                        
            var productResult = this.productService.GetById(invoiceAddDto.ProductId);
            if (role == "user")
            {
                var userdiscount = _userService.GetByAgentCode(agentCode);
                var userdiscountgroup = _userDiscountGroupService.GetByUserId(invoiceAddDto.UserId);

                if (userdiscountgroup.Data != null)
                {
                    var discountgroup = _discountGroupService.GetById(userdiscountgroup.Data.DiscountGroupId);
                    decimal ss = discountgroup.Data.Discount;
                    decimal aa = productResult.Data.UnitPrice;
                    decimal productDiscount = aa - (aa * ss / 100);
                    invoiceAddDto.Total = productDiscount * invoiceAddDto.Quantity;
                }

                var total= (productResult.Data.UnitPrice-(productResult.Data.UnitPrice*userdiscount.Data.Discount/100))*invoiceAddDto.Quantity;
               // var total = productResult.Data.UnitPrice - (productResult.Data.UnitPrice * userdiscount.Data.Discount / 100);
                var invoice = new Invoice()
                {
                    ProductId = invoiceAddDto.ProductId,
                    Quantity = invoiceAddDto.Quantity,
                    Description = invoiceAddDto.Description,
                    Total = total,
                    PaymentStatus = false,
                    CreateDate = DateTime.Now,
                    DoDate = DateTime.Now,
                    //AgentCode = agentCode
                    UserId=userid
                };
                _invoiceDal.Add(invoice);
                return new SuccessDataResult<Invoice>(invoice);
                
            }

              

            else if (role=="admin")
            {
                var udiscount= _userService.GetByUserId(invoiceAddDto.UserId);
                var userdiscountgroup = _userDiscountGroupService.GetByUserId(invoiceAddDto.UserId);
                if (userdiscountgroup.Data != null)
                {
                    var discountgroup = _discountGroupService.GetById(userdiscountgroup.Data.DiscountGroupId);
                    decimal ss = discountgroup.Data.Discount;
                    decimal aa = productResult.Data.UnitPrice;
                    decimal productDiscount = aa - (aa * ss / 100);
                    invoiceAddDto.Total = productDiscount * invoiceAddDto.Quantity;
                }
                else
                {
                    invoiceAddDto.Total=invoiceAddDto.Quantity*(productResult.Data.UnitPrice - (productResult.Data.UnitPrice * udiscount.Data.Discount / 100));
                }
                var invoice = new Invoice()
                {
                    ProductId = invoiceAddDto.ProductId,
                    Quantity = invoiceAddDto.Quantity,
                    Description = invoiceAddDto.Description,
                    Total = invoiceAddDto.Total,
                    PaymentStatus = false,
                    CreateDate = DateTime.Now,
                    DoDate = DateTime.Now,
                    AppStatus = false,             
                   UserId = invoiceAddDto.UserId
                };
                _invoiceDal.Add(invoice);
                return new SuccessDataResult<Invoice>(invoice);
            }

         

            return new SuccessDataResult<Invoice>();
        }

        //[SecuredOperation("user,admin")]
        public IDataResult<PagedModel<List<Invoice>>> GetAllBy(InvoiceDetailDto invoiceDetailDto)
        {
            int pageNumber = (int)(invoiceDetailDto?.Pagination?.PageNumber != null ? invoiceDetailDto.Pagination.PageNumber : 1);
            int pageSize = (int)(invoiceDetailDto?.Pagination?.PageSize != null ? invoiceDetailDto.Pagination.PageSize : 10);
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 10;
            int start = (int)((pageNumber - 1) * pageSize);

            var invoices = _invoiceDal.GetAllBy(invoiceDetailDto).Skip(start).Take(pageSize).ToList();
            var totalRecords = _invoiceDal.GetAllBy(invoiceDetailDto).Count();

            if (totalRecords == 0)
            {
                return new SuccessDataResult<PagedModel<List<Invoice>>>("Empty List");
            }
            else if (invoices.Count == 0)
            {
                return new ErrorDataResult<PagedModel<List<Invoice>>>("Wrong Page Settings");
            }
            return new SuccessDataResult<PagedModel<List<Invoice>>>(new PagedModel<List<Invoice>>(invoices, totalRecords, pageNumber, pageSize));
        }

        [SecuredOperation("user,admin")]
        public IDataResult<int>GetInvoiceCount(InvoiceCountDto invoiceCountDto)
        {
            return new SuccessDataResult<int>(_invoiceDal.GetInvoiceCount(invoiceCountDto));       
        }

        [SecuredOperation("user,admin")]
        public IResult Update(InvoiceUpdateDto invoice)
        {
            Invoice invoiceforupdate = _invoiceDal.Get(i => i.Id == invoice.Id);
            invoiceforupdate.UpdateDate = DateTime.Now;
            invoiceforupdate.DoDate = DateTime.Now;
            invoiceforupdate.PaymentStatus = true;
            _invoiceDal.Update(invoiceforupdate);
            return new SuccessResult();
        }

        public IResult UpdateAppStatus(InvoiceAppStatusUpdateDto invoiceAppStatusUpdateDto)
        {
            Invoice invoice = _invoiceDal.Get(x => x.Id == invoiceAppStatusUpdateDto.Id);
            invoice.AppStatus = invoiceAppStatusUpdateDto.AppStatus;
            _invoiceDal.Update(invoice);
            return new SuccessResult();
        }

        public IDataResult<List<Invoice>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetAll(x => x.UserId == id));
        }

        //public IDataResult<List<Invoice>> GetByAgentCode(string agentCode)
        //{
        //    return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetAll(x => x.AgentCode == agentCode));
        //}

    }
}
