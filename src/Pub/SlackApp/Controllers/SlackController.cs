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
        private readonly IMessageQueue _messageQueue;

        public SlackController(IMessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
            _slackRequestValidator = new SlackRequestValidator();
        }

        // POST api/slack/event
        [HttpPost("event")]
        public async Task<ActionResult> RecieveEvent([FromBody] SlackEventDto slackEventDto)
        {

            if (await _slackRequestValidator.IsValid(Request))
            {
                var eventType = slackEventDto.Type;

                if (eventType == "url_verification")
                {
                    var urlVerificationResponseDto = new UrlVerificationResponseDto { challenge = slackEventDto.Challenge };
                    return Ok(urlVerificationResponseDto);
                }

                await _messageQueue.SendMessageAsync(slackEventDto, "event");
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
                await _messageQueue.SendMessageAsync(slackCommandDto, "command");
                return Ok();
            }
            return BadRequest();
        }
    }
}
