using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers._1._0.Identity
{    
    /// <summary>
    /// Forms
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserAccessController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserAccessController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        /// <summary>
        /// Check for admin role
        /// </summary>
        /// <returns>Array of Forms</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [Produces("application/json")]
        public OkResult IsAdmin()
        {
            // authorizes with annotation
            return Ok();
        }
    }
}