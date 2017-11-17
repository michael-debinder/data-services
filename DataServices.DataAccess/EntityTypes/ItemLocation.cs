// <copyright file="ItemLocation.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.EntityTypes
{
	using Data;
	using SDK.Data;

	/// <summary>
	/// Entity definition for the ItemLocation object.
	/// </summary>
	public class ItemLocation : DSEntityType
	{
		/// <summary>Class name for this Entity Type.</summary>
		public const string ClassName = "ItemLocation";

		/// <summary>
		/// Initializes a new instance of the <see cref="ItemLocation" /> class.
		/// </summary>
		public ItemLocation() : base()
		{
			Name = "ItemLocation";
			StorageName = "ItemLocation";
			KeyName = "ID";

			Add(KeyName, DSElementTypeEnum.Integer);
            
			Add("Description", DSElementTypeEnum.String, true);
			Add("Name", DSElementTypeEnum.String);
        }
    }
}
