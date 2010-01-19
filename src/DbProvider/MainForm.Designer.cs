namespace DbProvider
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_list = new System.Windows.Forms.ListView();
			this.m_colArtist = new System.Windows.Forms.ColumnHeader();
			this.m_colGenre = new System.Windows.Forms.ColumnHeader();
			this.m_cmdLinqtoSQL = new System.Windows.Forms.Button();
			this.m_txtSQL = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_cmdLingToEntities = new System.Windows.Forms.Button();
			this.m_cmdNHibernate = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_list
			// 
			this.m_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colArtist,
            this.m_colGenre});
			this.m_list.Location = new System.Drawing.Point(12, 12);
			this.m_list.MultiSelect = false;
			this.m_list.Name = "m_list";
			this.m_list.Size = new System.Drawing.Size(520, 162);
			this.m_list.TabIndex = 0;
			this.m_list.UseCompatibleStateImageBehavior = false;
			this.m_list.View = System.Windows.Forms.View.Details;
			// 
			// m_colArtist
			// 
			this.m_colArtist.Text = "Artist";
			this.m_colArtist.Width = 150;
			// 
			// m_colGenre
			// 
			this.m_colGenre.Text = "Genre";
			this.m_colGenre.Width = 100;
			// 
			// m_cmdLinqtoSQL
			// 
			this.m_cmdLinqtoSQL.Location = new System.Drawing.Point(12, 187);
			this.m_cmdLinqtoSQL.Name = "m_cmdLinqtoSQL";
			this.m_cmdLinqtoSQL.Size = new System.Drawing.Size(120, 37);
			this.m_cmdLinqtoSQL.TabIndex = 1;
			this.m_cmdLinqtoSQL.Text = "Get Pop Artists Using LINQ to SQL";
			this.m_cmdLinqtoSQL.UseVisualStyleBackColor = true;
			this.m_cmdLinqtoSQL.Click += new System.EventHandler(this.m_cmdLinqtoSQL_Click);
			// 
			// m_txtSQL
			// 
			this.m_txtSQL.Location = new System.Drawing.Point(12, 250);
			this.m_txtSQL.Multiline = true;
			this.m_txtSQL.Name = "m_txtSQL";
			this.m_txtSQL.ReadOnly = true;
			this.m_txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.m_txtSQL.Size = new System.Drawing.Size(520, 187);
			this.m_txtSQL.TabIndex = 3;
			this.m_txtSQL.WordWrap = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 234);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "SQL Commands:";
			// 
			// m_cmdLingToEntities
			// 
			this.m_cmdLingToEntities.Location = new System.Drawing.Point(138, 187);
			this.m_cmdLingToEntities.Name = "m_cmdLingToEntities";
			this.m_cmdLingToEntities.Size = new System.Drawing.Size(120, 37);
			this.m_cmdLingToEntities.TabIndex = 5;
			this.m_cmdLingToEntities.Text = "Get Indie Artists Using LINQ to Entities";
			this.m_cmdLingToEntities.UseVisualStyleBackColor = true;
			this.m_cmdLingToEntities.Click += new System.EventHandler(this.m_cmdLingToEntities_Click);
			// 
			// m_cmdNHibernate
			// 
			this.m_cmdNHibernate.Location = new System.Drawing.Point(264, 187);
			this.m_cmdNHibernate.Name = "m_cmdNHibernate";
			this.m_cmdNHibernate.Size = new System.Drawing.Size(120, 37);
			this.m_cmdNHibernate.TabIndex = 6;
			this.m_cmdNHibernate.Text = "Get Classical Artists Using NHibernate";
			this.m_cmdNHibernate.UseVisualStyleBackColor = true;
			this.m_cmdNHibernate.Click += new System.EventHandler(this.m_cmdNHibernate_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(544, 449);
			this.Controls.Add(this.m_cmdNHibernate);
			this.Controls.Add(this.m_cmdLingToEntities);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_txtSQL);
			this.Controls.Add(this.m_cmdLinqtoSQL);
			this.Controls.Add(this.m_list);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView m_list;
		private System.Windows.Forms.ColumnHeader m_colArtist;
		private System.Windows.Forms.ColumnHeader m_colGenre;
		private System.Windows.Forms.Button m_cmdLinqtoSQL;
		private System.Windows.Forms.TextBox m_txtSQL;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button m_cmdLingToEntities;
		private System.Windows.Forms.Button m_cmdNHibernate;
	}
}

