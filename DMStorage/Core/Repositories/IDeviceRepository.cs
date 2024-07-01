using DMStorage.Core.Models.Domains;
using System.Collections.Generic;

namespace DMStorage.Core.Repositories
{
    public interface IDeviceRepository
    {
        IEnumerable<Department> GetDepartments();
        Device GetDevice(int id);
        IEnumerable<Device> GetDevices();
        IEnumerable<TypeDevice> GetTypes(int deviceId = 0);
        void AddDevice(Device device);
        void AddTypeDevice(TypeDevice typeDevice);
        void UpdateDevice(Device device);
        void UpdateTypeDevice(TypeDevice typeDevice);
        void DeleteDevice(int id);
        bool DeviceNameExists(string name, int typeDeviceId, int id);
        bool TypeDeviceNameExists(string name);
        IEnumerable<Machine> GetMachines();
    }
}
