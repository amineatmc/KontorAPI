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
    public interface IInvoiceService
    {       
        IDataResult<Invoice> Add(InvoiceAddDto invoiceAddDto, int userId, string role,string agentCode);
        IResult Update(InvoiceUpdateDto invoice);
        IResult UpdateAppStatus(InvoiceAppStatusUpdateDto invoiceAppStatusUpdateDto);
        IDataResult<Invoice> GetByInvoiceId(int id);
       // IDataResult<List<Invoice>> GetByAgentCode(string agentCode);
        IDataResult<List<Invoice>> GetByUserId(int id);       
        IDataResult<PagedModel<List<Invoice>>> GetAllBy(InvoiceDetailDto invoiceDetailDto);
        IDataResult<int> GetInvoiceCount(InvoiceCountDto invoiceCountDto);
   
    }
}
