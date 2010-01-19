using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.IO;
using System.Data.Objects;
using Model;

namespace LinqToSqlModel
{
	public class Repository : IRepository, IDisposable
	{
		private DataContext m_ctx;
		private Table<Genre> m_genres;
		private Table<Artist> m_artists;

		public Repository(string a_strConnection)
		{
			m_ctx = new DataContext(a_strConnection);

			DataLoadOptions dlo = new DataLoadOptions();
			dlo.LoadWith<Artist>(c => c.Genre);
			m_ctx.LoadOptions = dlo;
		}

		~Repository()
		{
			Dispose(false);
		}

		public TextWriter SQLlog 
		{
			set 
			{
				if (null != m_ctx)
					m_ctx.Log = value;
			}
		}

		public IEnumerable<IArtist> Artists
		{
			get
			{
				if (null == m_artists)
				{
					m_artists = m_ctx.GetTable<Artist>();
				}

				return m_artists.AsEnumerable().Cast<IArtist>();
			}
		}

		public IEnumerable<IGenre> Genres
		{
			get 
			{
				if (null == m_genres)
				{
					m_genres = m_ctx.GetTable<Genre>();
				}
				return m_genres.AsEnumerable().Cast<IGenre>(); 
			}
		}

		public IEnumerable<IArtist> GetArtistsByGenre(string a_genre)
		{
			try
			{
				return
					(from a in Artists
					 where a.Genre.Name == a_genre
					 select a);
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
				m_ctx.Dispose();
			}
		}
	}
}
