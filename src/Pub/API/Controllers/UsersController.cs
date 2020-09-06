using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Common.DTOs;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    /// <summary>
    ///  This controller class defines the set of endpoints
    ///  available to handle all user related functionality
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;

        public UsersController(IUser user)
        {
            _user = user;
        }

        // GET api/[controller]/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<UserProfileDto>))]
        public async Task<IActionResult> GetUser(Guid id)
        {
            ResponseDto<UserProfileDto> okResponse = new ResponseDto<UserProfileDto>(true)
            {
                Data = await _user.GetUserAsync(id)
            };
            return Ok(okResponse);
        }

        // GET api/[controller]/contact/{id}
        [HttpGet("contact/{id}")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<UserContactDto>))]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> GetUserContact(Guid id)
        {
            ResponseDto<UserContactDto> okResponse = new ResponseDto<UserContactDto>(true)
            {
                Data = await _user.GetUserContactAsync(id)
            };
            return Ok(okResponse);
        }

        // GET api/[controller]/recent
        [HttpGet("recent")]
        [ProducesResponseType(200, Type = typeof(ResponseDto<List<RecentDevDto>>))]
        public async Task<IActionResult> GetRecentDevs()
        {
            ResponseDto<List<RecentDevDto>> okResponse = new ResponseDto<List<RecentDevDto>>(true)
            {
                Data = await _user.GetRecentDevsAsync()
            };
            return Ok(okResponse);
        }

        // PUT api/[controller]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ResponseDto<UserDto>))]
        #if !DEBUG
        [Authorize]
        #endif
        public async Task<IActionResult> UpdateUser([FromBody]UserDto user)
        {
            ResponseDto<UserDto> okResponse = new ResponseDto<UserDto>(true)
            {
                Data = await _user.UpdateUserAsync(user)
            };
            return Ok(okResponse);
        }
    }
}