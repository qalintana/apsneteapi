
using API_EF.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EF.Controller;

[Route("categories")]
public class CategoryController : ControllerBase
{

    [Route("")]
    [HttpGet]
    public async Task<ActionResult<List<Category>>> Index()
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
    public async Task<ActionResult<Category>> Post(
                [FromBody] Category model,
                [FromServices] DataContext context)
    {
        if (!ModelState.IsValid)
        {
            return new BadRequestObjectResult(ModelState);
        }

        try
        {
            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return BadRequest(new { Message = "Não foi possivel criar uma categoria" });
        }


    }

    [Route("{id:int}")]
    [HttpPut]
    public async Task<ActionResult<Category?>> Put(int id,
                [FromBody] Category model,
                [FromServices] DataContext context)
    {
        if (id != model.Id)
        {
            return NotFound(new { message = "Categoria não encontrada" });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            context.Entry<Category>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return model;
        }
        catch (DbUpdateConcurrencyException)
        {

            return BadRequest(new { message = "Não foi possivel atualizar" });
        }
    }


    [Route("{id:int}")]
    [HttpDelete]
    public async Task<ActionResult<HttpRequest>> Delete()
    {
        return Ok();
    }
}