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
		private Session m_session = new Session();

		public Repository(string a_strConnection)
		{
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
				return m_session.CurrentSession.Linq<Artist>().Cast<IArtist>();
			}
		}

		public IEnumerable<IGenre> Genres
		{
			get 
			{
				return m_session.CurrentSession.Linq<Genre>().Cast<IGenre>();
			}
		}

		public IEnumerable<IArtist> GetArtistsByGenre(string a_genre)
		{
			try
			{
				return m_session.CurrentSession.Linq<Artist>().Where(a => a.Genre.Name == a_genre).Cast<IArtist>();
			}
			catch (Exception)
			{
				return Artists;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool a_disposing)
		{
			if (a_disposing)
			{
				m_session.Close();
			}
		}
	}
}
