using DMStorage.Core;
using DMStorage.Core.Models.Domains;
using DMStorage.Core.Service;
using System.Collections.Generic;
using System.Linq;

namespace DMStorage.Persistence.Services
{
    public class MachineService : IMachineService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MachineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddDepartment(Department department)
        {
            _unitOfWork.Machine.AddDepartment(department);
            _unitOfWork.Complete();
        }

        public void AddMachine(Machine machine)
        {
            _unitOfWork.Machine.AddMachine(machine);
            _unitOfWork.Complete();
        }

        public void AddVariable(Variable variable)
        {
            _unitOfWork.Machine.AddVariable(variable);
            _unitOfWork.Complete();
        }

        public void DeleteMachine(int id)
        {
            _unitOfWork.Machine.DeleteMachine(id);
            _unitOfWork.Complete();
        }

        public bool DepartmentNameExists(string name, int id)
        {
            return _unitOfWork.Machine.DepartmentNameExists(name, id);
        }

        public IEnumerable<Department> GetDepartments(int departmentId = 0)
        {
            return _unitOfWork.Machine.GetDepartments(departmentId);
        }

        public Machine GetMachine(int id)
        {
            return _unitOfWork.Machine.GetMachine(id);
        }

        public IQueryable<Machine> GetMachines()
        {
            return _unitOfWork.Machine.GetMachines();
        }

        public IEnumerable<Variable> GetVariables()
        {
            return _unitOfWork.Machine.GetVariables();
        }

        public bool MachineNameExists(string name, int id)
        {
            return _unitOfWork.Machine.MachineNameExists(name, id);
        }

        public void UpdateDepartment(Department department)
        {
            _unitOfWork.Machine.UpdateDepartment(department);
            _unitOfWork.Complete();
        }

        public void UpdateMachine(Machine machine)
        {
            _unitOfWork.Machine.UpdateMachine(machine);
            _unitOfWork.Complete();
        }

        public void UpdateVariable(Variable variable)
        {
            _unitOfWork.Machine.UpdateVariable(variable);
            _unitOfWork.Complete();
        }

        public bool VariableNameExists(string name, int machineId, int variableId)
        {
            return _unitOfWork.Machine.VariableNameExists(name, machineId, variableId);
        }
    }
}
