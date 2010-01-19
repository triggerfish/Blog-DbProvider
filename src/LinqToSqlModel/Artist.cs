using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;
using Model;

namespace LinqToSqlModel
{
	[Table(Name = "Artists")]
	public class Artist : IArtist
	{
		private EntityRef<Genre> m_genre;

		[Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
		public int ID { get; private set; }

		[Column(CanBeNull = false)]
		public string Name { get; set; }

		[Column(CanBeNull = false)]
		public int GenreID { get; set; }

		[Association(Name = "FK_Artist_Genre", Storage = "m_genre", ThisKey = "GenreID", OtherKey = "ID", IsForeignKey = true)]
		public Genre Genre 
		{
			get { return m_genre.Entity; }
			set { m_genre.Entity = value; }
		}

		IGenre IArtist.Genre
		{
			get { return Genre; }
			set { Genre = value as Genre; }
		}
	}
}
