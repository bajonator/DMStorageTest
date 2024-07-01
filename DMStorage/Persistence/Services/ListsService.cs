using DMStorage.Core;
using DMStorage.Core.Models.Domains;
using DMStorage.Core.Service;
using System.Collections.Generic;

namespace DMStorage.Persistence.Services
{
    public class ListsService : IListsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Department GetDepartment(int id)
        {
            return _unitOfWork.Lists.GetDepartment(id);
        }

        public IEnumerable<Department> GetDepartments(int id = 0)
        {
            return _unitOfWork.Lists.GetDepartments(id);
        }

        public Device GetDevice(int id)
        {
            return _unitOfWork.Lists.GetDevice(id);
        }

        public IEnumerable<Device> GetDevices()
        {
            return _unitOfWork.Lists.GetDevices();
        }

        public IEnumerable<Device> GetDevicesByDepartmentId(int departmentId)
        {
            return _unitOfWork.Lists.GetDevicesByDepartmentId(departmentId);
        }

        public IEnumerable<Device> GetDevicesByTypeDeviceId(int id)
        {
            return _unitOfWork.Lists.GetDevicesByTypeDeviceId(id);
        }

        public Machine GetMachine(int id)
        {
            return _unitOfWork.Lists.GetMachine(id);
        }

        public IEnumerable<Machine> GetMachines()
        {
            return _unitOfWork.Lists.GetMachines();
        }

        public IEnumerable<Machine> GetMachinesByDepartmentId(int departmentId)
        {
            return _unitOfWork.Lists.GetMachinesByDepartmentId(departmentId);
        }

        public TypeDevice GetTypeDevice(int id)
        {
            return _unitOfWork.Lists.GetTypeDevice(id);
        }

        public List<TypeDevice> GetTypesDevice(string query = "")
        {
            return _unitOfWork.Lists.GetTypesDevice(query);
        }

        public IEnumerable<Variable> GetVariables()
        {
            return _unitOfWork.Lists.GetVariables();
        }

        public IEnumerable<Variable> GetVariablesByMachineId(int machineId)
        {
            return _unitOfWork.Lists.GetVariablesByMachineId(machineId);
        }

        public List<Department> SearchDepartments(string query)
        {
            return _unitOfWork.Lists.SearchDepartments(query);
        }

        public List<Device> SearchDevices(string query)
        {
            return _unitOfWork.Lists.SearchDevices(query);
        }

        public List<Machine> SearchMachines(string query)
        {
            return _unitOfWork.Lists.SearchMachines(query);
        }
    }
}
