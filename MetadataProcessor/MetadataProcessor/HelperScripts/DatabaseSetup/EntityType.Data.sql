PRINT 'Updating Static Data for EntityTypes'

Declare @ImportTemp as Table 
([EntityTypeKey] int, [Name] varchar(50), [Description] VARCHAR(MAX) NULL, 
	[StorageName] varchar(50), [ReadOnly] bit, [KeyName] varchar(50))
 
--Begin the Static Data Insert
INSERT @ImportTemp ([EntityTypeKey], [Name], [Description], [StorageName], [ReadOnly], [KeyName]) 
          SELECT 1, N'Course', N'Course', 'Course', 0, 'CourseID'
UNION ALL SELECT 2, N'Department', N'Department', 'Department', 0, 'DepartmentID'
UNION ALL SELECT 3, N'Enrollment', N'Enrollment', 'Enrollment', 0, 'EnrollmentID'
UNION ALL SELECT 4, N'Person', N'Person', 'Person', 0, 'ID'

SET IDENTITY_INSERT [dbo].[EntityTypes] ON

MERGE [dbo].[EntityTypes] AS t
USING (SELECT * FROM @ImportTemp) as s
ON ( t.[EntityTypeKey] = s.[EntityTypeKey] )
WHEN MATCHED THEN UPDATE SET
    [Name] = s.[Name],
	[Description] = s.[Description], 
	[StorageName] = s.[StorageName], 
	[ReadOnly] = s.[ReadOnly], 
	[KeyName] = s.[KeyName]
 WHEN NOT MATCHED BY TARGET THEN
    INSERT([EntityTypeKey], [Name], [Description], [StorageName], [ReadOnly], [KeyName])
    VALUES(s.[EntityTypeKey], s.[Name], s.[Description], s.[StorageName], s.[ReadOnly], s.[KeyName])
WHEN NOT MATCHED BY SOURCE THEN DELETE; 
 
SET IDENTITY_INSERT [dbo].[EntityTypes] OFF

GO