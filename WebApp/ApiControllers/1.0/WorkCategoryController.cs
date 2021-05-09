using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1.Mappers;
using WorkCategory = PublicApi.DTO.v1.WorkCategory;
using V1DTO = PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{    /// <summary>
    /// WorkCategories
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class WorkCategoriesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly WorkCategoryMapper _mapper = new WorkCategoryMapper();

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkCategoriesController(IAppBLL bll)
        {
            _bll = bll;
        }
        /// <summary>
        /// Get all WorkCategories
        /// </summary>
        /// <returns>Array of WorkCategories</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.WorkCategory>))]
        public async Task<ActionResult<IEnumerable<V1DTO.WorkCategory>>> GetWorkCategories()
        {
            return Ok((await _bll.WorkCategories.GetAllAsync(User.UserId())).Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a WorkCategory
        /// </summary>
        /// <param name="id">WorkCategory Id</param>
        /// <returns>WorkCategory object</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.WorkCategory))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<WorkCategory>> GetWorkCategory(Guid id)
        {
            var workCategory = await _bll.WorkCategories.FirstOrDefaultAsync(id);

            if (workCategory == null)
            {
                return NotFound(new V1DTO.MessageDTO($"WorkCategory with id {id} not found"));
            }

            return Ok(_mapper.Map(workCategory));
        }

        /// <summary>
        /// Update a WorkCategory
        /// </summary>
        /// <param name="id">Session Id</param>
        /// <param name="WorkCategory">WorkCategory object</param>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutWorkCategory(Guid id, V1DTO.WorkCategory WorkCategory)
        {
            if (id != WorkCategory.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and WorkCategory.id do not match"));
            }

            if (!await _bll.WorkCategories.ExistsAsync(WorkCategory.Id, User.UserId()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have WorkCategory with this id {id}"));
            }

            await _bll.WorkCategories.UpdateAsync(_mapper.Map(WorkCategory));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }
        
        /// <summary>
        /// Post a WorkCategory
        /// </summary>
        /// <param name="WorkCategory"></param>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.WorkCategory))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.WorkCategory>> PostWorkCategory(V1DTO.WorkCategory workCategory)
        {
            var bllEntity = _mapper.Map(workCategory);

            workCategory.Id = bllEntity.Id;

            return CreatedAtAction("GetWorkCategory",
                new {id = workCategory.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                workCategory);
        }

        /// <summary>
        /// Delete a WorkCategory
        /// </summary>
        /// <param name="id">WorkCategory Id to delete.</param>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.WorkCategory))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult> DeleteWorkCategory(Guid id)
        {
            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId();

            var workCategory =
                await _bll.WorkCategories.FirstOrDefaultAsync(id, userIdTKey);
            
            if (workCategory == null)
            {
                return NotFound(new V1DTO.MessageDTO($"WorkCategory with id {id} not found!"));
            }

            await _bll.WorkCategories.RemoveAsync(workCategory, userIdTKey);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
