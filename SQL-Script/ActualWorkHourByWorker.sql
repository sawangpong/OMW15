CREATE VIEW OM_ACTUAL_WORKHOURS_BY_WORKER AS
SELECT 
	t.y
	,t.EMPCODE
	,t.fname
	,'jan' = SUM(CASE WHEN t.m	= 1 THEN t.totalHours ELSE 0 END)
	,'feb' = SUM(CASE WHEN t.m	= 2 THEN t.totalHours ELSE 0 END)
	,'mar' = SUM(CASE WHEN t.m	= 3 THEN t.totalHours ELSE 0 END)
	,'apr' = SUM(CASE WHEN t.m	= 4 THEN t.totalHours ELSE 0 END)
	,'may' = SUM(CASE WHEN t.m	= 5 THEN t.totalHours ELSE 0 END)
	,'jun' = SUM(CASE WHEN t.m	= 6 THEN t.totalHours ELSE 0 END)
	,'jul' = SUM(CASE WHEN t.m	= 7 THEN t.totalHours ELSE 0 END)
	,'aug' = SUM(CASE WHEN t.m	= 8 THEN t.totalHours ELSE 0 END)
	,'sep' = SUM(CASE WHEN t.m	= 9 THEN t.totalHours ELSE 0 END)
	,'oct' = SUM(CASE WHEN t.m	= 10 THEN t.totalHours ELSE 0 END)
	,'nov' = SUM(CASE WHEN t.m	= 11 THEN t.totalHours ELSE 0 END)
	,'dec' = SUM(CASE WHEN t.m	= 12 THEN t.totalHours ELSE 0 END)
     ,'Total' = SUM(t.TotalHours)
FROM [OLDMOON].[dbo].[OM_FS_VALIDTIME_RECORDS] t
GROUP BY t.y,t.EMPCODE,t.fname
