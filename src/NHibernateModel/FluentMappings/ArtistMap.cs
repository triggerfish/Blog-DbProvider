using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NHibernateModel.FluentMappings
{
	public class ArtistMap : ClassMap<Artist>
	{
		public ArtistMap()
		{
			Table("Artists");
			Id(x => x.ID)
				.GeneratedBy.Native();
			Map(x => x.Name)
				.Length(50)
				.Not.Nullable();
			References(x => x.Genre)
				.Column("GenreID")
				.Not.Nullable();
		}
	}
}
