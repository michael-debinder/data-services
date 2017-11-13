CREATE TABLE [dbo].[Department]
(
	[DepartmentID]   INT IDENTITY(1,1) NOT NULL	[Name]           VARCHAR (100)       NULL	[Budget]         MONEY               NOT NULL	[StartDate]      DATETIME            NOT NULL	[InstructorID]   [dbo].[KeyType]     NULL
)
GO

