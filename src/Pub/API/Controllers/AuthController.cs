using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.DTOs;

namespace API.Controllers
{
    /// <summary>  
    ///  This controller class defines the set of endpoints
    ///  available to authenticate members and complete Oauth
    ///  workflow.
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // POST api/[controller]/login
        [HttpPost("login")]
        public ActionResult Login([FromBody] SlackEventDto slackEvent)
        {
            return Ok();
        }

         // POST api/[controller]/slack
        [HttpPost("register")]
        public async Task<ActionResult> Slack([FromBody] SlackAuthDto slackAuthDto)
        {
            return Ok();
        }
    }
}
