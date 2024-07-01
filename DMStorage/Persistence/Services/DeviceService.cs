using DMStorage.Core;
using DMStorage.Core.Models.Domains;
using DMStorage.Core.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DMStorage.Persistence.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeviceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _unitOfWork.Device.GetDepartments();
        }
        public Device GetDevice(int id)
        {
            return _unitOfWork.Device.GetDevice(id);
        }

        public IEnumerable<Device> GetDevices()
        {
            return _unitOfWork.Device.GetDevices();
        }

        public IEnumerable<TypeDevice> GetTypes(int deviceId = 0)
        {
            return _unitOfWork.Device.GetTypes(deviceId);
        }

        public void AddDevice(Device device)
        {
             _unitOfWork.Device.AddDevice(device);
            _unitOfWork.Complete();
        }

        public void AddTypeDevice(TypeDevice typeDevice)
        {
            _unitOfWork.Device.AddTypeDevice(typeDevice);
            _unitOfWork.Complete();
        }

        public void UpdateDevice(Device device)
        {
            _unitOfWork.Device.UpdateDevice(device);
            _unitOfWork.Complete();
        }

        public void UpdateTypeDevice(TypeDevice typeDevice)
        {
            _unitOfWork.Device.UpdateTypeDevice(typeDevice);
            _unitOfWork.Complete();
        }

        public void DeleteDevice(int id)
        {
            _unitOfWork.Device.DeleteDevice(id);
        }

        public bool DeviceNameExists(string name, int typeDeviceId, int id)
        {
            return _unitOfWork.Device.DeviceNameExists(name, typeDeviceId, id);
        }

        public bool TypeDeviceNameExists(string name)
        {
            return _unitOfWork.Device.TypeDeviceNameExists(name);
        }

        public IEnumerable<Machine> GetMachines()
        {
            return _unitOfWork.Device.GetMachines();
        }
    }
}
