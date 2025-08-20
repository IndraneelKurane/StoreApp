using Microsoft.EntityFrameworkCore;
using StoreApp.Dal.Entities;
using StoreApp.Dal.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Dal.Repositories.Base;
public class RepositoryBase<TDbContext, TEntity> 
    where TDbContext : DbContext
    where TEntity : EntityBase
{
    protected readonly TDbContext _context;
    public RepositoryBase(TDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        var entity = await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        return entity;
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }
    public virtual async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public virtual async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public virtual async Task DeleteAsync(TEntity entity)
    {
        //var entt = (TEntity)_context.Set<TEntity>().AsNoTracking().First(e => e == entity);
        _context.Set<TEntity>().Remove(entity);
        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
    
    public virtual void DetachAllEntities()
    {
        var entries = _context.ChangeTracker.Entries().ToList();
        foreach (var entry in entries)
        {
            entry.State = EntityState.Detached;
        }
    }
}
