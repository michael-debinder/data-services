PRINT 'Updating Static Data for EntityTypeElements'

Declare @ImportTemp as Table 
([EntityTypeElementKey] int, [EntityTypeKey] int, [SortOrder] int, [Name] VARCHAR(50), [Description] VARCHAR(MAX) NULL, [StorageName] VARCHAR(50), [DataType] int, [DataSize] VARCHAR(50),
	[AllowNull] bit, [Default] VARCHAR(200), [ReferenceTypeName] VARCHAR(50) NULL, [VirtualPath] VARCHAR(MAX) NULL, [Calculated] VARCHAR(MAX) NULL)

--Begin the Static Data Insert
INSERT @ImportTemp ([EntityTypeElementKey], [EntityTypeKey], [SortOrder], [Name], [Description], [StorageName], [DataType], [DataSize], [AllowNull], [Default], [ReferenceTypeName], [VirtualPath], [Calculated]) 
-- Course
          SELECT 1, 1, 1, N'CourseID', N'CourseID', 'CourseID', 1, NULL, 0, NULL, NULL, NULL, NULL
UNION ALL SELECT 2, 1, 2, N'Title', N'Title', 'Title', 2, '100', 1, NULL, NULL, NULL, NULL
UNION ALL SELECT 3, 1, 3, N'Credits', N'Credits', 'Credits', 1, NULL, 0, NULL, NULL, NULL, NULL
UNION ALL SELECT 4, 1, 4, N'Department', N'DepartmentID', 'DepartmentID', 7, NULL, 0, '((1))', 'Department', NULL, NULL
-- Department
UNION ALL SELECT 5, 2, 1, N'DepartmentID', N'DepartmentID', 'DepartmentID', 1, NULL, 0, NULL, NULL, NULL, NULL
UNION ALL SELECT 6, 2, 2, N'Name', N'Name', 'Name', 2, '100', 1, NULL, NULL, NULL, NULL
UNION ALL SELECT 7, 2, 3, N'Budget', N'Budget', 'Budget', 6, 'MONEY', 0, NULL, NULL, NULL, NULL
UNION ALL SELECT 8, 2, 4, N'StartDate', N'StartDate', 'StartDate', 5, NULL, 0, NULL, NULL, NULL, NULL
UNION ALL SELECT 9, 2, 5, N'Instructor', N'InstructorID', 'InstructorID', 7, NULL, 1, NULL, 'Person', NULL, NULL
--UNION ALL SELECT 10, 2, 6, N'RowVersion', N'RowVersion', 'RowVersion', |BROKEN|, NULL, 0, NULL, NULL, NULL, NULL
-- Enrollment
UNION ALL SELECT 11, 3, 1, N'EnrollmentID', N'EnrollmentID', 'EnrollmentID', 1, NULL, 0, NULL, NULL, NULL, NULL
UNION ALL SELECT 12, 3, 2, N'Course', N'CourseID', 'CourseID', 7, NULL, 0, NULL, 'Course', NULL, NULL
UNION ALL SELECT 13, 3, 3, N'Student', N'StudentID', 'StudentID', 7, NULL, 0, NULL, 'Person', NULL, NULL
UNION ALL SELECT 14, 3, 4, N'Grade', N'Grade', 'Grade', 1, NULL, 1, NULL, NULL, NULL, NULL
-- Person
UNION ALL SELECT 15, 4, 1, N'ID', N'ID', 'ID', 1, NULL, 0, NULL, NULL, NULL, NULL
UNION ALL SELECT 16, 4, 2, N'LastName', N'LastName', 'LastName', 2, '100', 0, NULL, NULL, NULL, NULL
UNION ALL SELECT 17, 4, 3, N'FirstName', N'FirstName', 'FirstName', 2, '100', 0, NULL, NULL, NULL, NULL
UNION ALL SELECT 18, 4, 4, N'HireDate', N'HireDate', 'HireDate', 5, NULL, 1, NULL, NULL, NULL, NULL
UNION ALL SELECT 19, 4, 5, N'EnrollmentDate', N'EnrollmentDate', 'EnrollmentDate', 5, NULL, 1, NULL, NULL, NULL, NULL
UNION ALL SELECT 20, 4, 6, N'Discriminator', N'Discriminator', 'Discriminator', 2, '256', 0, '(''Instructor'')', NULL, NULL, NULL

SET IDENTITY_INSERT [dbo].[EntityTypeElements] ON

MERGE [dbo].[EntityTypeElements] AS t
USING (SELECT * FROM @ImportTemp) as s
ON ( t.[EntityTypeElementKey] = s.[EntityTypeElementKey] )
WHEN MATCHED THEN UPDATE SET
    [EntityTypeKey] = s.[EntityTypeKey],
    [SortOrder] = s.[SortOrder],
    [Name] = s.[Name],
	[Description] = s.[Description], 
	[StorageName] = s.[StorageName], 
	[DataType] = s.[DataType], 
	[DataSize] = s.[DataSize], 
	[AllowNull] = s.[AllowNull], 
	[Default] = s.[Default], 
	[ReferenceTypeName] = s.[ReferenceTypeName], 
	[VirtualPath] = s.[VirtualPath], 
	[Calculated] = s.[Calculated]
 WHEN NOT MATCHED BY TARGET THEN
    INSERT([EntityTypeElementKey], [EntityTypeKey], [SortOrder], [Name], [Description], [StorageName], [DataType], [DataSize], [AllowNull], [Default], [ReferenceTypeName], [VirtualPath], [Calculated])
    VALUES(s.[EntityTypeElementKey], s.[EntityTypeKey], s.[SortOrder], s.[Name], s.[Description], s.[StorageName], s.[DataType], s.[DataSize], s.[AllowNull], s.[Default], s.[ReferenceTypeName], s.[VirtualPath], s.[Calculated])
WHEN NOT MATCHED BY SOURCE THEN DELETE; 
 
SET IDENTITY_INSERT [dbo].[EntityTypeElements] ON

