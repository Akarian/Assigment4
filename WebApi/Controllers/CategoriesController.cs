using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {

        IDataService _dataService;

        public CategoriesController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories =  _dataService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public ActionResult<Category> GetCategory(int categoryId)
        {
            var category = _dataService.GetCategory(categoryId);

            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Category> CreateCategory([FromBody] Category category)
        {
            var categoryCreated = _dataService.CreateCategory(category.Name,category.Description);

            return Created("Created Category",categoryCreated);
        }

        [HttpPut("{categoryId}")]
        public ActionResult<Category> UpdateCategory(int categoryId, [FromBody] Category category)
        {
            if (!_dataService.UpdateCategory(categoryId,category.Name,category.Description))
                return NotFound();
            return Ok(new Category(){Id = categoryId, Name = category.Name, Description = category.Description});
        }

        [HttpDelete("{categoryId}")]
        public ActionResult DeleteCategory(int categoryId)
        {
            if (!_dataService.DeleteCategory(categoryId))
                return NotFound();
            return Ok();
        }
    }
}
