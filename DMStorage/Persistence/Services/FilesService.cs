using DMStorage.Core;
using DMStorage.Core.Models.Domains;
using DMStorage.Core.Service;

namespace DMStorage.Persistence.Services
{
    public class FilesService : IFilesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FilesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddMachine(Machine machine)
        {
            _unitOfWork.File.AddMachine(machine);
        }

        public int GetDepartmentId(string name)
        {
            return _unitOfWork.File.GetDepartmentId(name);
        }

        public bool MachineExist(Machine newMachine)
        {
            return _unitOfWork.File.MachineExist(newMachine);
        }
    }
}
