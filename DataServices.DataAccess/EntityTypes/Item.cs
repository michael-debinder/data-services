// <copyright file="Item.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.EntityTypes
{
	using Data;
	using SDK.Data;

	/// <summary>
	/// Entity definition for the Item object.
	/// </summary>
	public class Item : DSEntityType
	{
		/// <summary>Class name for this Entity Type.</summary>
		public const string ClassName = "Item";

		/// <summary>
		/// Initializes a new instance of the <see cref="Item" /> class.
		/// </summary>
		public Item() : base()
		{
			Name = "Item";
			StorageName = "Item";
			KeyName = "ID";

			Add(KeyName, DSElementTypeEnum.Integer);
            
			Add("Description", DSElementTypeEnum.String, true);
			Add("Name", DSElementTypeEnum.String);
        }
    }
}
