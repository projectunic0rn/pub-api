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
        [ProducesResponseType(200, Type = typeof(ResponseDto<UserDto>))]
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            ResponseDto<UserDto> okResponse = new ResponseDto<UserDto>(true)
            {
                Data = await _user.GetUserAsync(id)
            };
            return Ok(okResponse);
        }

        // PUT api/[controller]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ResponseDto<UserDto>))]
        public async Task<ActionResult<UserDto>> UpdateUser([FromBody]UserDto user)
        {
            ResponseDto<UserDto> okResponse = new ResponseDto<UserDto>(true)
            {
                Data = await _user.UpdateUserAsync(user)
            };
            return Ok(okResponse);
        }
    }
}