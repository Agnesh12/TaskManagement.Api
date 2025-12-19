using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Common.Entities;

namespace TaskManagement.Infrastructure.Interface
{
    public interface IGenericRepository<T> where T : class
    {
       Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task<T> Delete(int id);
    }
    
}
