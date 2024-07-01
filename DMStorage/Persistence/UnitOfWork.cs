using DMStorage.Core;
using DMStorage.Core.Repositories;
using DMStorage.Data;
using DMStorage.Persistence.Repositories;

namespace DMStorage.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Account = new AccountRepository(context);
            Device = new DeviceRepository(context);
            File = new FilesRepository(context);
            Machine = new MachineRepository(context);
            Lists = new ListsRepository(context);
        }

        public IAccountRepository Account { get; set; }
        public IDeviceRepository Device { get; set; }
        public IFilesRepository File { get; set; }
        public IListsRepository Lists { get; set; }
        public IMachineRepository Machine { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
