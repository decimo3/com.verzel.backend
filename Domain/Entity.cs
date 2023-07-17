using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Domain
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
