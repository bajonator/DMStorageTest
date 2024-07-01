using DMStorage.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DMStorage.Core.Repositories
{
    public interface IListsRepository
    {
        IEnumerable<Department> GetDepartments(int id = 0);
        Department GetDepartment(int id);
        IEnumerable<Machine> GetMachinesByDepartmentId(int departmentId);
        IEnumerable<Device> GetDevicesByDepartmentId(int departmentId);
        IEnumerable<Device> GetDevices();
        IEnumerable<Machine> GetMachines();
        List<TypeDevice> GetTypesDevice(string query = "");
        IEnumerable<Variable> GetVariables();
        Machine GetMachine(int id);
        IEnumerable<Variable> GetVariablesByMachineId(int machineId);
        TypeDevice GetTypeDevice(int id);
        IEnumerable<Device> GetDevicesByTypeDeviceId(int id);
        Device GetDevice(int id);
        List<Device> SearchDevices(string query);
        List<Department> SearchDepartments(string query);
        List<Machine> SearchMachines(string query);
    }
}
