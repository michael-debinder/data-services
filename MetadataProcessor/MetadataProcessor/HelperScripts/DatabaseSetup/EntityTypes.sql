CREATE TABLE [dbo].[EntityTypes] (
	[EntityTypeKey]							[dbo].[KeyType]			IDENTITY(1,1) NOT NULL,
	[Name]									[dbo].[NameType]		NOT NULL,
	[Description]							VARCHAR (MAX)			NULL,
	[StorageName]							[dbo].[NameType]		NOT NULL,
	[ReadOnly]								BIT						NOT NULL CONSTRAINT [DF_EntityTypes_ReadOnly]  DEFAULT ((0)),
	[KeyName]								[dbo].[NameType]		NOT NULL
	CONSTRAINT [PK_EntityTypes] PRIMARY KEY CLUSTERED ([EntityTypeKey] ASC)
);
GO
