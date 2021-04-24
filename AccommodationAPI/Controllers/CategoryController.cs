using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccommodationAPI.APIModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DataModels;
using Services.Interfaces;

namespace AccommodationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("add-update-category")]
        public IActionResult AddOrUpdateCategory(CategoryDBModel categoryDBModel)
        {
            BasicResponse basicResponse = new BasicResponse();
            basicResponse.Data = _categoryService.AddOrUpdateCategory(categoryDBModel);
            return Ok(basicResponse);
        }
        [HttpGet]
        [Route("all-categories")]
        public IActionResult CategoriesList()
        {
            BasicResponse basicResponse = new BasicResponse();
            basicResponse.Data = _categoryService.GetCategories();
            return Ok(basicResponse);
        }
    }
}
