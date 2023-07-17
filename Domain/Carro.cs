using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Teste.Domain;
public class Carro : Entity
{
  [Required]
  public string? Nome {get; set;}
  [Required]
  public string? Marca {get; set;}
  [Required]
  public string? Foto {get; set;}
  [Required]
  public float Valor {get; set;}
}