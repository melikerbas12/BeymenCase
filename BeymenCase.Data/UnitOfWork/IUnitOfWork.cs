using System;
using System.Threading.Tasks;
using BeymenCase.Data.Repositories;
using SahaBT.Retro.Data.Repositories;

namespace BeymenCase.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISettingRepository SettingRepository { get; }
        Task<int> Complete(CancellationToken cancellationToken);
    }
}