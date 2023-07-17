using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Teste.Domain;
public class User : Entity
{
  [Key]
  [Required]
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public string? usuario { get; set; }
  [Required]
  public string? palavra { get; set; }
  [Required]
  public Role role { get; set; }
}
public enum Role {administrador,usuario}