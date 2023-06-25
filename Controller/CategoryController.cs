using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace API_EF.Controller;

[Route("categories")]
public class CategoryController : ControllerBase
{

    [Route("")]
    [HttpGet]
    public async Task<ActionResult<List<Category>>> MeuTodo()
    {
        return new List<Category>();
    }

    [Route("{id:int}")]
    [HttpGet]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        return new Category();
    }

    [Route("")]
    [HttpPost]
    public Category Post([FromBody] Category model)
    {
        return model;
    }


    [Route("{id:int}")]
    [HttpPut]
    public Category? Put(int id, [FromBody] Category model)
    {
        if (model.Id == id)
        {
            return model;
        }
        return null;
    }


    [Route("{id:int}")]
    [HttpDelete]
    public string Delete()
    {
        return "DELETE";
    }
}