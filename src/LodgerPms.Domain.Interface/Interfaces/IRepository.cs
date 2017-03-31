
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Interface.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(string id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(string id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }

    //public interface IRepository<T>

    //public interface IRepository<T> where T : IAggregateRoot
    //{
    //    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

    //    Task<T> GetById(string id);
    //    /// <summary>
    //    /// Return a queryable object for all graphs. This method
    //    /// represents the foundation of LET (layered-expression-trees):
    //    /// you build one query through the layers (not tiers!)
    //    /// </summary>
    //    /// <returns>IQueryable (query, not data)</returns>
    //    Task<IList<T>> FindAll();

    //    /// <summary>
    //    /// Add an aggregate graph to the store.
    //    /// </summary>
    //    /// <param name="aggregate">Aggregate root object</param>
    //    /// <returns>True if successful; False otherwise</returns>
    //    Task<bool> Add(T aggregate);

    //    /// <summary>
    //    /// Save changes to an aggregate graph already in the store.
    //    /// </summary>
    //    /// <param name="aggregate">Aggregate root object</param>
    //    /// <returns>True if successful; False otherwise</returns>
    //    Task<bool> Save(T aggregate);

    //    /// <summary>
    //    /// Delete the entire graph rooted in the specified aggregate object.
    //    /// Cascading rules must be set at the DB level.
    //    /// </summary>
    //    /// <param name="aggregate">Aggregate root object</param>
    //    /// <returns>True if successful; False otherwise</returns>
    //    Task<bool> Delete(T aggregate);

    //}
}
