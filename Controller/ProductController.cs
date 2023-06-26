using API_EF.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EF.Controller;

[Route("products")]
public class ProductController : ControllerBase
{

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
    {
        var products = await context.Products.Include(x => x.category).AsNoTracking().ToListAsync();
        return Ok(products);
    }


    [HttpGet]
    [Route("categories/{id:int}")]
    public async Task<ActionResult<Product>> GetBy([FromServices] DataContext context, int id)
    {
        var product = await context.Products.Include(c => c.category).
                            AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        if (product != null)
        {
            return Ok(product);
        }
        return BadRequest(new { message = "Produto não encontrado" });
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Product>> GetByCategory([FromServices] DataContext context, int id)
    {
        var product = await context.Products.
                            Include(c => c.category).
                            AsNoTracking().Where(c => c.CategoryId == id).ToListAsync();
        if (product != null)
        {
            return Ok(product);
        }
        return BadRequest(new { message = "Produto não encontrado" });
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Product>> Post([FromServices] DataContext context, [FromBody] Product model)
    {
        if (ModelState.IsValid)
        {
            context.Products.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

}