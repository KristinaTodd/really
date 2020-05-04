using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Really.Models;
using Really.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Really.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HomeController : ControllerBase
  {
    private readonly HomeService _ks;
    public HomeController(HomeService ks)
    {
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Home>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Home> Post([FromBody] Home newHome)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newHome.UserId = userId;
        return Ok(_ks.Create(newHome));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}