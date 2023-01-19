using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, KontorContext>, IOrderDal
    {

        //public Invoice CheckIfInvoicePaid(int invoiceId)
        //{
        //    using (KontorContext context = new KontorContext())
        //    {
        //        return context.Invoices.Where(i => i.Id == invoiceId).FirstOrDefault();
        //    }
        //}
        public List<Order> GetAllByInfoQuery(OrderDetailDto orderDetailDto)
        {
            using (KontorContext context = new KontorContext())
            {
                Expression<Func<Order, bool>> query = q =>

                  (orderDetailDto.Description != null ? q.Description.Contains(orderDetailDto.Description) : true)
               && (orderDetailDto.UserId > 0 ? q.UserId == orderDetailDto.UserId : true)
               && (orderDetailDto.OrderId > 0 ? q.OrderId == orderDetailDto.OrderId : true)
               && (orderDetailDto.ProductId > 0 ? q.ProductId == orderDetailDto.ProductId : true)
               && (orderDetailDto.InvoiceId > 0 ? q.InvoiceId==orderDetailDto.InvoiceId: true);
                return context.Set<Order>().Where(query).ToList();
            }
        }

        //public List<OrderCountDto> GetOrderCount()
        //{
        //    using (KontorContext context= new KontorContext())
        //    {
        //        return context.Orders.GroupBy(x => x.OrderId).Select(x => new OrderCountDto
        //        {
        //            OrderId =x.Key,
        //            OrderCount = x.Count()
        //        }).ToList();
        //    }
        //}

        public List<OrderDetailDto> GetAll()
        {
            using (KontorContext context = new KontorContext())
            {
                var result = from o in context.Orders
                             join p in context.Products on o.ProductId equals p.ProductId
                             join u in context.Users on o.UserId equals u.Id
                             join i in context.Invoices on o.InvoiceId equals i.Id
                             join pt in context.PaymentType on o.PaymentTypeId equals pt.Id
                             select new OrderDetailDto 
                             {
                                    OrderId=o.OrderId,
                                    UserId =u.Id, 
                                    ProductId=p.ProductId,
                                    UnitPrice=p.UnitPrice,
                                    Description = o.Description,
                                   // OrderDate = o.OrderDate,
                                    Quantity = o.Quantity,
                                    Total = o.Total,
                                    PaymentType = pt.Payment_type,
                                    InvoiceId = i.Id
                             };
                return result.ToList();     
            }
        }

        public int GetOrderCount(OrderCountDto orderCountDto)
        {                        
                using (KontorContext context = new KontorContext())
                {
                    if (orderCountDto.UserId != null)
                    {
                        return context.Orders.Count(x => x.UserId== orderCountDto.UserId);
                    }
                    else
                    {
                        return context.Orders.Count();
                    }
                }
            
        }
    }
}
