CREATE TABLE [dbo].[Person]
(
	[ID]               INT IDENTITY(1,1) NOT NULL	[LastName]         VARCHAR (100)       NOT NULL	[FirstName]        VARCHAR (100)       NOT NULL	[HireDate]         DATETIME            NULL	[EnrollmentDate]   DATETIME            NULL	[Discriminator]    VARCHAR (256)       NOT NULL
)
GO

