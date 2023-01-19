using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCreditController : Controller
    {
        IUserCreditService _userCreditService;
        public UserCreditController(IUserCreditService userCreditService)
        {
            _userCreditService = userCreditService;
        }

        //[HttpPost("add")]
        //public IActionResult Add(UserCredit userCredit)
        //{
        //    int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
        //    string userName = User.FindFirst(ClaimTypes.Name).Value;
        //    string ss = User.FindFirstValue(ClaimTypes.Role);

        //    var result = _userCreditService.Add(userCredit);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}

        //[HttpPost("update")]
        //public IActionResult Update(UserCredit userCredit)
        //{
        //    int userId = string.IsNullOrWhiteSpace(User.FindFirst(ClaimTypes.NameIdentifier).Value) == false ? Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 0;
        //    string userName = User.FindFirst(ClaimTypes.Name).Value;
        //    string ss = User.FindFirstValue(ClaimTypes.Role);

        //    var result = _userCreditService.Update(userCredit);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}

    }
}
