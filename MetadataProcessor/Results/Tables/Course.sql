CREATE TABLE [dbo].[Course]
(
	[CourseID]       INT IDENTITY(1,1) NOT NULL	[Title]          VARCHAR (100)       NULL	[Credits]        INT                 NOT NULL	[DepartmentID]   [dbo].[KeyType]     NOT NULL
)
GO

