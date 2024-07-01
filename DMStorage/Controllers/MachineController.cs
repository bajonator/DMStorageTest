using DMStorage.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using DMStorage.Persistence.Repositories;
using DMStorage.Core.ViewModels;
using DMStorage.Core.Models.Domains;
using System.Linq;
using Newtonsoft.Json;
using DMStorage.Helpers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DMStorage.Controllers
{
    [LoadUserRoles]
    [Route("machine")]
    public class MachineController : Controller
    {

        private MachineRepository _machineRepository;
        public MachineController(ApplicationDbContext context)
        {
            _machineRepository = new MachineRepository(context);
        }
        [HttpGet("base")]
        public IActionResult Base()
        {
            var model = new DepartmentsViewModel
            {
                //Departments = _machineRepository.GetDepartments(),
                //Machines = _machineRepository.GetMachines(),
            };
            return View("Views/Shared/BaseView.cshtml", model);
        }
        [HttpGet("machines")]
        public IActionResult Machines(DepartmentsViewModel departmentsViewModel)
        {
            var machines = new DepartmentsViewModel
            {
                Departments = _machineRepository.GetDepartments(departmentsViewModel.Department.Id),
                Machines = _machineRepository.GetMachines(),
            };

            return PartialView("Views/Machine/_MachineDataTablePartial.cshtml", machines);
        }
        [HttpGet("getmachines")]
        public JsonResult GetMachines()
        {
            var departments = _machineRepository.GetDepartments().Select(d => new {
                DepartmentName = d.Name, d.Number,
                Machines = d.Machines.Select(m => new {
                    m.Name,
                    m.Ip,
                    m.VLan,
                    m.MacAdress,
                    m.Id,
                    m.Original_PLC,
                    m.DMCZ_Connection,
                    m.OPC_PLC,
                    m.OPC_Driver,
                    m.Port,
                }).ToList()
            }).ToList();
            System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(departments));

            return Json(departments);
        }
        [HttpGet("GetMachinesPages")]
        public async Task<IActionResult> GetMachinesPages(int pageNumber, int pageSize)
        {
            try
            {
                var machines = await _machineRepository.GetMachinesPaged(pageNumber, pageSize);
                return Json(machines);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("machinesmanagement")]

        public IActionResult MachinesManagement()
        {
            var model = new DepartmentsViewModel
            {
                Departments = _machineRepository.GetDepartments(),
                Machines = _machineRepository.GetMachines(),
            };

            return View("Views/Machine/Machine.cshtml", model);
        }
        //public IActionResult MachinesManagement(int? pageNumber, int pageSize = 11)
        //{
        //    var departments = _machineRepository.GetDepartments();
        //    var machines = _machineRepository.GetMachines();

        //    int currentPage = pageNumber ?? 1;
        //    var paginatedMachines = machines.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        //    var totalMachinesCount = machines.Count();
        //    var totalPages = (int)Math.Ceiling(totalMachinesCount / (double)pageSize);

        //    var model = new DepartmentsViewModel
        //    {
        //        Departments = departments,
        //        Machines = paginatedMachines,
        //        CurrentPage = currentPage,
        //        TotalPages = totalPages
        //    };

        //    return View("Views/Machine/Machine.cshtml", model);
        //}
        [HttpGet("adddepartment")]

        public IActionResult AddDepartment()
        {
            var model = new DepartmentsViewModel
            {
                //Departments = _machineRepository.GetDepartments(),
                //Machines = _machineRepository.GetMachines(),
            };

            return PartialView("Views/Machine/_AddDepartmentPartial.cshtml", model);
        }
        [HttpGet("addmachine")]

        public IActionResult AddMachine(int id = 0)
        {
            var model = new DepartmentsViewModel
            {
                Departments = _machineRepository.GetDepartments(),
                //Machines = _machineRepository.GetMachines(),
                Machine = id == 0 ? new Machine() : _machineRepository.GetMachine(id)
            };
            return PartialView("Views/Machine/_AddMachinePartial.cshtml", model);
        }
        [HttpGet("addvariable")]

        public IActionResult AddVariable()
        {
            var model = new DepartmentsViewModel
            {
                //Departments = _machineRepository.GetDepartments(),
                //Machines = _machineRepository.GetMachines(),
            };

            return PartialView("Views/Machine/_AddVariablePartial.cshtml", model);
        }

        [HttpPost("department")]
        [AutoValidateAntiforgeryToken]

        public JsonResult Department(Department department)
        {
            ModelState.Remove("department.Id");
            if (!ModelState.IsValid)
            {
                var vm = new DepartmentsViewModel
                {
                    Department = department,
                    Departments = _machineRepository.GetDepartments(),
                    Machines = _machineRepository.GetMachines(),
                };
                return Json("");
            }
            if (_machineRepository.DepartmentNameExists(department.Name, department.Id))
            {
                return Json("Nazev toho oddeleni uż existuje v databazi");
            }
            if (department.Id == 0)
                _machineRepository.AddDepartment(department);
            else
                _machineRepository.UpdateDepartment(department);

            return Json("Ulozeno uspesne");
        }

        [HttpPost("machine")]
        [AutoValidateAntiforgeryToken]
        public JsonResult Machine(Machine machine)
        {
            ModelState.Remove("machine.Id");
            if (!ModelState.IsValid)
            {
                var vm = new DepartmentsViewModel
                {
                    Machine = machine,
                    Departments = _machineRepository.GetDepartments(),
                    Machines = _machineRepository.GetMachines(),
                };
                return Json("");
            }

            if (machine.Id == 0)
            {
                if (_machineRepository.MachineNameExists(machine.Name, machine.DepartmentId))
                {
                    return Json("Nazev toho stroju uż existuje v databazi.");
                }
                _machineRepository.AddMachine(machine);
            }
            else
                _machineRepository.UpdateMachine(machine);

            return Json("Ulozeno uspesne");
        }
        [HttpPost("variable")]
        [AutoValidateAntiforgeryToken]

        public JsonResult Variable(Variable variable)
        {
            ModelState.Remove("variable.Id");

            if (!ModelState.IsValid)
            {
                var vm = new DepartmentsViewModel
                {
                    Departments = _machineRepository.GetDepartments(),
                    Machines = _machineRepository.GetMachines(),
                };
                return Json("");
            }
            if (_machineRepository.VariableNameExists(variable.Name, variable.MachineId, variable.Id) && variable.Id == 0)
            {
                return Json("Prommena v tom stroji uż existuje.");
            }
            if (variable.Id == 0)
                _machineRepository.AddVariable(variable);
            else
                _machineRepository.UpdateVariable(variable);

            return Json("Ulozeno uspesne");
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _machineRepository.DeleteMachine(id);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }
    }
}
