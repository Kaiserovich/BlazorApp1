using BlazorOrders;
using BlazorOrders.Contracts;
using BlazorOrders.Entities;
using BlazorOrders.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorOrders.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext db { get; set; }
        public RepositoryBase(AppDbContext repositoryContext) => this.db = repositoryContext;
        public IQueryable<T> FindAll() => this.db.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>  this.db.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => this.db.Set<T>().Add(entity);
        public void Update(T entity) => this.db.Set<T>().Update(entity); 
        public void Delete(T entity) => this.db.Set<T>().Remove(entity);
    }
}
