namespace API_EF.Controller;

using API_EF.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("users")]
public class UserController : Controller
{


    [HttpPost]
    [Route("")]
    [AllowAnonymous]
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

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> Authenticate([FromServices] DataContext context,
            [FromBody] User model)
    {

        var user = await context.Users.AsNoTracking()
                .Where(x => x.Username == model.Username && x.password == model.password)
                .SingleOrDefaultAsync();

        if (user == null)
        {
            return BadRequest(new { message = "Usuário ou senha inválidos" });
        }

        var token = TokenService.GenerateToken(user);
        return new
        {
            user,
            token
        };


    }
}