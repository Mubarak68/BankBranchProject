namespace Bank_Branch.Models
{
    public class BankDashboardViewModel
    {
        public int TotalBranches { get; set; }
        public int TotalEmployee { get; set; }
        public BankBranch BranchWithMostEmployee { get; set;}
        public List<BankBranch> BranchList { get; set; }
    }
}
