using DMStorage.Core;
using DMStorage.Core.Models.Domains;
using DMStorage.Core.Repositories;
using DMStorage.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DMStorage.Persistence.Repositories
{
    public class ListsRepository : IListsRepository
    {
        private IApplicationDbContext _context;

        public ListsRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetDepartments(int id = 0)
        {
            var departments = _context.Departments.ToList();
            return departments;
        }
        public Department GetDepartment(int id)
        {
            return _context.Departments.SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<Machine> GetMachinesByDepartmentId(int departmentId)
        {
            return _context.Machines.Where(m => m.DepartmentId == departmentId).ToList();
        }
        public IEnumerable<Device> GetDevicesByDepartmentId(int departmentId)
        {
            return _context.Devices.Where(m => m.DepartmentId == departmentId).ToList();
        }
        public IEnumerable<Device> GetDevices()
        {
            var devices = _context.Devices.ToList();
            return devices;
        }
        public IEnumerable<Machine> GetMachines()
        {
            var machines = _context.Machines.ToList();
            return machines;
        }
        public List<TypeDevice> GetTypesDevice(string query = "")
        {
            if (query == "")
            {
                var types = _context.TypeDevices.ToList();
                return types;
            }
            else
            {
                var types = _context.TypeDevices.Where(x => x.Name.Contains(query)).ToList();
                return types;
            }
        }
        public IEnumerable<Variable> GetVariables()
        {
            var variables = _context.Variables.ToList();
            return variables;
        }
        public Machine GetMachine(int id)
        {
            return _context.Machines.SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<Variable> GetVariablesByMachineId(int machineId)
        {
            return _context.Variables.Where(m => m.MachineId == machineId).ToList();
        }
        public TypeDevice GetTypeDevice(int id)
        {
            return _context.TypeDevices
                .Include(x => x.Devices)
                .ThenInclude(d => d.Department)
                .Include(x => x.Devices)
                .ThenInclude(d => d.Machine).SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<Device> GetDevicesByTypeDeviceId(int id)
        {
            return _context.Devices.Include(x => x.TypeDevice).Where(m => m.TypeDeviceId == id).ToList();
        }
        public Device GetDevice(int id)
        {
            return _context.Devices.SingleOrDefault(x => x.Id == id);
        }
        public List<Device> SearchDevices(string query)
        {
            return _context.Devices
                .Where(d => d.Name.Contains(query) ||
                    d.MacAdress.Contains(query) ||
                    d.Ip.Contains(query) ||
                    d.WPAUserName.Contains(query) ||
                    d.WPAPassword.Contains(query) ||
                    d.State.Contains(query) ||
                    d.InventoryNumber.Contains(query) ||
                    d.SerialNumber.Contains(query) ||
                    d.Department.Name.Contains(query) ||
                    d.TypeDevice.Name.Contains(query))
                .Include(m => m.TypeDevice)
                .Include(x => x.Department)
                .Include(x => x.Machine)
                .ToList();
        }
        public List<Department> SearchDepartments(string query)
        {
            return _context.Departments
                .Where(d => d.Name.Contains(query) ||
                    d.Number.Contains(query))
                .ToList();
        }
        public List<Machine> SearchMachines(string query)
        {
            var machines = _context.Machines
                    .Where(d => d.Name.Contains(query) ||
                        d.Ip.Contains(query) ||
                        d.MacAdress.Contains(query) ||
                        d.Original_PLC.Contains(query) ||
                        d.VLan.Contains(query) ||
                        d.OPC_Driver.Contains(query) ||
                        d.OPC_PLC.Contains(query) ||
                        d.DMCZ_Connection.Contains(query) ||
                        d.Port.Contains(query) ||
                        d.Department.Name.Contains(query))
                    .Include(m => m.Department)
                    .ToList();

            return machines;
        }
    }
}

