using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using Model;

namespace EntityFrameworkModel
{
	[EdmEntityTypeAttribute(NamespaceName = "ArtistsModel", Name = "Foo")]
	public class Artist : EntityObject, IArtist
	{
		private int m_id;
		private string m_name;

		[EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
		public int ID
		{
			get
			{
				return this.m_id;
			}
			private set
			{
				this.m_id = value;
			}
		}

		[EdmScalarPropertyAttribute(IsNullable = false)]
		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}

		[EdmRelationshipNavigationPropertyAttribute("ArtistsModel", "FK_Relationship", "FooToBar")]
		public Genre BarFK
		{
			get
			{
				return BarFKReference.Value;
			}
			set
			{
				BarFKReference.Value = value;
			}
		}

		public EntityReference<Genre> BarFKReference
		{
			get
			{
				return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<Genre>("ArtistsModel.FK_Relationship", "FooToBar");
			}
			set
			{
				if ((value != null))
				{
					((IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<Genre>("ArtistsModel.FK_Relationship", "FooToBar", value);
				}
			}
		}

		public IGenre Genre
		{
			get { return BarFK; }
			set { BarFK = value as Genre; }
		}
	}
}
