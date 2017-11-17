// <copyright file="ItemAdjustment.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.EntityTypes
{
	using Data;
	using SDK.Data;

	/// <summary>
	/// Entity definition for the ItemAdjustment object.
	/// </summary>
	public class ItemAdjustment : DSEntityType
	{
		/// <summary>Class name for this Entity Type.</summary>
		public const string ClassName = "ItemAdjustment";

		/// <summary>
		/// Initializes a new instance of the <see cref="ItemAdjustment" /> class.
		/// </summary>
		public ItemAdjustment() : base()
		{
			Name = "ItemAdjustment";
			StorageName = "ItemAdjustment";
			KeyName = "ID";

			Add(KeyName, DSElementTypeEnum.Integer);
            
			Add("Brand", DSElementTypeEnum.String, true);
			Add("Cost", DSElementTypeEnum.Decimal);
			Add("Date", DSElementTypeEnum.DateTime);
			AddReference("ItemID", "ItemID", "Item");
			Add("ItemsPerPkg", DSElementTypeEnum.Decimal);
			Add("Qty", DSElementTypeEnum.Decimal);
			Add("Rating", DSElementTypeEnum.Integer, true);
        }
    }
}
