using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Domain;
using NHibernate;

namespace PoorMansCQRS.Data
{
    public class Repository<T> : IRepository<T>
        where T : AggregateRoot
    {
        private readonly ISessionFactory _sessionFactory;

        public Repository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public T GetById(Guid id)
        {
            return _sessionFactory.GetCurrentSession().Get<T>(id);
        }

        public void Save(T aggregate)
        {
            if (aggregate == null)
                throw new ArgumentNullException("aggregate");

            _sessionFactory.GetCurrentSession().SaveOrUpdate(aggregate);
        }
    }
}
