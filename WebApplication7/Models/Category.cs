using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication7.Models
{
    [Table("Categories")] // <-- tabla real en el .sqlite del profe
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        // OJO: en tu DB Browser revisa el nombre exacto de esta columna.
        // Si se llama distinto, lo cambiamos.
        public string CategoryName { get; set; }
    }
}