using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace backend.Models;
public class Carro
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id {get; set;}
  [Required]
  public string? Nome {get; set;}
  [Required]
  public string? Marca {get; set;}
  [Required]
  public string? Foto {get; set;}
  [Required]
  public float Valor {get; set;}
}