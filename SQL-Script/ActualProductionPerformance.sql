CREATE VIEW OM_ACTUAL_PRODUCTION_PERFORMANCE AS

SELECT 
ap.WORKYEAR,
ap.WORKERNAME,
'jan' = (ap.jan/CASE WHEN aw.jan = 0 THEN 1 ELSE aw.jan END) * 100,
'feb' = (ap.feb/CASE WHEN aw.feb = 0 THEN 1 ELSE aw.feb END) * 100,
'mar' = (ap.mar/CASE WHEN aw.mar = 0 THEN 1 ELSE aw.mar END) * 100,
'apr' = (ap.apr/CASE WHEN aw.apr = 0 THEN 1 ELSE aw.apr END) * 100,
'may' = (ap.may/CASE WHEN aw.may = 0 THEN 1 ELSE aw.may END) * 100,
'jun' = (ap.jun/CASE WHEN aw.jun = 0 THEN 1 ELSE aw.jun END) * 100,
'jul' = (ap.jul/CASE WHEN aw.jul = 0 THEN 1 ELSE aw.jul END) * 100,
'aug' = (ap.aug/CASE WHEN aw.aug = 0 THEN 1 ELSE aw.aug END) * 100,
'sep' = (ap.sep/CASE WHEN aw.sep = 0 THEN 1 ELSE aw.sep END) * 100,
'oct' = (ap.oct/CASE WHEN aw.oct = 0 THEN 1 ELSE aw.oct END) * 100,
'nov' = (ap.nov/CASE WHEN aw.nov = 0 THEN 1 ELSE aw.nov END) * 100,
'dec' = (ap.dec/CASE WHEN aw.dec = 0 THEN 1 ELSE aw.dec END) * 100,
'avg' = (ap.totalNT/CASE WHEN aw.Total = 0 then 1 ELSE aw.Total END) * 100
FROM dbo.OM_ACTUAL_WORKHOURS_BY_WORKER aw 
INNER JOIN OM_ACTUAL_PRODUCTION_HOUR_BY_WORKER ap 
ON aw.EMPCODE = ap.WORKERID 
AND aw.y = ap.WORKYEAR
