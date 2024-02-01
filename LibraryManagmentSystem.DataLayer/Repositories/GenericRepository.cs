﻿

using LibraryManagmentSystem.DataLayer.Context;
using LibraryManagmentSystem.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagmentSystem.DataLayer.Repositories;

public abstract class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
    where TEntity : BaseEntity
{
    private readonly LibraryDbContext _context;

    public GenericRepository(LibraryDbContext context) =>
        _context = context;

    public virtual async ValueTask<TEntity> InsertAsync(
        TEntity entity)
    {
        var entityEntry = await _context.AddAsync<TEntity>(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public virtual IQueryable<TEntity> SelectAll() =>
        _context.Set<TEntity>().Where(s => !s.IsDeleted);

    public virtual async ValueTask<TEntity?> SelectByIdAsync(TKey id) =>
        await _context.Set<TEntity>().FindAsync(id);

    public virtual async ValueTask<TEntity?> SelectByIdWithDetailsAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
    {
        IQueryable<TEntity> entities = this.SelectAll();

        foreach (var include in includes)
        {
            entities = entities.Include(include);
        }

        return await entities.FirstOrDefaultAsync(expression);
    }

    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var entityEntry = _context.Update<TEntity>(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public virtual async ValueTask<TEntity> DeleteAsync(TEntity entity)
    {
        entity.IsDeleted= true;
        var entityEntry = _context.Update<TEntity>(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}