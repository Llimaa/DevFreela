using System;
using System.Data;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Context
{
    public interface IDB : IDisposable
    {
        Task<IDbConnection> GetConAsync();
    }
}
