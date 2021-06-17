using EmployeeService.Domain.Base;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity;
    }
}