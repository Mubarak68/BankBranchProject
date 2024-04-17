using Bank_Branch.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Branch.Controllers
{
    public class BankController : Controller
    {
        private static List<BankBranch> bankBranches =
            [
            new BankBranch()
            {
                BankId = 1,
                LocationName = "Al-Jahra Branch",
                LocationURL = "https://maps.app.goo.gl/mPDxWzf5bcwgNCek9",
                BranchManager = "Mohammed Ali",
                EmployeeCount = 20
            },

            new BankBranch()
            {
                BankId = 2,
                LocationName = "Kaifan Branch",
                LocationURL = "https://maps.app.goo.gl/DnMgNCGQD1cpPJLFA",
                BranchManager = "Saoud Faleh",
                EmployeeCount = 18
            },
            
            new BankBranch()
            {
                BankId = 3,
                LocationName = "Al-Khaldiya Branch",
                LocationURL = "https://maps.app.goo.gl/R559DtfAFDN3f92g8",
                BranchManager = "Mubarak Mohammed",
                EmployeeCount = 24
            }, 

            new BankBranch()
            {
                BankId = 4,
                LocationName = "Farwaniya Branch",
                LocationURL = "https://maps.app.goo.gl/mmLBR5aSciF2k9q8A",
                BranchManager = "Salem Ali",
                EmployeeCount = 35
            }
            ];

        public IActionResult Index()
        {
            return View(bankBranches);
        }
        public IActionResult Details(int id)
        {
            var banks = bankBranches.SingleOrDefault(a => a.BankId == id);
            if (banks == null)
            {
                return RedirectToAction("Index");
            }
            return View(banks);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            var locationName = form["LocationName"];
            var locationURL = form["LocationURL"];
            var branchManager = form["BranchManager"];
            var employeeCount = form["EmployeeCount"];

            bankBranches.Add(new BankBranch()
            {
                LocationName = locationName,
                LocationURL = locationURL,
                BranchManager = branchManager,
                EmployeeCount = int.Parse(employeeCount)
            });
            return RedirectToAction("Index");
        }

    }
}
