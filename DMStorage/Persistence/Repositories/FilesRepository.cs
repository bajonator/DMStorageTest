using DMStorage.Core;
using DMStorage.Core.Models.Domains;
using DMStorage.Core.Repositories;
using DMStorage.Data;
using System;
using System.Linq;

namespace DMStorage.Persistence.Repositories
{
    public class FilesRepository: IFilesRepository
    {
        private IApplicationDbContext _context;
        public FilesRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public int GetDepartmentId(string name)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Name == name);
            if (department == null)
            {
                return 0;
            }
            return department.Id;
        }
        public void AddMachine(Machine machine)
        {

            _context.Machines.Add(machine);
        }

        public bool MachineExist(Machine newMachine)
        {
            var machineInDb = _context.Machines.FirstOrDefault(x => x.Name == newMachine.Name);
            if (machineInDb != null )
            {
                if (machineInDb.Name.Equals(newMachine.Name))
                {
                    return true;
                }
                return false;       
            }
            return false;
        }
    }
}
