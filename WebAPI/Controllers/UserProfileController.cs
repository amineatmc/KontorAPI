using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        IUserService _userService;
        IUseCreditService _useCreditService;
        public UserProfileController(IUserService userService, IUseCreditService useCreditService)
        {
            _useCreditService = useCreditService;
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyagentcode")]
        public IActionResult GetByAgentCode(string agentCode)
        {
            var result = _userService.GetByAgentCode(agentCode);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(UserForUpdateDto userForUpdateDto)
        {
            int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
            string userName = User.FindFirst(ClaimTypes.Name).Value;
            string ss = User.FindFirstValue(ClaimTypes.Role);

            var result = _userService.Update(userForUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("creditupdate")]
        public IActionResult Update(UserCreditAddDto userCreditAddDto)
        {
            int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
            string userName = User.FindFirst(ClaimTypes.Name).Value;
            string ss = User.FindFirstValue(ClaimTypes.Role);

            var result = _userService.CreditUpdate(userCreditAddDto, userName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("userdiscountupdate")]
        public IActionResult UserDiscount(UserDiscountUpdateDto userDiscountUpdateDto)
        {
            var result = _userService.UserDiscountUpdate(userDiscountUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("useractivation")]
        public IActionResult UserActivation(UserActivationDto userActivation)
        {
            var result = _userService.UserActivation(userActivation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(new ErrorResult(Messages.AuthorizationDenied));
        }

        [HttpPost("usecredit")]
        public IActionResult UseCredit(UseCredit useCredit)
        {
            var result = _useCreditService.Add(useCredit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


    }
}
