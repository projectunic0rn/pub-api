using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Contracts;
using Common.DTOs.SlackAppDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlackApp.Helpers;

namespace SlackApp.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class SlackController : ControllerBase
    {
        private SlackRequestValidator _slackRequestValidator;
        private readonly IChatAppCommandHandler _commandHandler;
        private readonly IChatAppEventHandler _eventHandler;

        public SlackController(IChatAppCommandHandler commandHandler, IChatAppEventHandler eventHandler)
        {
            _slackRequestValidator = new SlackRequestValidator();
            _commandHandler = commandHandler;
            _eventHandler = eventHandler;
        }

        // POST api/slack/event
        [HttpPost("event")]
        public async Task<ActionResult> RecieveEvent([FromBody] SlackEventDto slackEventDto)
        {   
            if (await _slackRequestValidator.IsValid(Request))
            {
                if (slackEventDto.Type == "url_verification")
                {
                    var urlVerificationResponseDto = _eventHandler.UrlVerification(slackEventDto);
                    return Ok(urlVerificationResponseDto);
                }
                
                await _eventHandler.ProcessEvent(slackEventDto);
                return Ok();
            }
            
            return BadRequest();
            
        }

        // POST api/slack/command
        [HttpPost("command")]
        public async Task<ActionResult> RecieveCommand([FromForm] SlackCommandDto slackCommandDto)
        {
            if (await _slackRequestValidator.IsValid(Request))
            {
                var response = await _commandHandler.ProcessCommand(slackCommandDto);
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
