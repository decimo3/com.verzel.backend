using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Teste.Domain;
public class User : Entity
{
  [Key]
  [Required]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public string? Name { get; set; }
  [Required]
  public string? Password { get; set; }
  [Required]
  public string Roles { get; set; }
}