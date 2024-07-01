using DMStorage.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace DMStorage.Core.Service
{
    public interface IFilesService
    {
        int GetDepartmentId(string name);
        void AddMachine(Machine machine);
        public bool MachineExist(Machine newMachine);
    }
}
