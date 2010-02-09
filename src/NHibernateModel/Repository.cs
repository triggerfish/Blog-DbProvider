using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Model;
using NHibernate.Linq;

namespace NHibernateModel
{
	public class Repository : IRepository, IDisposable
	{
		private UnitOfWork m_unitOfWork = new UnitOfWork();

		public Repository(string strConnection)
		{
			m_unitOfWork.Begin();
		}

		~Repository()
		{
			Dispose(false);
		}

		public TextWriter SQLlog
		{
			set 
			{
				SQLlogger.Log = value;
			}
		}

		public IEnumerable<IArtist> Artists
		{
			get 
			{
				return m_unitOfWork.Session.Linq<Artist>().Cast<IArtist>();
			}
		}

		public IEnumerable<IGenre> Genres
		{
			get 
			{
				return m_unitOfWork.Session.Linq<Genre>().Cast<IGenre>();
			}
		}

		public IEnumerable<IArtist> GetArtistsByGenre(string genre)
		{
			return m_unitOfWork.Session.Linq<Artist>().Where(a => a.Genre.Name == genre).Cast<IArtist>();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				m_unitOfWork.End();
			}
		}
	}
}
