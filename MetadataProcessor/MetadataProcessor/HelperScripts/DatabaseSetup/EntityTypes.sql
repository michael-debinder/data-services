CREATE TABLE [dbo].[EntityTypes] (
	[EntityTypeKey]							INT				IDENTITY(1,1) NOT NULL,
	[Name]									VARCHAR (50)	NOT NULL,
	[Description]							VARCHAR (MAX)	NULL,
	[StorageName]							VARCHAR (50)	NOT NULL,
	[ReadOnly]								BIT				NOT NULL CONSTRAINT [DF_EntityTypes_ReadOnly]  DEFAULT ((0)),
	[KeyName]								VARCHAR(50)		NOT NULL
	CONSTRAINT [PK_EntityTypes] PRIMARY KEY CLUSTERED ([EntityTypeKey] ASC)
);
GO
