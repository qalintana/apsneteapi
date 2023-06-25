using Microsoft.AspNetCore.Mvc;

namespace API_EF.Controller;

[Route("categories")]
public class CategoryController : ControllerBase
{

    [Route("")]
    [HttpGet]
    public string MeuTodo()
    {
        return "Olá Mundo";
    }

    [Route("{id:int}")]
    [HttpGet]
    public string GetById(int id)
    {
        return $"Meu sistema todo funcional {id}";
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