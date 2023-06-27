namespace API_EF.Controller;

using API_EF.Data;
using Microsoft.AspNetCore.Mvc;

[Route("users")]
public class UserController : Controller
{

    public async Task<ActionResult<User>> Post(
        [FromServices] DataContext context,
        [FromBody] User model
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            context.Users.Add(model);
            await context.SaveChangesAsync();
            return model;
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Não foi possível criar usuário" });
        }
    }
}