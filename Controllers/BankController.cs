using Bank_Branch.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Branch.Controllers
{
    public class BankController : Controller
    {
        

        public IActionResult Index()
        {
            var context = new BankContext();
            return View(context.bankBranchTable.ToList());
        }
        public IActionResult Details(int id)
        {
            var context = new BankContext();
            var banks = context.bankBranchTable.SingleOrDefault(a => a.BankId == id);
            if (banks == null)
            {
                return RedirectToAction("Index");
            }
            return View(banks);
        }

        public IActionResult Search(string searchTerm)
        {
            using (var context = new BankContext())
            {
                var branches = context.bankBranchTable.AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    branches = branches.Where(b => b.LocationName.StartsWith(searchTerm));
                }

                var data = branches.ToList();
                return View("Index", data);
            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var context = new BankContext();
            var banks = context.bankBranchTable.SingleOrDefault(a => a.BankId == id);
            if (banks == null)
            {
                return RedirectToAction("Index");
            }
            return View(banks);
        }
        [HttpPost]
        public IActionResult Create(NewBranchForm form)
        {
            var context = new BankContext();

            var locationName = form.LocationName;
            var locationURL = form.LocationURL;
            var branchManager = form.BranchManager;
            var employeeCount = form.EmployeeCount;
            if (ModelState.IsValid)
            {
             
                context.bankBranchTable.Add(new BankBranch
                {
                    LocationName = locationName,
                    LocationURL = locationURL,
                    BranchManager = branchManager,
                    EmployeeCount = employeeCount
                });
                context.SaveChanges();
            }
            {
                return View(form);
            }
           

            //bankBranches.Add(new BankBranch()
            //{
            //    LocationName = locationName,
            //    LocationURL = locationURL,
            //    BranchManager = branchManager,
            //    EmployeeCount = int.Parse(employeeCount)
            //});
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form, int id)
        {
            var context = new BankContext();

            var locationName = form["LocationName"];
            var locationURL = form["LocationURL"];
            var branchManager = form["BranchManager"];
            var employeeCount = form["EmployeeCount"];
            if (ModelState.IsValid)
            {
                var bank = context.bankBranchTable.Find(id);
               if (bank != null)
                {
                    bank.LocationName = locationName;
                    bank.LocationURL = locationURL;
                    bank.BranchManager = branchManager;
                    bank.EmployeeCount = int.Parse(employeeCount);
                    context.SaveChanges();
                }
               
            }
            else
            {
                return View(form);
            }

            return RedirectToAction("Index");
        }


        //public IActionResult Edit(int id, BankBranch data)
        //{
        //    if (id != data.BankId)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        using (var context = new BankContext())
        //        {
        //            context.Update(data);
        //            context.SaveChanges();
        //        }

        //        return RedirectToAction("Index");
        //    }

        //    return View(data);
        //}


    }
}

