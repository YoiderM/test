﻿using CleanArch.Infra.Data.Context;
using Core.Models.Common;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class BaseIntRepository<T> : IIntRepository<T> where T : EntityWithIntId
    {
        private readonly U27ApplicationDBContext _ctx;
        private DbSet<T> _entities;
        public BaseIntRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
            _entities = ctx.Set<T>();
        }
     
        public IQueryable<T> Get()
        {
            return  _entities;
        }
        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            _entities.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Put(T entity)
        {
            _entities.Update(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> Delete(T entity)        {
           
            _entities.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
        public async Task<List<T>> AddRange(List<T> entity)
        {
            _entities.AddRange(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }
    }
}
