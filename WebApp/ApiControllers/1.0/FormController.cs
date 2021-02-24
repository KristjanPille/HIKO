﻿using System;
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
using Form = PublicApi.DTO.v1.Form;
using V1DTO=PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{    /// <summary>
    /// Forms
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class FormsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly FormMapper _mapper = new FormMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public FormsController(IAppBLL bll)
        {
            _bll = bll;
        }
        /// <summary>
        /// get all the Forms
        /// </summary>
        /// <returns>Array of Forms</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.Form>))]
        public async Task<ActionResult<IEnumerable<V1DTO.Form>>> GetForms()
        {
            return Ok((await _bll.Forms.GetAllAsync()).Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single Form
        /// </summary>
        /// <param name="id">Form Id</param>
        /// <returns>Form object</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.Form))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<Form>> GetForm(Guid id)
        {
            var form = await _bll.Forms.FirstOrDefaultAsync(id);

            if (form == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Form with id {id} not found"));
            }

            return Ok(_mapper.Map(form));
        }
        
        /// <summary>
        /// Update the Forms
        /// </summary>
        /// <param name="id">Session Id</param>
        /// <param name="form">Form object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutForm(Guid id, V1DTO.Form form)
        {
            if (id != form.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and Form.id do not match"));
            }

            if (!await _bll.Forms.ExistsAsync(form.Id, User.UserId()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have Form with this id {id}"));
            }

            form.AppUserId = User.UserId();
            await _bll.Forms.UpdateAsync(_mapper.Map(form));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }
        
        /// <summary>
        /// Post /forms
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.Form))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<Form>> PostForm(V1DTO.Form form)
        {
            form.AppUserId = User.UserId();
            form.DateAndTime = DateTime.Now;
            var bllEntity = _mapper.Map(form);

            _bll.Forms.Add(bllEntity);
            await _bll.SaveChangesAsync();
            form.Id = bllEntity.Id;

            return CreatedAtAction("GetForm",
                new {id = form.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                form);
        }
        
        /// <summary>
        /// Delete the Form
        /// </summary>
        /// <param name="id">form Id to delete.</param>
        /// <returns>form just deleted</returns>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.Form))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<Form>> DeleteForm(Guid id)
        {
            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId();

            var form =
                await _bll.Forms.FirstOrDefaultAsync(id, userIdTKey);
            
            if (form == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Form with id {id} not found!"));
            }

            await _bll.Forms.RemoveAsync(form, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(form);
        }
    }
}