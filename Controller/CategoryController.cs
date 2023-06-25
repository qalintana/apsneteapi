using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public async Task<ActionResult<Category>> Post([FromBody] Category model)
    {
        if (!ModelState.IsValid)
        {
            return new BadRequestObjectResult(ModelState);
        }
        return Ok(model);
    }


    [Route("{id:int}")]
    [HttpPut]
    public async Task<ActionResult<Category?>> Put(int id, [FromBody] Category model)
    {
        if (model.Id == id)
        {
            return Ok(model);
        }
        return NotFound();
    }


    [Route("{id:int}")]
    [HttpDelete]
    public async Task<ActionResult<HttpRequest>> Delete()
    {
        return Ok();
    }
}