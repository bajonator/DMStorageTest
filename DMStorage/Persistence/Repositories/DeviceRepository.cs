using DMStorage.Core;
using DMStorage.Core.Models.Domains;
using DMStorage.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DMStorage.Persistence.Repositories
{
    public class DeviceRepository: IDeviceRepository
    {
        private IApplicationDbContext _context;
        public DeviceRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetDepartments()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }
        public Device GetDevice(int id)
        {
            var device = _context.Devices.FirstOrDefault(x => x.Id == id);
            return device;
        }

        public IEnumerable<Device> GetDevices()
        {
            var devices = _context.Devices.Include(d => d.Department).Include(m => m.Machine).ToList();
            return devices;
        }

        public IEnumerable<TypeDevice> GetTypes(int deviceId = 0)
        {
            var typeDevices = _context.TypeDevices
                .Include(x => x.Devices)
                .ThenInclude(d => d.Department)
                .Include(x => x.Devices)
                .ThenInclude(d => d.Machine)
                .AsQueryable();

            if (deviceId > 0)
            {
                typeDevices = typeDevices.Where(d => d.Id == deviceId);
            }

            return typeDevices.ToList();
        }

        public void AddDevice(Device device)
        {
            _context.Devices.Add(device);
        }

        public void AddTypeDevice(TypeDevice typeDevice)
        {
            _context.TypeDevices.Add(typeDevice);
        }

        public void UpdateDevice(Device device)
        {
            var deviceToUpdate = _context.Devices.FirstOrDefault(x => x.Id == device.Id);
            if (deviceToUpdate != null)
            {
                deviceToUpdate.Description = device.Description;
                deviceToUpdate.Name = device.Name;
                deviceToUpdate.Ip = device.Ip;
                deviceToUpdate.MacAdress = device.MacAdress;
                deviceToUpdate.TypeDevice = device.TypeDevice;
                deviceToUpdate.DepartmentId = device.DepartmentId;
                deviceToUpdate.InventoryNumber = device.InventoryNumber;
                deviceToUpdate.SerialNumber = device.SerialNumber;
                deviceToUpdate.WPAPassword = device.WPAPassword;
                deviceToUpdate.WPAUserName = device.WPAUserName;
                deviceToUpdate.MachineId = device.MachineId;
                deviceToUpdate.State = device.State;

            }
        }

        public void UpdateTypeDevice(TypeDevice typeDevice)
        {
            var typeToUpdate = _context.TypeDevices.FirstOrDefault(x => x.Id == typeDevice.Id);
            if (typeToUpdate != null)
            {
                typeToUpdate.Name = typeDevice.Name;
            }
        }

        public void DeleteDevice(int id)
        {
            var deviceToDelete = _context.Devices.Single(x => x.Id == id);

            _context.Devices.Remove(deviceToDelete);
        }

        public bool DeviceNameExists(string name, int typeDeviceId, int id)
        {
            return _context.Devices.Any(x => x.Name == name);
        }

        public bool TypeDeviceNameExists(string name)
        {
            return _context.TypeDevices.Any(x => x.Name == name);
        }

        public IEnumerable<Machine> GetMachines()
        {
            var machines = _context.Machines.ToList();
            return machines;
        }
    }
}
