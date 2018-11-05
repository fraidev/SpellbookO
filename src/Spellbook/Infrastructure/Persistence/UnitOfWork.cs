using System;
using System.Linq;
using NHibernate;

namespace Spellbook.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        void Save<TEntity>(TEntity entity) where TEntity : class;
        /*TEntity Merge<TEntity>(TEntity entity) where TEntity : class; */
        void Update(object entity);
        void SaveOrUpdate(object entity);
        void Delete(object entity);
        /* void Delete(params object[] entities);
         void Clear();
         void Flush(); */
        T GetById<T>(Guid id);
        IQueryable<T> Query<T>();
        /* ISQLQuery CreateSqlQuery(string sql);
         IQuery GetNamedQuery(string namedQuery);
         object Get(Type type, object id);
         IList List(Type t);
         bool Contains(object entity);
         bool IsMapped(Type type);*/
    }
    
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ISession _session;

        public UnitOfWork()
        {
            _session = NHibernateHelper.CreateSessionFactory().OpenSession();
            _session.BeginTransaction();
        }
        
        public void Save<TEntity>(TEntity entity) where TEntity : class
        {
            _session.Save(entity);
            _session.Transaction.Commit();
        }

        public void Update(object entity)
        {
            _session.Update(entity);
        }

        public void SaveOrUpdate(object entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public void Delete(object entity)
        {
            _session.Delete(entity);
        }

        public T GetById<T>(Guid id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }
    }
}