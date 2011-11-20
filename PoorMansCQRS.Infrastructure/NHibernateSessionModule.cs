using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;
using NHibernate.Context;

namespace PoorMansCQRS.Infrastructure
{
    public class NHibernateSessionModule : IHttpModule
    {
        private HttpApplication _application;

        public ISessionFactory SessionFactory
        {
            get;
            set;
        }

        public void Init(HttpApplication context)
        {
            _application = context;

            _application.BeginRequest += BeginRequest;
            _application.EndRequest += EndRequest;
        }

        private void BeginRequest(object sender, EventArgs e)
        {
            var session = SessionFactory.OpenSession();
            session.BeginTransaction();

            CurrentSessionContext.Bind(session);
        }

        private void EndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(SessionFactory);

            if (session != null)
            {
                try
                {
                    if (session.Transaction != null && session.Transaction.IsActive)
                    {
                        session.Transaction.Commit();
                    }
                }
                catch
                {
                    session.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    session.Dispose();
                }
            }
        }

        public void Dispose()
        {
            _application.BeginRequest -= BeginRequest;
            _application.EndRequest -= EndRequest;
        }
    }
}
