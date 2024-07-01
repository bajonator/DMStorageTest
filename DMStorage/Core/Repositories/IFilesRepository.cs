using DMStorage.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace DMStorage.Core.Repositories
{
    public interface IFilesRepository
    {
        int GetDepartmentId(string name);
        void AddMachine(Machine machine);
        bool MachineExist(Machine newMachine);
    }
}
