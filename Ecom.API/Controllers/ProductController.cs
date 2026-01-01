using Ecom.API.Helper;
using Ecom.Core.DTO;
using Ecom.Core.Entity.Product;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var Products = await _unitOfWork.ProductsRepository.GetAllAsync(x=>x.Category,x=>x.Photos);
                if (Products == null || !Products.Any())
                {
                    return NotFound("No products found.");
                }
                return Ok(Products);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here for brevity)
                return BadRequest(new ResponseAPI(400));
            }
        }

        [HttpGet("GetById/${Id}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            try
            {
                var Product = await _unitOfWork.ProductsRepository.GetByIdAsync(Id, x=>x.Photos,x=>x.Category);
                if (Product == null)
                {
                    return NotFound($"Product with ID {Id} not found.");
                }
                return Ok(Product);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here for brevity)
                return BadRequest(new ResponseAPI(400, $"Product with ID {Id} not found."));
            }
        }

        [HttpDelete("Delete/${Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            try
            {
                _unitOfWork.ProductsRepository.Delete(Id);
                return Ok(new ResponseAPI(200, $"Product with ID {Id} has been deleted."));
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here for brevity)
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(ProductDto ProductDto)
        {
            try
            {
                //var Product = new Product
                //{
                //    Name = ProductDto.Name,
                //    Description = ProductDto.Description
                //};
                //await _unitOfWork.ProductsRepository.AddAsync(Product);
                return Ok(new ResponseAPI(200, "Product has been saved successfully."));
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here for brevity)
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(Product ProductDto)
        {
            try
            {
                _unitOfWork.ProductsRepository.Update(ProductDto);
                //return Ok("Product has been saved successfully.");
                return Ok(new ResponseAPI(200, "Product has been updated successfully."));
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here for brevity)
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
