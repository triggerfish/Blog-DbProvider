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
		[EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
		public int ID { get; set; }

		[EdmScalarPropertyAttribute(IsNullable = false)]
		public string Name { get; set; }

		[EdmRelationshipNavigationPropertyAttribute("ArtistsModel", "FK_Foo_Bar", "BarToFoo")]
		public EntityCollection<Artist> Foos
		{
			get
			{
				return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<Artist>("ArtistsModel.FK_Foo_Bar", "BarToFoo");
			}
			set
			{
				if ((value != null))
				{
					((IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<Artist>("ArtistsModel.FK_Foo_Bar", "BarToFoo", value);
				}
			}
		}
	}
}
