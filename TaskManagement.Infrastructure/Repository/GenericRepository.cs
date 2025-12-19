using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Common.Entities;
using TaskManagement.Data;
using TaskManagement.Infrastructure.Interface;

namespace TaskManagement.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TaskManagementContext _Context;
        private readonly DbSet<T> dbset;
        public GenericRepository(TaskManagementContext _Context)
        {
            this._Context = _Context;
            this.dbset = _Context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbset.ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
           return await dbset.FindAsync(id);
        }
        public async Task<T> Insert(T obj)
        {
            await dbset.AddAsync(obj);
            await _Context.SaveChangesAsync();
            return obj;
        }
        public async Task<T> Update(T obj)
        {
            dbset.Attach(obj);
            _Context.Entry(obj).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return obj;
        }
        public async Task<T> Delete(int id)
        {
            T existing = await dbset.FindAsync(id);
            dbset.Remove(existing);
            await _Context.SaveChangesAsync();
            return existing;
        }
    }
}
