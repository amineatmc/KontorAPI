using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        IInvoiceService _invoiceService;
        IHttpContextAccessor _contextAccessor;

        public InvoiceController(IInvoiceService invoiceService, IHttpContextAccessor contextAccessor)
        {
            _invoiceService = invoiceService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("add")]
        public IActionResult Add(InvoiceAddDto invoiceAddDto)
        {
            int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
            string role = User.FindFirst(ClaimTypes.Role).Value;
            string agentCode =User.FindFirst(ClaimTypes.Surname).Value;
            var result = _invoiceService.Add(invoiceAddDto, userId, role,agentCode);         
            if (result.Success)
            {                                            
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
  

        [HttpGet("getbyid")]
        public IActionResult GetByInvoiceId(int id)
        {
            int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
            string role = User.FindFirst(ClaimTypes.Role).Value;
            string agentCode = User.FindFirst(ClaimTypes.Surname).Value;
           // var ss = _invoiceService.GetByUserId(userId);
            var ss=_invoiceService.GetByUserId(userId);
            var result = _invoiceService.GetByInvoiceId(id);
            if (result.Success)
            {                
                if (role == "user")
                {
                    if (result.Data.UserId == userId)
                    {
                         return Ok(result);                                               
                    }
                    return BadRequest(new ErrorResult());
                }
                else if (role == "admin")
                {
                    return Ok(result);
                }
                return BadRequest(new ErrorResult());
            }
            return BadRequest(new ErrorResult());
        }
        #region
        [HttpGet("getbyuserid")]

        public IActionResult GetByUserId(int id)
        {
            int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
            string role = User.FindFirst(ClaimTypes.Role).Value;
            var result = _invoiceService.GetByUserId(id);

            // var result = _invoiceService.GetByInvoiceId(id);
            if (role == "user")
            {
                if (userId == id)
                {
                    if (result.Success)
                    {
                        return Ok(result);
                    }
                    return BadRequest(new ErrorResult());
                }
            }
            else if (role == "admin")
            {

                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(new ErrorResult());
            }
            return BadRequest(new ErrorResult());
        }
        #endregion
        //[HttpGet("getbyagentcode")]
        //public IActionResult GetByAgentCode(string agentCode)
        //{
        //    int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
        //    string role = User.FindFirst(ClaimTypes.Role).Value;
        //    var result = _invoiceService.GetByAgentCode(agentCode);
        //    if (role == "user")
        //    {
        //        if (agentCode != null)
        //        {
        //            if (result.Success)
        //            {
        //                return Ok(result);
        //            }
        //            return BadRequest(new ErrorResult());
        //        }
        //    }
        //    else if (role == "admin")
        //    {

        //        if (result.Success)
        //        {
        //            return Ok(result);
        //        }
        //        return BadRequest(new ErrorResult());
        //    }
        //    return BadRequest(new ErrorResult());
        //}

        [HttpPost("getallby")]
        public IActionResult GetAllBy([FromBody] InvoiceDetailDto invoiceDetailDto)
        {
            var result = _invoiceService.GetAllBy(invoiceDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getinvoicescount")]
        public IActionResult GetInvoiceCount(InvoiceCountDto invoiceCountDto)
        {
            var result = _invoiceService.GetInvoiceCount(invoiceCountDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(InvoiceUpdateDto invoice)
        {
            var result = _invoiceService.Update(invoice);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
