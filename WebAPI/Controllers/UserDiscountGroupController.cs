using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserDiscountGroupController : ControllerBase
    {
        IUserDiscountGroupService _userDiscountGroupService;
        IDiscountGroupService _discountGroupService;
        IUserService _userService;
        public UserDiscountGroupController(IUserDiscountGroupService userDiscountGroupService, IDiscountGroupService discountGroupService,IUserService userService)
        {
            _userDiscountGroupService = userDiscountGroupService;
            _discountGroupService = discountGroupService;
            _userService=userService;
        }


        //[HttpGet("getbyagentcode")]
        //public IActionResult GetByAgentCode(string agentCode)
        //{
        //    var result = _userDiscountGroupService.GetByAgentCode(agentCode);

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int id)
        {
            var result= _userDiscountGroupService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserDiscountGroup userDiscountGroup)
        {
            var result = _userDiscountGroupService.Update(userDiscountGroup);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userDiscountGroupService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserDiscountGroup userDiscountGroup)
        {
            var result = _userDiscountGroupService.Add(userDiscountGroup);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserDiscountGroupDeleteDto userDiscountGroup)
        {
            var result = _userDiscountGroupService.Delete(userDiscountGroup);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
