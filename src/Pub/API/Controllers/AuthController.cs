using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
    public class AuthController : ControllerBase { }
}