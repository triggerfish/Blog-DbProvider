using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using System.IO;

namespace DbProvider
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		//******* Event handles *********

		private void m_cmdLinqtoSQL_Click(object sender, EventArgs e)
		{
			string connection = @"Server=.\SQLEXPRESS;Database=music;Trusted_Connection=yes;";

			using (LinqToSqlModel.Repository repository = new LinqToSqlModel.Repository(connection))
			{
				PopulateList(repository, "Pop");
			}
		}

		private void m_cmdLingToEntities_Click(object sender, EventArgs e)
		{
			string connection = "metadata=res://*/EntityFrameworkModel.Model.csdl|res://*/EntityFrameworkModel.Model.ssdl|res://*/EntityFrameworkModel.Model.msl;provider=System.Data.SqlClient;provider connection string=\"Data Source=TALISKER\\SQLEXPRESS;Initial Catalog=music;Integrated Security=True\"";

			using (EntityFrameworkModel.Repository repository = new EntityFrameworkModel.Repository(connection))
			{
				PopulateList(repository, "Indie");
			}
		}

		private void m_cmdNHibernate_Click(object sender, EventArgs e)
		{
			try
			{
				using (NHibernateModel.Repository repository = new NHibernateModel.Repository(""))
				{
					PopulateList(repository, "Classical");
				}
			}
			catch (Exception ex)
			{
				m_txtSQL.Text = ex.ToString();
			}
		}

		//******* Implementation *********

		private void PopulateList(IRepository repository, string genre)
		{
			m_list.Items.Clear();

			StringWriter sw = new StringWriter();
			repository.SQLlog = sw;

			IEnumerable<IArtist> artists = repository.GetArtistsByGenre(genre);

			foreach (IArtist artist in artists)
			{
				ListViewItem lvi = new ListViewItem(artist.Name);
				if (null != artist.Genre)
					lvi.SubItems.Add(artist.Genre.Name);
				m_list.Items.Add(lvi);
			}

			m_txtSQL.Text = sw.ToString();
		}
	}
}
