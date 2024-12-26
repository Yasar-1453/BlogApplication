using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Helpers.Exceptions.CategoryExceptions;
using BlogApp.Business.Helpers.Exceptions.Common;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(categoryService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(categoryService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryDto dto)
        {
            try
            {

                return Ok(await categoryService.CreateAsync(dto));
            }
            catch(CategoryNameExsistException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]UpdateCategoryDto dto)
        {
            try
            {
                await categoryService.Update(dto);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
