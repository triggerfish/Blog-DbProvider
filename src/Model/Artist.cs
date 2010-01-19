using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	public interface IArtist
	{
		int ID { get; }

		string Name { get; set; }

		IGenre Genre { get; set; }
	}
}
