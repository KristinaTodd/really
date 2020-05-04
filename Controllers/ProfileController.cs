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
  public class ProfileController : ControllerBase
  {
    private readonly ProfileService _ks;
    public ProfileController(ProfileService ks)
    {
      _ps = ps;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Profile>> Get()
    {
      try
      {
        return Ok(_ps.Get());
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
        return Ok(_ps.Create(newHome));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}