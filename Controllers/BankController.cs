using Bank_Branch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank_Branch.Controllers
{
    public class BankController : Controller
    {

        private readonly BankContext _context;

        public BankController(BankContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var context = _context;
            return View(context.bankBranchTable.ToList());
        }
        public IActionResult Details(int id)
        {
            var context = _context;
            var banks = context.bankBranchTable.Include(r => r.Employees).SingleOrDefault(a => a.BankId == id);
            if (banks == null)
            {
                return RedirectToAction("Index");
            }
            return View(banks);
        }

        public IActionResult Search(string searchTerm)
        {
            using (var context = _context)
            {
                var branches = context.bankBranchTable.AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    branches = branches.Where(m => m.LocationName.StartsWith(searchTerm));
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
            var form = new EditBranch();
            var context = _context;
            var banks = context.bankBranchTable.SingleOrDefault(a => a.BankId == id);
            if (banks == null)
            {
                return RedirectToAction("Index");
            }
            form.BankId = banks.BankId;
            form.LocationURL = banks.LocationURL;
            form.LocationName = banks.LocationName;
            form.BranchManager = banks.BranchManager;
            form.EmployeeCount = banks.EmployeeCount;
            return View(form);
        }
        [HttpPost]
        public IActionResult Create(NewBranchForm form)
        {
            var context = _context;

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
        public IActionResult Edit(EditBranch form, int id)
        {
            var context = _context;

            var bankId = form.BankId;
            var locationName = form.LocationName;
            var locationURL = form.LocationURL;
            var branchManager = form.BranchManager;
            var employeeCount = form.EmployeeCount;
            if (ModelState.IsValid)
            {
                var bank = context.bankBranchTable.Find(id);
                if (bank != null)
                {
                    bank.BankId = bankId;
                    bank.LocationName = locationName;
                    bank.LocationURL = locationURL;
                    bank.BranchManager = branchManager;
                    bank.EmployeeCount = employeeCount;
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


        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(int id, AddEmployeeForm form)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var context = _context;

                    var name = form.Name;
                    var civilId = form.CivilId;
                    var position = form.Position;
                    var bank = context.bankBranchTable.Find(id);

                    bank.Employees.Add(new Employee
                    {
                        Name = name,
                        CivilId = civilId,
                        Position = position
                    });
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("CivilId", "This Civil id is already in the system");
                    return View(form);
                }
            }
            else
            {
                return View(form);
            }
            return RedirectToAction("Details", new { id = id });

        }

    }
}

