using System.ComponentModel.DataAnnotations;

namespace API_EF;

public class Category
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatorio demais")]
    [MaxLength(60, ErrorMessage = "Este campo mais deve conter entre 3 a 60 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 a 60 caracteres")]
    [DataType("nvarchar")]
    public string Title { get; set; }
}