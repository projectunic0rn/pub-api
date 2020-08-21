using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Common.Contracts;
using Common.DTOs;

namespace API.Controllers
{
    [Route("api/util")]
    [AllowAnonymous]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        private readonly IUtilities _utilities;
        private readonly INotifier _notifier;

        public UtilitiesController(IUtilities utilities, INotifier notifier)
        {
            _utilities = utilities;
            _notifier = notifier;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ResponseDto<ValidationDto>))]
        public async Task<IActionResult> ValidateUsername([FromBody] UsernameDto usernameDto)
        {
            ResponseDto<ValidationDto> okResponse = new ResponseDto<ValidationDto>(true);

            var response = await _utilities.ValidateUsernameAsync(usernameDto.Username);
            okResponse.Data = response;

            return Ok(okResponse);
        }

        [HttpGet("projecttypes")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<List<ProjectTypeDto>>))]
        public async Task<IActionResult> GetProjectTypes()
        {
            ResponseDto<List<ProjectTypeDto>> okResponse = new ResponseDto<List<ProjectTypeDto>>(true);
            var projectTypes = await _utilities.GetProjectTypesAsync();
            okResponse.Data = projectTypes;
            return Ok(okResponse);
        }

        [HttpGet("workspaces")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<List<CommunicationPlatformTypeDto>>))]
        public async Task<IActionResult> GetCommunicationPlatformTypes()
        {
            ResponseDto<List<CommunicationPlatformTypeDto>> okResponse = new ResponseDto<List<CommunicationPlatformTypeDto>>(true);
            var communicationPlatformTypes = await _utilities.GetCommunicationPlatformTypesAsync();
            okResponse.Data = communicationPlatformTypes;
            return Ok(okResponse);
        }

        [HttpPost("send-feedback")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<NotificationDto>))]
        [ProducesResponseType(400, Type = typeof(ResponseDto<ErrorDto>))]
        public async Task<IActionResult> SendFeedback([FromBody] FeedbackDto feedback)
        {
            ResponseDto<NotificationDto> okResponse = new ResponseDto<NotificationDto>(true);
            ResponseDto<ErrorDto> errorResponse = new ResponseDto<ErrorDto>(false);

            NotificationDto notification = new NotificationDto(feedback.Content);
            try
            {
                await _notifier.SendFeedbackNotificationAsync(notification);
                okResponse.Data = notification;
            }
            catch (Exception e)
            {
                errorResponse.Data = new ErrorDto(e.Message);
                return BadRequest(errorResponse);
            }

            return Ok(okResponse);
        }
    }
}