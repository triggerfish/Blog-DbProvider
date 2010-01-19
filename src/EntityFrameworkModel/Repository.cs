using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Objects;
using Model;

namespace EntityFrameworkModel
{
	public class Repository : IRepository, IDisposable
	{
		private DataContext m_ctx;

		public Repository(string a_strConnection)
		{
			m_ctx = new DataContext(a_strConnection);
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
				return m_ctx.Artists.Include("BarFK").AsEnumerable().Cast<IArtist>();
			}
		}

		public IEnumerable<IGenre> Genres
		{
			get
			{
				return m_ctx.Genre.AsEnumerable().Cast<IGenre>();
			}
		}

		public IEnumerable<IArtist> GetArtistsByGenre(string a_genre)
		{
			try
			{
				return m_ctx.Artists.Include("BarFK").Where(a => a.BarFK.Name == a_genre).AsEnumerable().Cast<IArtist>();
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
