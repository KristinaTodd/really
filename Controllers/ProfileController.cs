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
    private readonly ProfileService _ps;
    public ProfileController(ProfileService ps)
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
    public ActionResult<Profile> Post([FromBody] Profile newProfile)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newProfile.UserId = userId;
        return Ok(_ps.Create(newProfile));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}