using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CatalogService.Business;
using CatelogService.DTO;
using CatelogService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CatelogService.API.Controllers
{
    /// <summary>
    /// This Controller will provide API related to Product Catalog.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private IProductBusiness _productBusiness;
        private IMapper _mapper;
        private ILogger<CatalogController> _logger; 

        public CatalogController(IProductBusiness productBusiness, IMapper mapper, ILogger<CatalogController> logger)
        {
            this._productBusiness = productBusiness;
            this._mapper = mapper;
            this._logger = logger;
            
        }

        /// <summary>
        /// This function returns all the products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            IEnumerable<ProductModel> products = await _productBusiness.GetAllAsyc();

            return Ok(products.ToDtoEnumerable<ProductDto>(_mapper));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<ProductDto> GetById(Guid id)
        {
            ProductModel productModel = _productBusiness.GetById(id);

            if (productModel == null)
            {
                return NotFound();
            }

            return Ok(productModel.ToDto<ProductDto>(_mapper));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<ProductDto>> Create(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductModel productModel = productDto.ToEntity<ProductModel>(_mapper);

            // Add product
            productModel = await _productBusiness.AddAsync(productModel);

            return CreatedAtAction(nameof(GetById), new { id = productModel.ID }, productModel.ToDto<ProductDto>(_mapper));

        }

        [HttpPut]
        [ProducesResponseType(204)]
        public IActionResult Update(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductModel productModel = productDto.ToEntity<ProductModel>(_mapper);

            // Update Product
            productModel = _productBusiness.Update(productModel);

            return NoContent(); 

        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            if(_productBusiness.GetById(id) == null)
            {
                return NotFound();
            }

            _productBusiness.Delete(id);

            return NoContent();
        }

    }
}