using DMStorage.Core.Models.Domains;
using DMStorage.Core.Service;
using DMStorage.Core.ViewModels;
using DMStorage.Data;
using DMStorage.Helpers;
using DMStorage.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DMStorage.Controllers
{
    [LoadUserRoles]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IListsService _listsService;

        public HomeController(ILogger<HomeController> logger, IListsService listsService)
        {
            _logger = logger;
            _listsService = listsService;
        }
        [CustomAuthorize]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Base", "Machine");
            }
            return View();
        }

        public IActionResult LoadLoginPartial()
        {
            return PartialView("/Views/User/_LoginPartial.cshtml");
        }

        public IActionResult LoadRegisterPartial()
        {
            return PartialView("/Views/User/_RegisterPartial.cshtml");
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            return RedirectToAction("Base", "Machine");
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Lists()
        {
            var model = new ListsViewModel
            {
                Departments = _listsService.GetDepartments(),
                Machines = _listsService.GetMachines(),
                TypeDevices = _listsService.GetTypesDevice(),
                Devices = _listsService.GetDevices(),
                Variables = _listsService.GetVariables()
            };

            return View("ListBase", model);
        }
        public IActionResult Details(string type, int id)
        {
            if (type == "department")
            {
                var department = _listsService.GetDepartment(id);
                if (department == null)
                {
                    return NotFound();
                }

                var machines = _listsService.GetMachinesByDepartmentId(id);
                var devices = _listsService.GetDevicesByDepartmentId(id);
                var viewModel = new DepartmentViewModel
                {
                    Department = department,
                    Machines = machines,
                    Devices = devices                    
                };
                TempData["DepartmentId"] = department.Id;

                return View("/Views/Home/DepartmentDetails.cshtml", viewModel);
            }
            else if (type == "machine")
            {
                var machine = _listsService.GetMachine(id);
                if (machine == null)
                {
                    return NotFound();
                }

                var department = _listsService.GetDepartment(machine.DepartmentId);
                var variables = _listsService.GetVariablesByMachineId(id);

                var viewModel = new MachineViewModel
                {
                    Machine = machine,
                    Department = department,
                    Variables = variables
                };

                TempData["DepartmentId"] = department.Id;

                return View("/Views/Home/MachineDetails.cshtml", viewModel);
            }
            else if (type == "deviceType")
            {
                var typeDevice = _listsService.GetTypeDevice(id);
                if (typeDevice == null)
                {
                    return NotFound();
                }

                var devices = _listsService.GetDevicesByTypeDeviceId(id);

                var viewModel = new DeviceViewModel
                {
                    TypeDevice = typeDevice,
                    Devices = devices,
                };


                return View("/Views/Home/TypeDeviceDetails.cshtml", viewModel);
            }
            else if (type == "device")
            {
                var device = _listsService.GetDevice(id);
                if (device == null)
                {
                    return NotFound();
                }

                var typeDevice = _listsService.GetTypeDevice(device.TypeDeviceId);

                var viewModel = new DeviceViewModel
                {
                    TypeDevice = typeDevice,
                    Device = device,
                };

                TempData["typeDeviceId"] = typeDevice.Id;

                return View("/Views/Home/DeviceDetails.cshtml", viewModel);
            }
            return BadRequest();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Upload()
        {
            return RedirectToAction("Upload", "Files");
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(new List<Device>());
            }

            var typeDeviceResults = _listsService.GetTypesDevice(query);

            var deviceResults = _listsService.SearchDevices(query);

            var departmentResults = _listsService.SearchDepartments(query);

            var machineResults = _listsService.SearchMachines(query);

            var results = new SearchViewModel
            {
                TypeDevices = typeDeviceResults,
                Devices = deviceResults,
                Departments = departmentResults,
                Machines = machineResults
            };

            return PartialView("/Views/Shared/_SearchResultsPartial.cshtml", results);
        }
        public IActionResult SearchView()
        {
            return View("/Views/Shared/Search.cshtml");
        }

    }
}
