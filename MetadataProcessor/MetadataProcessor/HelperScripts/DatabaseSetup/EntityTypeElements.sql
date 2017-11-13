CREATE TABLE [dbo].[EntityTypeElements](
	[EntityTypeElementKey]				[dbo].[KeyType] IDENTITY(1,1) NOT NULL,
	[EntityTypeKey]						[dbo].[KeyType] NOT NULL,
	[SortOrder]							[int] NULL,
	[Name]								[dbo].[NameType] NOT NULL,
	[Description]						[varchar](max) NULL,
	[StorageName]						[dbo].[NameType] NOT NULL,
	[DataType]							[dbo].[KeyType] NOT NULL,
	[DataSize]							[varchar](50) NULL,
	[AllowNull]							[bit] NOT NULL CONSTRAINT [DF_EntityTypeElements_AllowNull]  DEFAULT ((1)),
	[Default]							[varchar](200) NULL,
	[ReferenceTypeName]					[dbo].[NameType] NULL,
	[VirtualPath]						[varchar](max) NULL,
	[Calculated]						[varchar](max) NULL,
	CONSTRAINT [PK_EntityTypeElements] PRIMARY KEY NONCLUSTERED ([EntityTypeElementKey] ASC),
	CONSTRAINT [FK_EntityTypeElements_EntityTypes_EntityTypeKey] FOREIGN KEY([EntityTypeKey]) REFERENCES [dbo].[EntityTypes] ([EntityTypeKey])
);
GO

CREATE CLUSTERED INDEX [IX_EntityTypeElements_EntityTypeKey] 
	ON [dbo].[EntityTypeElements] ([EntityTypeKey] ASC)
GO
