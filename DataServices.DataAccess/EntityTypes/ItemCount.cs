// <copyright file="ItemCount.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.EntityTypes
{
	using Data;
	using SDK.Data;

	/// <summary>
	/// Entity definition for the ItemCount object.
	/// </summary>
	public class ItemCount : DSEntityType
	{
		/// <summary>Class name for this Entity Type.</summary>
		public const string ClassName = "ItemCount";

		/// <summary>
		/// Initializes a new instance of the <see cref="ItemCount" /> class.
		/// </summary>
		public ItemCount() : base()
		{
			Name = "ItemCount";
			StorageName = "ItemCount";
			KeyName = "ID";

			Add(KeyName, DSElementTypeEnum.Integer);
            
			Add("Count", DSElementTypeEnum.Decimal);
			Add("Date", DSElementTypeEnum.DateTime);
			AddReference("ItemID", "ItemID", "Item");
			AddReference("ItemLocationID", "ItemLocationID", "ItemLocation");
        }
    }
}
