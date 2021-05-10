using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using DAL.App.DTO;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1.Mappers;
using Company = PublicApi.DTO.v1.Company;
using V1DTO = PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{    /// <summary>
    /// Companies
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CompaniesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly CompanyMapper _mapper = new CompanyMapper();
        private readonly WorkCategoryMapper _workCategoryMapper = new WorkCategoryMapper();

        /// <summary>
        /// Constructor
        /// </summary>
        public CompaniesController(IAppBLL bll)
        {
            _bll = bll;
        }
        /// <summary>
        /// Get all Companies
        /// </summary>
        /// <returns>Array of Companies</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.Company>))]
        public async Task<ActionResult<IEnumerable<V1DTO.Company>>> GetCompanies()
        {
            return Ok((await _bll.Companies.GetAllAsync(User.UserId())).Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a Company
        /// </summary>
        /// <param name="id">Company Id</param>
        /// <returns>Company object</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.Company))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<Company>> GetCompany(Guid id)
        {
            var company = await _bll.Companies.FirstOrDefaultAsync(id);

            if (company == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Company with id {id} not found"));
            }

            return Ok(_mapper.Map(company));
        }

        /// <summary>
        /// Update a Company
        /// </summary>
        /// <param name="id">Session Id</param>
        /// <param name="company">Company object</param>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutCompany(Guid id, V1DTO.Company company)
        {
            if (id != company.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and Company.id do not match"));
            }

            if (!await _bll.Companies.ExistsAsync(company.Id, User.UserId()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have Company with this id {id}"));
            }

            company.AppUserId = User.UserId();

            await _bll.Companies.UpdateAsync(_mapper.Map(company));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }
        
        /// <summary>
        /// Post a Company
        /// </summary>
        /// <param name="company"></param>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.Company))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.Company>> PostCompany(V1DTO.Company company)
        {
            company.AppUserId = User.UserId();
            var bllEntity = _mapper.Map(company);

            _bll.Companies.Add(bllEntity);
            
            await _bll.SaveChangesAsync();

            company.Id = bllEntity.Id;

            return CreatedAtAction("GetCompany",
                new {id = company.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                company);
        }

        /// <summary>
        /// Delete a Company
        /// </summary>
        /// <param name="id">Company Id to delete.</param>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.Company))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult> DeleteCompany(Guid id)
        {
            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId();

            var company =
                await _bll.Companies.FirstOrDefaultAsync(id, userIdTKey);
            
            if (company == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Company with id {id} not found!"));
            }

            await _bll.Companies.RemoveAsync(company, userIdTKey);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
