using DMStorage.Core.Models.Domains;
using DMStorage.Core.Service;
using DMStorage.Data;
using DMStorage.Helpers;
using DMStorage.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace DMStorage.Controllers
{
    [LoadUserRoles]
    public class FilesController : Controller
    {
        private IFilesService _filesService;
        public FilesController(IFilesService filesService)
        {
            _filesService = filesService;
        }
        public IActionResult Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(Path.GetTempPath(), file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        var sheetNames = FileHelper.GetExcelSheetNames(stream);
                        ViewBag.SheetNames = sheetNames;
                        TempData["filePath"] = filePath;
                        return PartialView("_SelectSheetPartial", sheetNames);
                    }
                }

                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return PartialView("_ErrorPartial", ex.Message);
                }

            }
            return View("/Views/Shared/Import.cshtml");

        }
        [HttpPost]
        public IActionResult GetColumns(string sheetName, string selectedModel)
        {
            var filePath = TempData["filePath"] as string;

            if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(sheetName))
            {
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        TempData["sheetName"] = sheetName;
                        TempData["filePath"] = filePath;
                        TempData["selectedModel"] = selectedModel;
                        var columns = FileHelper.GetExcelColumnsMachine(stream, sheetName);
                        return PartialView("_SelectColumnPartial", columns);
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return PartialView("_ErrorPartial", ex.Message);
                }
            }

            TempData["Error"] = "Invalid file path or sheet name.";
            return PartialView("_ErrorPartial");
        }

        [HttpPost]
        public IActionResult PreviewData(Dictionary<string, string> columnMappings, string selectedModel)
        {
            var filePath = TempData["filePath"] as string;
            var sheetName = TempData["sheetName"] as string;

            if (!string.IsNullOrEmpty(filePath) && sheetName != null && columnMappings != null && columnMappings.Count > 0)
            {
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        object previewData = new List<object>();

                        if (selectedModel == "Machine")
                        {
                            previewData = FileHelper.GetPreviewDataMachine(stream, sheetName, columnMappings);
                            return PartialView("_PreviewMachineDataPartial", previewData);
                        }
                        else if (selectedModel == "Device")
                        {
                            previewData = FileHelper.GetPreviewDataDevice(stream, sheetName, columnMappings);
                            return PartialView("_PreviewDeviceDataPartial", previewData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return PartialView("_ErrorPartial", ex.Message);
                }
            }

            TempData["Error"] = "Invalid file path, sheet name, or column mappings.";
            return PartialView("_ErrorPartial");
        }
        [HttpPost]
        public IActionResult SaveToDatabase(List<MachineImport> machines)
        {
            var machinesNotSave = new List<Machine>();

            foreach (var machine in machines)
            {
                var newMachine = new Machine()
                {
                    DepartmentId = _filesService.GetDepartmentId(machine.DepartmentName),
                    Name = machine.MachineName,
                    Ip = machine.Ip,
                    VLan = machine.VLan,
                    MacAdress = machine.MacAdress,
                    Port = machine.Port,
                    DMCZ_Connection = machine.DMCZ_Connection,
                    OPC_Driver = machine.OPC_Driver,
                    OPC_PLC = machine.OPC_PLC,
                    Original_PLC = machine.Original_PLC             
                };

                if (newMachine.DepartmentId != 0 && !_filesService.MachineExist(newMachine))                    
                    _filesService.AddMachine(newMachine);

                else
                {
                    machinesNotSave.Add(newMachine);
                }
            }
            return PartialView("_ShowResultSavedPartial", machinesNotSave);
        }
        [HttpPost]
        public IActionResult SaveSingleMachineRowToDatabase([FromForm] MachineImport machine)
        {
            var newMachine = new Machine()
            {
                DepartmentId = _filesService.GetDepartmentId(machine.DepartmentName),
                Name = machine.MachineName,
                Ip = machine.Ip,
                VLan = machine.VLan,
                MacAdress = machine.MacAdress,
                Port = machine.Port,
                DMCZ_Connection = machine.DMCZ_Connection,
                OPC_Driver = machine.OPC_Driver,
                OPC_PLC = machine.OPC_PLC,
                Original_PLC = machine.Original_PLC
            };

            if (newMachine.DepartmentId != 0 && !_filesService.MachineExist(newMachine))
                _filesService.AddMachine(newMachine);

            return Ok();
        }
        [HttpPost]
        public IActionResult SaveSingleDeviceRowToDatabase([FromForm] DeviceImport device)
        {
            var newDevice = new Device()
            {
                //DepartmentId = _filesRepository.GetDepartmentId(machine.DepartmentName),
                //Name = machine.MachineName,
                //Ip = machine.Ip,
                //VLan = machine.VLan,
                //MacAdress = machine.MacAdress,
                //Port = machine.Port,
                //DMCZ_Connection = machine.DMCZ_Connection,
                //OPC_Driver = machine.OPC_Driver,
                //OPC_PLC = machine.OPC_PLC,
                //Original_PLC = machine.Original_PLC
            };

            //if (newDevice.DepartmentId != 0 && !_filesRepository.MachineExist(newDevice))
            //    _filesRepository.AddMachine(newDevice);

            return Ok();
        }
    }
}
