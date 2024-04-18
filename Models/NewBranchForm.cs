using System.ComponentModel.DataAnnotations;

namespace Bank_Branch.Models
{
    public class NewBranchForm
    {
        [Required]
        [Display (Name ="Location Name: ")]
        public string LocationName { get; set; }

        [Required]
        [Display(Name = "Location Link: ")]
        public string LocationURL { get; set; }

        [StringLength(100)]
        [Display(Name = "Branch Manager: ")]
        public string BranchManager { get; set; }

        [Range(1,100)]
        [Display(Name = "Employee Count: ")]
        public int EmployeeCount { get; set; }
    }
}
