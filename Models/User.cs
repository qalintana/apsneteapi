using System.ComponentModel.DataAnnotations;

namespace API_EF;

public class User
{
    
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatorio")]
    [MaxLength(20, ErrorMessage = "Este campo deve conter no minimo 3 e 60 no maximo")]
    [MinLength(3, ErrorMessage = "Este campo deve conter no minimo 3 e 60 no maximo")]
    public string Username { get; set; }  
    
    [Required(ErrorMessage = "Este campo é obrigatorio")]
    [MaxLength(20, ErrorMessage = "Este campo deve conter no minimo 3 e 60 no maximo")]
    [MinLength(3, ErrorMessage = "Este campo deve conter no minimo 3 e 60 no maximo")]
    public string password { get; set; }
    
    public string Role { get; set; }
}