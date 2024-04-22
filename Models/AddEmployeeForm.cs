using System.ComponentModel.DataAnnotations;

namespace Bank_Branch.Models
{
    public class AddEmployeeForm
    {
        [Required]
        public string Name { get; set; }
        [Required (ErrorMessage ="The civil id is already existed")]
        public int CivilId { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
