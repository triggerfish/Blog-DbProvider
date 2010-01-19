using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace NHibernateModel
{
	public class Genre : IGenre
	{
		private IList<Artist> m_artists = new List<Artist>();

		public virtual int ID { get; private set; }

		public virtual string Name { get; set; }

		public virtual IList<Artist> Artists
		{
			get { return m_artists; }
			set { m_artists = value; }
		}
	}
}
