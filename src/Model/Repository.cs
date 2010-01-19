using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Model
{
	public interface IRepository
	{
		TextWriter SQLlog { set; }

		IEnumerable<IArtist> Artists { get; }

		IEnumerable<IGenre> Genres { get; }

		IEnumerable<IArtist> GetArtistsByGenre(string a_genre);
	}
}
