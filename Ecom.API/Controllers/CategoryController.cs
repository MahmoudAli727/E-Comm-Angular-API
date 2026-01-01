using Ecom.API.Helper;
using Ecom.Core.DTO;
using Ecom.Core.Entity.Product;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecom.API.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _unitOfWork.CategoriesRepository.GetAllAsync();
                if (categories == null || !categories.Any())
                {
                    return NotFound("No categories found.");
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here for brevity)
                return BadRequest(new ResponseAPI(400));
            }
        }

        [HttpGet("GetById/${Id}")]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            try
            {
                var category = await _unitOfWork.CategoriesRepository.GetByIdAsync(Id);
                if (category == null)
                {
                    return NotFound($"Category with ID {Id} not found.");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here for brevity)
                //return StatusCode(500, "An error occurred while processing your request.");
                return BadRequest(new ResponseAPI(400, $"Category with ID {Id} not found."));
            }
        }

        [HttpDelete("Delete/${Id}")]
        public IActionResult DeleteCategory(int Id)
        {
            try
            {
                _unitOfWork.CategoriesRepository.Delete(Id);
                //return Ok($"Category with ID {Id} has been deleted.");
                return Ok(new ResponseAPI(200, $"Category with ID {Id} has been deleted."));
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here for brevity)
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
   
        [HttpPost("Save")]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            try
            {
                var category = new Category
                {
                    Name = categoryDto.Name,
                    Description = categoryDto.Description
                };
                 await _unitOfWork.CategoriesRepository.AddAsync(category);
                return Ok(new ResponseAPI(200, "Category has been saved successfully."));
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here for brevity)
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(Category categoryDto)
        {
            try
            {
                 _unitOfWork.CategoriesRepository.Update(categoryDto);
                //return Ok("Category has been saved successfully.");
                return Ok(new ResponseAPI(200, "Category has been updated successfully."));
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here for brevity)
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
