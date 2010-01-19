using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Model;

namespace NHibernateModel
{
	public class Artist : IArtist
	{
		public virtual int ID { get; private set; }

		public virtual string Name { get; set; }

		public virtual Genre Genre { get; set; }

		IGenre IArtist.Genre
		{
			get { return Genre; }
			set { Genre = value as Genre; }
		}
	}
}
