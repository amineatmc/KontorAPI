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
    public interface IInvoiceDal : IEntityRepository<Invoice>
    {
        List<Invoice> GetAllBy(InvoiceDetailDto invoiceDetailDto);   
        public int GetInvoiceCount(InvoiceCountDto invoiceCountDto);
        public List<Invoice> GetInvoiceUpdate(InvoiceUpdateDto invoiceUpdateDto);
    }
}
