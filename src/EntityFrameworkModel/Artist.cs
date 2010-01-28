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
		[EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
		public int ID { get; set; }

		[EdmScalarPropertyAttribute(IsNullable = false)]
		public string Name { get; set; }

		[EdmRelationshipNavigationPropertyAttribute("ArtistsModel", "FK_Foo_Bar", "FooToBar")]
		public Genre Bar
		{
			get	{ return BarReference.Value; }
			set	{ BarReference.Value = value;	}
		}

		public EntityReference<Genre> BarReference
		{
			get
			{
				return ((IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<Genre>("ArtistsModel.FK_Foo_Bar", "FooToBar");
			}
			set
			{
				if ((value != null))
				{
					((IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<Genre>("ArtistsModel.FK_Foo_Bar", "FooToBar", value);
				}
			}
		}

		IGenre IArtist.Genre
		{
			get { return Bar; }
			set { Bar = value as Genre; }
		}
	}
}
