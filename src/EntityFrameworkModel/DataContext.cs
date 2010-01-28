using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.Metadata.Edm;

[assembly: EdmSchemaAttribute()]
[assembly: EdmRelationshipAttribute("ArtistsModel", "FK_Foo_Bar", "FooToBar", RelationshipMultiplicity.One, typeof(EntityFrameworkModel.Genre), "BarToFoo", RelationshipMultiplicity.Many, typeof(EntityFrameworkModel.Artist))]

namespace EntityFrameworkModel
{
	public class DataContext : LoggingObjectContext
	{
		private ObjectQuery<Artist> m_artists;
		private ObjectQuery<Genre> m_genres;

		public DataContext(string strConnection)
			: base(strConnection, "DataContext")
		{
		}

		public ObjectQuery<Genre> Genre
		{
			get 
			{
				if (m_genres == null)
				{
					m_genres = CreateQuery<Genre>("[Bar]");
				}

				return m_genres;
			}
		}

		public ObjectQuery<Artist> Artists
		{
			get 
			{
				if (m_artists == null)
				{
					m_artists = CreateQuery<Artist>("[Foo]");
				}
				return m_artists;
			}
		}
	}
}
