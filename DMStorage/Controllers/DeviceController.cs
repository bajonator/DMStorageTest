using DMStorage.Core.Models.Domains;
using DMStorage.Core.Service;
using DMStorage.Core.ViewModels;
using DMStorage.Data;
using DMStorage.Helpers;
using DMStorage.Persistence;
using DMStorage.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace DMStorage.Controllers
{
    [LoadUserRoles]

    public class DeviceController : Controller
    {
        private IDeviceService _deviceService;
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        public IActionResult Index()
        {
            var model = new DevicesViewModel
            {
                
                Devices = _deviceService.GetDevices(),
                Departments = _deviceService.GetDepartments(),
                TypeDevices = _deviceService.GetTypes(),  
            };
            return View("Views/Device/Device.cshtml", model);
        }
        public IActionResult Devices(DevicesViewModel devicesViewModel)
        {
            var devices = new DevicesViewModel
            {
                TypeDevices = _deviceService.GetTypes(devicesViewModel.TypeDevice.Id),
                Devices = _deviceService.GetDevices(),
            };
            return PartialView("Views/Device/_DeviceDataTablePartial.cshtml", devices);
        }
        public JsonResult GetDevices()
        {
            var typeDevices = _deviceService.GetTypes().Select(t => new {
                TypeName = t.Name,
                Devices = t.Devices.Select(d => new {
                    d.Name,
                    d.Ip,
                    d.MacAdress,
                    d.Description,
                    d.Id,
                    d.SerialNumber,
                    d.State,
                    d.InventoryNumber,
                    d.WPAPassword,
                    d.WPAUserName,
                    DepartmentName = d.Department?.Name,
                    MachineName = d.Machine?.Name,
                }).ToList()
            }).ToList();
            System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(typeDevices));

            return Json(typeDevices);
        }
        public IActionResult AddTypeDevice()
        {
            var model = new DevicesViewModel
            {
                Departments = _deviceService.GetDepartments(),
            };

            return PartialView("Views/Device/_AddTypeDevicePartial.cshtml", model);
        }
        public IActionResult DevicesManagement()
        {
            var model = new DevicesViewModel
            {
                Departments = _deviceService.GetDepartments(),
                TypeDevices = _deviceService.GetTypes(),
                Devices = _deviceService.GetDevices()
            };

            return View("Views/Device/Device.cshtml", model);
        }
        public IActionResult AddDevice(int id = 0)
        {
            var model = new DevicesViewModel
            {
                Departments = _deviceService.GetDepartments(),
                TypeDevices = _deviceService.GetTypes(),
                Machines = _deviceService.GetMachines(),
                Device = id == 0 ? new Device() : _deviceService.GetDevice(id)
            };

            return PartialView("Views/Device/_AddDevicePartial.cshtml", model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult Device(Device device)
        {
            ModelState.Remove("device.Id");
            if (!ModelState.IsValid)
            {
                var vm = new DevicesViewModel
                {
                    Device = device,
                    Departments = _deviceService.GetDepartments(),
                    TypeDevices = _deviceService.GetTypes(),
                };
                return Json("");
            }
            if (_deviceService.DeviceNameExists(device.Name, device.TypeDeviceId, device.Id) && device.Id == 0)
            {
                return Json("Nazev toho zarizeni existuje v databazi.");
            }
            if (device.Id == 0)
                _deviceService.AddDevice(device);
            else
                _deviceService.UpdateDevice(device);

            return Json("Ulozeno uspesne");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult TypeDevice(TypeDevice typeDevice)
        {
            ModelState.Remove("typeDevice.Id");
            if (!ModelState.IsValid)
            {
                var vm = new DevicesViewModel
                {
                    TypeDevice = typeDevice,
                };
                return Json("");
            }
            if (_deviceService.TypeDeviceNameExists(typeDevice.Name))
            {
                return Json("Nazev typu zarizeni uż existuje v databazi.");
            }
            if (typeDevice.Id == 0)
                _deviceService.AddTypeDevice(typeDevice);
            else
                _deviceService.UpdateTypeDevice(typeDevice);

            return Json("Ulozeno uspesne");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _deviceService.DeleteDevice(id);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }
    }
}
