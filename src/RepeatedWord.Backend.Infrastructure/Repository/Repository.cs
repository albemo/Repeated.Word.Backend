﻿using RepeatedWord.Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedWord.Backend.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext context )
        {
            _dbContext = context;
        }

        public async Task<IList<T>> GetAllAsync() => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbContext.FindAsync<T>(id);

        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public IQueryable<T> Query() => _dbContext.Set<T>();

        public IQueryable<T> QueryNoTracking() => _dbContext.Set<T>().AsNoTracking();
    }
}
