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
        private readonly INotifier _mailer;

        public UtilitiesController(IUtilities utilities, INotifier notifier)
        {
            _utilities = utilities;
            _mailer = notifier;
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
        [ProducesResponseType(200, Type = typeof(ResponseDto<ProjectTypeDto>))]
        public async Task<IActionResult> GetProjectTypes()
        {
            ResponseDto<List<ProjectTypeDto>> okResponse = new ResponseDto<List<ProjectTypeDto>>(true);
            var projectTypes = await _utilities.GetProjectTypesAsync();
            okResponse.Data = projectTypes;
            return Ok(okResponse);
        }

        [HttpPost("send-feedback")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<NotificationDto>))]
        public async Task<IActionResult> SendFeedback([FromBody] FeedbackDto feedback)
        {
            ResponseDto<NotificationDto> okResponse = new ResponseDto<NotificationDto>(true);
            NotificationDto notification = new NotificationDto(feedback.Content, "Feedback");
            try
            {
                var response = await _mailer.SendNotificationAsync(notification);
                okResponse.Data = response;
            }
            catch (Exception e)
            {
                // TODO: Update Exception type. Catch failed email sent, pass to bus/queue to re-try mailing later
                okResponse.Data = notification;
            }

            return Ok(okResponse);
        }
    }
}