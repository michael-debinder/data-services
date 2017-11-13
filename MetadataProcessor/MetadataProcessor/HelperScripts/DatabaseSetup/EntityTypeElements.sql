CREATE TABLE [dbo].[EntityTypeElements](
	[EntityTypeElementKey]				INT IDENTITY(1,1) NOT NULL,
	[EntityTypeKey]						INT NOT NULL,
	[SortOrder]							INT NULL,
	[Name]								VARCHAR (50) NOT NULL,
	[Description]						VARCHAR (max) NULL,
	[StorageName]						VARCHAR (50) NOT NULL,
	[DataType]							INT NOT NULL,
	[DataSize]							VARCHAR (50) NULL,
	[AllowNull]							BIT NOT NULL CONSTRAINT [DF_EntityTypeElements_AllowNull]  DEFAULT ((1)),
	[Default]							VARCHAR (200) NULL,
	[ReferenceTypeName]					VARCHAR (50) NULL,
	[VirtualPath]						VARCHAR (max) NULL,
	[Calculated]						VARCHAR (max) NULL,
	CONSTRAINT [PK_EntityTypeElements] PRIMARY KEY NONCLUSTERED ([EntityTypeElementKey] ASC),
	CONSTRAINT [FK_EntityTypeElements_EntityTypes_EntityTypeKey] FOREIGN KEY([EntityTypeKey]) REFERENCES [dbo].[EntityTypes] ([EntityTypeKey])
);
GO

CREATE CLUSTERED INDEX [IX_EntityTypeElements_EntityTypeKey] 
	ON [dbo].[EntityTypeElements] ([EntityTypeKey] ASC)
GO
