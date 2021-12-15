using AutoMapper;
using CatalogService.Business;
using CatelogService.DTO;
using CatelogService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatelogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogBrandController : ControllerBase
    {
        private ICatalogBrandBusiness _catalogBrandBusiness;
        private IMapper _mapper;
        private ILogger<CatalogBrandController> _logger;


        public CatalogBrandController(ICatalogBrandBusiness catalogBrandBusiness, IMapper mapper, ILogger<CatalogBrandController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _catalogBrandBusiness = catalogBrandBusiness;
        }


        // GET: api/<CatalogBrandController>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CatalogBrandDto>>> GetAll()
        {
            IEnumerable<CatalogBrandModel> catalogBrandModel = await _catalogBrandBusiness.GetAllAsyc();

            return Ok(catalogBrandModel.ToDtoEnumerable<CatalogBrandDto>(_mapper));

        }

        // GET api/<CatalogBrandController>/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CatalogBrandDto>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id must be passed to get the specific Product model");
            }

            CatalogBrandModel catalogBrandModel = await _catalogBrandBusiness.GetByIdAsync(id);

            if (catalogBrandModel != null)
            {
                return Ok(catalogBrandModel.ToDto<CatalogBrandDto>(_mapper));
            }
            else
            {
                return NotFound("Product type with this id not found");
            }

        }

        // POST api/<CatalogBrandController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CatalogBrandDto>> Post([FromBody] CatalogBrandDto catalogBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CatalogBrandModel catalogBrandModel = catalogBrandDto.ToEntity<CatalogBrandModel>(_mapper);

            // Add Product Catalog
            catalogBrandModel = await _catalogBrandBusiness.AddAsync(catalogBrandModel);

            // Send the the created object to client
            return CreatedAtAction(nameof(GetById), new { id = catalogBrandModel.ID }, catalogBrandModel.ToDto<CatalogBrandDto>(_mapper));

        }

        // PUT api/<CatalogBrandController>/5
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CatalogBrandDto>> Put([FromBody] CatalogBrandDto catalogBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CatalogBrandModel catalogBrandModelInDb = await _catalogBrandBusiness.GetByIdAsync(catalogBrandDto.ID);

            if (catalogBrandModelInDb == null)
            {
                return NotFound("There is no Catalog Brand with this name");
            }
            CatalogBrandModel catalogBrandModelUpdated = catalogBrandDto.ToEntity<CatalogBrandModel>(_mapper);

            catalogBrandModelUpdated = await _catalogBrandBusiness.UpdateSync(catalogBrandModelUpdated);

            return catalogBrandModelUpdated.ToDto<CatalogBrandDto>(_mapper);

        }

        // DELETE api/<CatalogBrandController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (await _catalogBrandBusiness.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await _catalogBrandBusiness.DeleteAsync(id);

            // Nothing to update to client.
            return NoContent();

        }
    }
}
