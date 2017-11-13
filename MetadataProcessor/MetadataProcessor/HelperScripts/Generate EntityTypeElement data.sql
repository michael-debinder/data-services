DECLARE @TableName VARCHAR(50) = 'Course'
DECLARE @EntityTypeKey VARCHAR(10) = '1'
DECLARE @StartKey INT = 1
SELECT 'UNION ALL SELECT ' + CONVERT(VARCHAR, @StartKey + (ROW_NUMBER() OVER(ORDER BY c.column_id))) + ', ' + @EntityTypeKey + ', ' + CONVERT(VARCHAR, (ROW_NUMBER() OVER(ORDER BY c.column_id))) + ', ' + 
	'N''' + c.Name + ''', N''' + c.Name + ''', ''' + c.Name + ''', ' + 
	CASE WHEN ut.name in ('int','tinyint','smallint') THEN '1'
		WHEN st.name in ('nvarchar','varchar', 'char') THEN '2' 
		WHEN st.name in ('bit') THEN '3' 
		WHEN st.name in ('date') THEN '4' 
		WHEN st.name in ('datetime') THEN '5' 
		WHEN st.name in ('decimal', 'money') THEN '6' 
		WHEN ut.name in ('KeyType') THEN CASE WHEN c.name = t.name + 'Key' THEN '1' ELSE '7' END 
		ELSE '|BROKEN|' END + ', ' +
	CASE WHEN st.name in ('tinyint','smallint','money') THEN '''' + UPPER(ut.name) + ''''
		WHEN ut.name <> st.name THEN '''' + ut.name + ''''
		WHEN ut.name in ('char') THEN '''CHAR (' + CONVERT(varchar, c.max_length) + ')'''
		WHEN ut.name in ('nvarchar','varchar') THEN '''' + CONVERT(varchar, c.max_length) + ''''
		WHEN st.name in ('decimal') THEN '''' + CONVERT(varchar, c.precision) + ',' + CONVERT(varchar, c.scale) + ''''
		ELSE 'NULL' END + ', ' +
	CONVERT(varchar, c.is_nullable) + ', ' + ISNULL('''' + REPLACE(dc.definition,'''','''''') + '''', 'NULL') + ', NULL, NULL, ' + 
	ISNULL('''' + REPLACE(cc.definition,'''','''''') + '''', 'NULL')
FROM sys.columns c 
join sys.tables t on c.object_id = t.object_id
join sys.types ut on c.user_type_id = ut.user_type_id
join sys.types st on ut.system_type_id = st.system_type_id and st.system_type_id = st.user_type_id
left join sys.default_constraints dc on c.object_id = dc.parent_object_id and c.column_id = dc.parent_column_id 
left join sys.computed_columns cc on c.object_id = cc.object_id and c.column_id = cc.column_id 
WHERE c.OBJECT_ID = OBJECT_ID(@TableName) 
ORDER BY c.column_id
