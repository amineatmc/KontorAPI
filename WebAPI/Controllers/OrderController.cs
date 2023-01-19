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
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("getall")]
        public IActionResult GetAllByInfoQuery([FromBody] OrderDetailDto orderDetailDto)
        {
            var result = _orderService.GetAllByInfoQuery(orderDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyorderid")]
        public IActionResult GetByOrderId(int id)
        {
            int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
            string role = User.FindFirst(ClaimTypes.Role).Value;
            var result = _orderService.GetByOrderId(id);
            if (role == "user")
            {
                if (result.Data.UserId == userId)
                {
                    return Ok(result);
                }
                return BadRequest(new ErrorResult());
            }
            else if (role=="admin")
            {                
                    return Ok(result);
                
                return BadRequest(new ErrorResult());
            }
            return BadRequest(new ErrorResult());
        }

        [HttpPost("getorderscount")]
        public IActionResult GetOrderCount(OrderCountDto orderCountDto)
        {
            var result = _orderService.GetOrdersCount(orderCountDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int id)
        {
            int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
            string role = User.FindFirst(ClaimTypes.Role).Value;
            var result = _orderService.GetByUserId(id);
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
            else if (role=="admin")
            {
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(new ErrorResult());
            }
            return BadRequest(new ErrorResult());
        }
        //[HttpGet("getbyagentcode")]
        //public IActionResult GetByAgentCode(string agentCode)
        //{
        //    int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
        //    string role = User.FindFirst(ClaimTypes.Role).Value;
        //    //var result = _orderService.GetByUserId(id);
        //    var result = _orderService.GetByUserId(userId);
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

        [HttpPost("add")]
        public IActionResult Add(OrderAddDto orderAddDto)
        {            
             int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
             string userName = User.FindFirst(ClaimTypes.Name).Value ;
             string role = User.FindFirst(ClaimTypes.Role).Value/*==false ? Convert.ToInt32(User.FindFirst(ClaimTypes.Role).Value) : 0*/;
             var result = _orderService.Add(orderAddDto, userName);                        
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
        }
    }
}