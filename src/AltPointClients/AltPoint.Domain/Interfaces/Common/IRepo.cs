﻿using AltPoint.Domain.Entities;

namespace AltPoint.Domain.Interfaces
{
    public interface IRepo<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        TEntity GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> GetAllSoftDeleted();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        Task<int> SaveChanges();
    }
}