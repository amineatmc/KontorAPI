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
    public class UseCreditController : ControllerBase
    {
        IUseCreditService _useCreditService;

        public UseCreditController(IUseCreditService useCreditService)
        {
            _useCreditService = useCreditService;
        }

        [HttpPost("getall")]
        public IActionResult Getall(UseCreditDto useCreditDto)
        {
            var result = _useCreditService.GetAllByInfoQuery(useCreditDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
