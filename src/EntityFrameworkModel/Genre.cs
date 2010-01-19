using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using Model;

namespace EntityFrameworkModel
{
	[EdmEntityTypeAttribute(NamespaceName = "ArtistsModel", Name = "Bar")]
	public partial class Genre : EntityObject, IGenre
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

		[EdmRelationshipNavigationPropertyAttribute("ArtistsModel", "FK_Relationship", "BarToFoo")]
		public EntityCollection<Artist> FooFK
		{
			get
			{
				return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<Artist>("ArtistsModel.FK_Relationship", "BarToFoo");
			}
			set
			{
				if ((value != null))
				{
					((IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<Artist>("ArtistsModel.FK_Relationship", "BarToFoo", value);
				}
			}
		}
	}
}
