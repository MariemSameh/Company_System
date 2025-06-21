using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_System.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Requiered")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description Is Requiered")]
        public string Description { get; set; }

        public List<Employee>? Employees { get; set; }
    }
}
