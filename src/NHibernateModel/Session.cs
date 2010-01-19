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
	sealed class Session
	{
		private static ISessionFactory m_factory;
		private ISession m_session;

		static Session()
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
							.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
							.BuildSessionFactory();
#else
			m_factory = new Configuration()
				.Configure()
				.AddAssembly(Assembly.GetExecutingAssembly())
				.BuildSessionFactory();
#endif
		}

		public Session()
		{
			m_session = m_factory.OpenSession();
		}

		public ISession CurrentSession
		{
			get
			{
				return m_session;
			}
		}

		public void Close()
		{
			if (null != m_session)
			{
				m_session.Close();
				m_session = null;
			}
		}
	}
}
