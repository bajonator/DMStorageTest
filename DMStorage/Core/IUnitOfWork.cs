using DMStorage.Core.Repositories;
using DMStorage.Persistence.Repositories;

namespace DMStorage.Core
{
    public interface IUnitOfWork
    {
        IAccountRepository Account { get; }
        IDeviceRepository Device { get; }
        IFilesRepository File { get; }
        IListsRepository Lists { get; }
        IMachineRepository Machine { get; }
        void Complete();
    }
}
