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
    public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
    {
        var product = await context.Products.Include(category => category.category).
                            AsNoTracking().FirstOrDefaultAsync(product => product.Id == id);
        if (product != null)
        {
            return Ok(product);
        }
        return BadRequest(new { message = "Produto não encontrado" });
    }

}