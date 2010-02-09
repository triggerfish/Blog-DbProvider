using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace NHibernateModel
{
	sealed class UnitOfWork
	{
		private static ISessionFactory m_factory;

		public ISession Session { get; private set; }

		// type constructor
		static UnitOfWork()
		{
			// load up the log4net xml config
			log4net.Config.XmlConfigurator.Configure();


#if FLUENT_MAPPINGS
			m_factory = Fluently.Configure()
							.Database(MsSqlConfiguration.MsSql2005
										.ConnectionString(c => c
											.Server(@"TALISKER\SQLEXPRESS")
											.Database("music")
											.TrustedConnection())
										.ProxyFactoryFactory("NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu")
										.ShowSql())
							.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Artist>())
							.BuildSessionFactory();
#else
			m_factory = new Configuration()
				.Configure()
				.AddAssembly(Assembly.GetExecutingAssembly())
				.BuildSessionFactory();
#endif
		}

		public bool IsActive
		{
			get { return null != Session && Session.Transaction != null && Session.Transaction.IsActive; }
		}

		public void Begin()
		{
			if (null == Session)
			{
				Session = m_factory.OpenSession();
				Session.FlushMode = FlushMode.Commit;
			}

			if (IsActive)
				return;

			try
			{
				Session.BeginTransaction();
			}
			catch (HibernateException)
			{
				End();
				throw;
			}
		}

		public void End()
		{
			if (null == Session) return;

			if (IsActive)
				Session.Transaction.Rollback();
			Session.Close();
			Session.Dispose();
			Session = null;
		}

		public void Commit()
		{
			if (null == Session) return;

			ITransaction tx = Session.Transaction;
			if (tx.IsActive && !tx.WasCommitted && !tx.WasRolledBack)
			{
				try
				{
					tx.Commit();
					Session.BeginTransaction();
				}
				catch (HibernateException)
				{
					End();
					throw;
				}
			}
		}
	}
}
