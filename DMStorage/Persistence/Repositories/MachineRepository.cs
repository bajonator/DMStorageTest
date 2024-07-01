using DMStorage.Core;
using DMStorage.Core.Models.Domains;
using DMStorage.Core.Repositories;
using DMStorage.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMStorage.Persistence.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private IApplicationDbContext _context;
        public MachineRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Department> GetDepartments(int departmentId = 0)
        {
            var departments = _context.Departments.Include(d => d.Machines).AsQueryable();

            if (departmentId > 0)
            {
                departments = departments.Where(d => d.Id == departmentId);
            }

            return departments.ToList();
        }

        public IQueryable<Machine> GetMachines()
        {
            var machines = _context.Machines.AsQueryable();
            return machines;
        }

        public IEnumerable<Variable> GetVariables()
        {
            var variables = _context.Variables.ToList();
            return variables;
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void AddMachine(Machine machine)
        {
            _context.Machines.Add(machine);
            _context.SaveChanges();

        }

        public void AddVariable(Variable variable)
        {
            _context.Variables.Add(variable);
            _context.SaveChanges();

        }

        public void UpdateDepartment(Department department)
        {
            var departmentToUpdate = _context.Departments.FirstOrDefault(x => x.Id == department.Id);
            if (departmentToUpdate != null)
            {
                departmentToUpdate.Number = department.Number;
                departmentToUpdate.Name = department.Name;
            }
            _context.SaveChanges();

        }

        public void UpdateMachine(Machine machine)
        {
            var machineToUpdate = _context.Machines.FirstOrDefault(x => x.Id == machine.Id);
            if (machineToUpdate != null)
            {
                machineToUpdate.Name = machine.Name;
                machineToUpdate.Ip = machine.Ip;
                machineToUpdate.MacAdress = machine.MacAdress;
                machineToUpdate.VLan = machine.VLan;
                machineToUpdate.Department = machine.Department;
                machineToUpdate.DepartmentId = machine.DepartmentId;
                machineToUpdate.Original_PLC = machine.Original_PLC;
                machineToUpdate.OPC_PLC = machine.OPC_PLC;
                machineToUpdate.OPC_Driver = machine.OPC_Driver;
                machineToUpdate.Port = machine.Port;
                machineToUpdate.DMCZ_Connection = machine.DMCZ_Connection;
            }
            _context.SaveChanges();

        }

        public void UpdateVariable(Variable variable)
        {
            var variableToUpdate = _context.Variables.FirstOrDefault(x => x.Id == variable.Id);
            if (variableToUpdate != null)
            {
                variableToUpdate.Name = variable.Name;
                variableToUpdate.Machine = variable.Machine;
                variableToUpdate.MachineId = variable.MachineId;
                variableToUpdate.DataType = variable.DataType;
                variableToUpdate.Description = variable.Description;
            }
            _context.SaveChanges();

        }

        public void DeleteMachine(int id)
        {
            var machineToDelete = _context.Machines.Single(x => x.Id == id);

            _context.Machines.Remove(machineToDelete);
            _context.SaveChanges();

        }

        public Machine GetMachine(int id)
        {
            var machine = _context.Machines.FirstOrDefault(y => y.Id == id);
            return machine;
        }

        public bool DepartmentNameExists(string name, int id)
        {
            return _context.Departments.Any(d => d.Name == name);
        }

        public bool MachineNameExists(string name, int id)
        {
            return _context.Machines.Any(d => d.Name == name);
        }

        public bool VariableNameExists(string name, int machineId, int variableId)
        {
            return _context.Variables.Any(v => v.Name == name && v.MachineId == machineId && v.Id != variableId);
        }

        public async Task<IEnumerable<Machine>> GetMachinesPaged(int pageNumber, int pageSize)
        {
            var skip = (pageNumber - 1) * pageSize;
            return await _context.Machines
                                 .OrderBy(m => m.Id)
                                 .Skip(skip)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }
}

