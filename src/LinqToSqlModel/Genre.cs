using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using Model;

namespace LinqToSqlModel
{
	[Table(Name = "Genres")]
	public class Genre : IGenre
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
		public int ID {	get; private set; }

		[Column(CanBeNull = false)]
		public string Name { get; set; }
	}
}
