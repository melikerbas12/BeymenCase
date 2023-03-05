using BeymenCase.Data.Context;
using BeymenCase.Data.Repositories;

namespace BeymenCase.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BeymenCaseDbContext _context;
        public ISettingRepository SettingRepository { get; }

        public UnitOfWork(BeymenCaseDbContext context, ISettingRepository SettingRepository)
        {
            this._context = context;
            this.SettingRepository = SettingRepository;

        }
        public async Task<int> Complete(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}