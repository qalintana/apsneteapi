﻿
using API_EF.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EF.Controller;

[Route("categories")]
public class CategoryController : ControllerBase
{

    [Route("")]
    [HttpGet]
    public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
    {
        var categories = await context.Categories.AsNoTracking().ToListAsync();
        return Ok(categories);
    }

    [Route("{id:int}")]
    [HttpGet]
    public async Task<ActionResult<Category>> GetById([FromServices] DataContext context, int id)
    {
        var category = await context.Categories.FirstOrDefaultAsync(category => category.Id == id);
        if (category == null)
        {
            return BadRequest(new { message = "Categoria não encontrada" });
        }
        return Ok(category);
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
            context.Entry(model).State = EntityState.Modified;
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
    public async Task<ActionResult<HttpRequest>> Delete(int id, [FromServices] DataContext context)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null)
        {
            return NotFound(new { message = "Categoria não encontrada" });
        }

        try
        {
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return Ok(new { message = "Categoria removida com sucesso" });
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Não foi possível remover a categoria" });
        }

    }
}