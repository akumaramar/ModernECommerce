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

        public CatalogController(IProductBusiness productBusiness, IMapper mapper)
        {
            this._productBusiness = productBusiness;
            this._mapper = mapper;
            
        }

        /// <summary>
        /// This function returns all the products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            IEnumerable<ProductModel> products = _productBusiness.GetAll();

            IEnumerable<ProductDto> productsToSend = _mapper.Map<IEnumerable<ProductDto>>(products);

            //All is well
            return Ok(productsToSend);
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

            return Ok(_mapper.Map<ProductDto>(productModel));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<ProductDto> Create(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductModel productModel = _mapper.Map<ProductModel>(productDto);

            // Add product
            productModel = _productBusiness.Add(productModel);

            return CreatedAtAction(nameof(GetById), new { id = productModel.ID }, _mapper.Map<ProductDto>(productModel));

        }

    }
}