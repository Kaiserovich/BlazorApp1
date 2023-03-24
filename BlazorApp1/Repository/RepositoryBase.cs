using BlazorApp1;
using BlazorApp1.Contracts;
using BlazorApp1.Entities;
using BlazorApp1.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext db { get; set; }

        public RepositoryBase(AppDbContext repositoryContext)
        {
            this.db = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.db.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.db.Set<T>()
                .Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.db.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.db.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.db.Set<T>().Remove(entity);
        }
    }


}
