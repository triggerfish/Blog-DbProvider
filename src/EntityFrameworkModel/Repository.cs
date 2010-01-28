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

		public Repository(string strConnection)
		{
			m_ctx = new DataContext(strConnection);
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
				return m_ctx.Artists.Include("Bar").AsEnumerable().Cast<IArtist>();
			}
		}

		public IEnumerable<IGenre> Genres
		{
			get
			{
				return m_ctx.Genre.AsEnumerable().Cast<IGenre>();
			}
		}

		public IEnumerable<IArtist> GetArtistsByGenre(string genre)
		{
			try
			{
				return m_ctx.Artists.Include("Bar").Where(a => a.Bar.Name == genre).AsEnumerable().Cast<IArtist>();
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

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				m_ctx.Dispose();
			}
		}
	}
}
