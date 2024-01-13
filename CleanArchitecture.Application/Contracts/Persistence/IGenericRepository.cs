
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    //Acciones compartidas entre las distintas entidades ⬇️
    //Ejemplo: CRUD
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetAsync(int id);
    Task<T> GetByIdAsync(int id);
}
