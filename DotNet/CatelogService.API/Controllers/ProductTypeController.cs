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
    public class ProductTypeController : ControllerBase
    {
        IProductTypeBusiness _productTypeBusiness;
        ILogger<ProductTypeController> _logger;
        IMapper _mapper;

        public ProductTypeController(IMapper mapper, ILogger<ProductTypeController> logger, IProductTypeBusiness productTypeBusiness)
        {
            _mapper = mapper;
            _logger = logger;
            _productTypeBusiness = productTypeBusiness;

        }

        // GET: api/<ProductTypeController>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductTypeDto>>> GetAll()
        {
            IEnumerable<ProductTypeModel> productTypeModels = await _productTypeBusiness.GetAllAsyc();

            return Ok(productTypeModels.ToDtoEnumerable<ProductTypeDto>(_mapper));
        }

        // GET api/<ProductTypeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ProductTypeDto>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id must be passed to get the specific Product Type Model");
            }

            ProductTypeModel productTypeModel = await _productTypeBusiness.GetByIdAsync(id);

            if (productTypeModel != null)
            {
                return Ok(productTypeModel.ToDto<ProductTypeDto>(_mapper));
            }
            else
            {
                return NotFound("The ProductType with this ID is not found");
            }

            
        }

        // POST api/<ProductTypeController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ProductTypeDto>> Post([FromBody] ProductTypeDto productTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductTypeModel productTypeModel = productTypeDto.ToEntity<ProductTypeModel>(_mapper);

            // Add Product Catalog
            productTypeModel = await _productTypeBusiness.AddAsync(productTypeModel);

            // Send the the created object to client
            return CreatedAtAction(nameof(GetById), new { id = productTypeModel.ID }, productTypeModel.ToDto<ProductTypeDto>(_mapper));
        }

        // PUT api/<ProductTypeController>/5
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProductTypeDto>> Put([FromBody] ProductTypeDto productTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductTypeModel productTypeModelInDb = await _productTypeBusiness.GetByIdAsync(productTypeDto.ID);

            if (productTypeModelInDb == null)
            {
                return NotFound("There is no Product Type with this name");
            }
            ProductTypeModel productTypeUpdated = productTypeDto.ToEntity<ProductTypeModel>(_mapper);

            productTypeUpdated = await _productTypeBusiness.UpdateSync(productTypeUpdated);

            return productTypeUpdated.ToDto<ProductTypeDto>(_mapper);
        }

        // DELETE api/<ProductTypeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (await _productTypeBusiness.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await _productTypeBusiness.DeleteAsync(id);

            // Nothing to update to client.
            return NoContent();
        }
    }
}
