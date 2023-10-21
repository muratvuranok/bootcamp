using BootCamp.FirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp.FirstWebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoriesController : ControllerBase
{
    static List<Category> categories = new List<Category> // database olarak düşünün
        {
            new Category { Id = 1, Name = "Category 1", Description = "Description of Category 1" },
            new Category { Id = 2, Name = "Category 2", Description = "Description of Category 2" },
            new Category { Id = 3, Name = "Category 3", Description = "Description of Category 3" },
            new Category { Id = 4, Name = "Category 4", Description = "Description of Category 4" },
            new Category { Id = 5, Name = "Category 5", Description = "Description of Category 5" },
            new Category { Id = 6, Name = "Category 6", Description = "Description of Category 6" },
            new Category { Id = 7, Name = "Category 7", Description = "Description of Category 7" },
            new Category { Id = 8, Name = "Category 8", Description = "Description of Category 8" }
        };

    [HttpGet]  // server to client
    public async Task<IActionResult> GetAll()   // Action
    {
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = categories.FirstOrDefault(x => x.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }


    [HttpPost]
    public async Task<IActionResult> Post(string categoryName, string description)
    {
        var category = new Category
        {
            Id = categories.Count + 1,
            Name = categoryName,
            Description = description
        };

        categories.Add(category);

        return Ok(category);
    }
}