using System.ComponentModel.DataAnnotations;
using System.Net;
using BootCamp.FirstWebApi.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp.FirstWebApi.Controllers;

[ApiController]
// [Route("api/v1/[controller]/[action]")]
[Route("api/v1/[controller]")]
public class CategoriesController : ControllerBase
{

    private IValidator<CategoryCreateInput> _categoryCreateInputValidator;
    public CategoriesController(IValidator<CategoryCreateInput> categoryCreateInputValidator)
    {
        this._categoryCreateInputValidator = categoryCreateInputValidator;
    }

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
    //http://localhost:5201/api/v1/Categories/GetAll
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
    public async Task<IActionResult> Post(CategoryCreateInput model)
    {

        var result = await _categoryCreateInputValidator.ValidateAsync(model);
 
        if (!result.IsValid)
        {
            return Ok(result.Errors);
        }
 
        // if (ModelState.IsValid)
        // {
        //     var category = new Category
        //     {
        //         Id = categories.Count + 1,
        //         Name = model.Name,
        //         Description = model.Description
        //     };

        //     categories.Add(category);
        //     return Ok(category);
        // }

        // return Ok(HttpStatusCode.BadRequest);

        return Ok(model);
    }

    [HttpPut]
    public async Task<IActionResult> Put(CategoryEditInput category)
    {
        var currentCategory = categories.FirstOrDefault(x => x.Id == category.Id);  // database içerisnde yer alan kategoriyi alıyoruz
        if (currentCategory == null)
        {
            return Ok(HttpStatusCode.NotFound);
        }

        // categories.Remove(currentCategory); 
        currentCategory.Name = category.Name;
        currentCategory.Description = category.Description;
        // categories.Add(currentCategory);

        return Ok(currentCategory);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) // x
    {
        var category = categories.FirstOrDefault(x => x.Id == id);  // x.CaregoryName.Contains("kola")  

        if (category != null)
        {
            categories.Remove(category);
            return Ok(HttpStatusCode.OK);
        }

        return Ok(HttpStatusCode.NotFound);
    }

    // [HttpDelete("{id}/{cName}")]
    // public async Task<IActionResult> DeleteSecond(int id, string cName) // x
    // {
    //     var category = categories.FirstOrDefault(x => x.Id == id);  // x.CaregoryName.Contains("kola")  

    //     if (category != null)
    //     {
    //         categories.Remove(category);
    //         return Ok(HttpStatusCode.OK);
    //     }

    //     return Ok(HttpStatusCode.NotFound);
    // }
}




/*


MVC  ->    www.deneme.com/categories/(Index, Edit, Delete, Add) - list vs. 
API  ->    www.deneme.com/categories (Get, Put, Delete, Post) - list vs.


*/