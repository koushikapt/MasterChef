using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MasterChefWebApp.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChefWebApp.Repository
{
    public sealed class Repository
    {
        ISessionFactory _sessionFactory;
        ISession _session;

        private static readonly Repository _instance = new Repository();

        private Repository()
        {
            InitializeSession();
        }

        public static Repository Instance
        {
            get
            {
                return _instance;
            }
        }

        void InitializeSession()
        {
            try
            {
                _sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString("Data Source=koushik-pc; Database=MasterChef; Integrated Security=SSPI;"))
                    .Mappings(m => m
                    .FluentMappings.AddFromAssemblyOf<Repository>())
                    .BuildSessionFactory();
                _session = _sessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
       
        public IList<Recipe> GetAllRecipes()
        {
            try
            {
                return _session.QueryOver<Recipe>().List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetEntity<T>(Guid id) where T : Entity
        {
            try
            {
                return _session.Get<T>(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T AddEntity<T>(T entity) where T : Entity
        {
            T newOne = null;
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(entity);
                    Commit(transaction, entity);
                    RefreshParentObject(entity);
                    newOne = _session.Get<T>(entity.Id) as T;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return newOne;
            }
        }

        public void UpdateEntity<T>(T entity) where T : Entity
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Update(entity);
                    Commit(transaction, entity);
                    RefreshParentObject(entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public void DeleteEntity<T>(Guid id) where T : Entity
        {
            using (var transaction = _session.BeginTransaction())
            {
                var entity = _session.Get<T>(id);
                if (entity != null)
                {
                    try
                    {
                        _session.Delete(entity);
                        Commit(transaction, entity);
                        RefreshParentObject(entity);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        #region Private Methods
        void Commit(ITransaction transaction, object obj)
        {
            try
            {
                transaction.Commit();
            }
            catch (StaleObjectStateException)
            {
                try
                {
                    _session.Merge(obj);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }

        void RefreshParentObject(Entity entity)
        {
            if (!entity.ParentId.HasValue)
                return;
            var parentObj = _session.Get(entity.ParentType, entity.ParentId.Value);
            if (parentObj != null)
                _session.Refresh(parentObj);
        }
        #endregion
    }
}

