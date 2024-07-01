using DMStorage.Core.Models.Domains;
using System.Collections.Generic;
using System.Linq;

namespace DMStorage.Core.Service
{
    public interface IMachineService
    {
        IEnumerable<Department> GetDepartments(int departmentId = 0);
        IQueryable<Machine> GetMachines();
        IEnumerable<Variable> GetVariables();
        void AddDepartment(Department department);
        void AddMachine(Machine machine);
        void AddVariable(Variable variable);
        void UpdateDepartment(Department department);
        void UpdateMachine(Machine machine);
        void UpdateVariable(Variable variable);
        void DeleteMachine(int id);
        Machine GetMachine(int id);
        bool DepartmentNameExists(string name, int id);
        bool MachineNameExists(string name, int id);
        bool VariableNameExists(string name, int machineId, int variableId);
    }
}
