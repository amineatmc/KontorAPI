using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfInvoiceDal : EfEntityRepositoryBase<Invoice, KontorContext>, IInvoiceDal
    {
        //    IInvoiceDal _invoiceDal;
        //    public EfInvoiceDal(IInvoiceDal invoiceDal)
        //    {
        //        _invoiceDal = invoiceDal;
        //    }
        //    public List<InvoiceDetailDto> GetAll(InvoiceDetailDto invoiceDetailDto)
        //    {
        //        using (KontorContext context = new KontorContext())
        //        {
        //            var result = from i in context.Invoices
        //                         join p in context.Products on i.ProductId equals p.ProductId
        //                         join u in context.PaymentType on i.PaymentTypeId equals u.Id
        //                         select new InvoiceDetailDto
        //                         {
        //                             //Id = i.Id,
        //                             Description = i.Description,
        //                             InvoiceDate = i.InvoiceDate,
        //                             Quantity = i.Quantity,
        //                             Status = i.Status,
        //                             Total = i.Total,
        //                             ProductId = p.ProductId,
        //                             PaymentTypeId = u.Id
        //                         };
        //            return result.ToList();
        //        }
        //    }

        public List<Invoice> GetAllBy(InvoiceDetailDto invoiceDetailDto)
        {
            using (KontorContext context = new KontorContext())
            {
                Expression<Func<Invoice, bool>> query = q =>
                      (invoiceDetailDto.Id > 0 ? q.Id == invoiceDetailDto.Id : true)
                   && (invoiceDetailDto.Description != null ? q.Description.Contains(invoiceDetailDto.Description) : true)
                   && (invoiceDetailDto.UserId > 0 ? q.UserId == invoiceDetailDto.UserId : true)
                   // && (invoiceDetailDto.CreateDate != null ? q.CreateDate.Equals(invoiceDetailDto.CreateDate) : true)
                   //&& (invoiceDetailDto.DoDate != null ? q.Equals(invoiceDetailDto.DoDate) : true)
                   //&& (invoiceDetailDto.UpdateDate != null ? q.Equals(invoiceDetailDto.UpdateDate) : true)

                   //&& (invoiceDetailDto.UserId >0 ? q.UserId==invoiceDetailDto.UserId : true)
                   // && (invoiceDetailDto.PaymentTypeId > 0 ? q.PaymentTypeId == invoiceDetailDto.PaymentTypeId : true) /*.Equals(invoiceDetailDto.PaymentTypeId) : true)*/
                   && (invoiceDetailDto.ProductId > 0 ? q.ProductId == invoiceDetailDto.ProductId : true);
                //  && (invoiceDetailDto.Quantity > 0 ? q.Quantity==invoiceDetailDto.Quantity : true)
                //  && (invoiceDetailDto.Status != true ? q.Equals(invoiceDetailDto.Status) : true)
                // && (invoiceDetailDto.Total > 0 ? q.Equals(invoiceDetailDto.Total) : true);

                return context.Set<Invoice>().Where(query).ToList();
            }
        }

        //public List<InvoiceCountDto> GetInvoiceCount()
        //{
        //    using (KontorContext context = new KontorContext())
        //    {
        //        //return context.Invoices.GroupBy(i => i.Id)
        //        //        .Select(i => new InvoiceCountDto
        //        //        {
        //        //            Id = i.Key,
        //        //            InvoiceCount = i.Count()
        //        //        }).ToList();

        //    }
        //}
        public int GetInvoiceCount(InvoiceCountDto invoiceCountDto)
        {
            using (KontorContext context = new KontorContext())
            {
                if (invoiceCountDto.UserId != null)
                {
                    return context.Invoices.Count(x => x.UserId == invoiceCountDto.UserId);
                }
                else
                {
                    return context.Invoices.Count();
                }
            }
        }

        public List<Invoice> GetInvoiceUpdate(InvoiceUpdateDto invoiceUpdateDto)
        {
            using (KontorContext context = new KontorContext())
            {
                Expression<Func<Invoice, bool>> query = q =>
                      (invoiceUpdateDto.Id != null ? q.Id.Equals(invoiceUpdateDto.Id) : true)
                    && (invoiceUpdateDto.UpdateDate != null ? q.UpdateDate.Equals(DateTime.Now) : true)
                    && (invoiceUpdateDto.DoDate != null ? q.DoDate.Equals(DateTime.Now) : true)
                    && (invoiceUpdateDto.PaymentStatus != null ? q.PaymentStatus.Equals(invoiceUpdateDto.PaymentStatus) : true);


                return context.Set<Invoice>().Where(query).ToList();
            }
        }
    }
}
