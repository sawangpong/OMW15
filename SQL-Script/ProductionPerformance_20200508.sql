SELECT
b.WORKYEAR,
b.WORKERID,
'jan' = (b.jan/CASE WHEN a.jan = 0 THEN 1 ELSE a.jan END) * 100,
'feb' = (b.feb/CASE WHEN a.feb = 0 THEN 1 ELSE a.feb END) * 100,
'mar' = (b.mar/CASE WHEN a.mar = 0 THEN 1 ELSE a.mar END) * 100,
'apr' = (b.apr/CASE WHEN a.apr = 0 THEN 1 ELSE a.apr END) * 100,
'may' = (b.may/CASE WHEN a.may = 0 THEN 1 ELSE a.may END) * 100,
'jun' = (b.jun/CASE WHEN a.jun = 0 THEN 1 ELSE a.jun END) * 100,
'jul' = (b.jul/CASE WHEN a.jul = 0 THEN 1 ELSE a.jul END) * 100,
'aug' = (b.aug/CASE WHEN a.aug = 0 THEN 1 ELSE a.aug END) * 100,
'sep' = (b.sep/CASE WHEN a.sep = 0 THEN 1 ELSE a.sep END) * 100,
'oct' = (b.oct/CASE WHEN a.oct = 0 THEN 1 ELSE a.oct END) * 100,
'nov' = (b.nov/CASE WHEN a.nov = 0 THEN 1 ELSE a.nov END) * 100,
'dec' = (b.dec/CASE WHEN a.dec = 0 THEN 1 ELSE a.dec END) * 100,
'tt'  = (b.tt/CASE WHEN a.tt =0 THEN 1 ELSE a.tt END)
FROM (
SELECT 
mt.IndRegID,
mt.Y,
'jan' = SUM(CASE WHEN mt.M=1 THEN mt.[Avail-Hour] ELSE 0 END),
'feb' = SUM(CASE WHEN mt.M=2 THEN mt.[Avail-Hour] ELSE 0 END),
'mar' = SUM(CASE WHEN mt.M=3 THEN mt.[Avail-Hour] ELSE 0 END),
'apr' = SUM(CASE WHEN mt.M=4 THEN mt.[Avail-Hour] ELSE 0 END),
'may' = SUM(CASE WHEN mt.M=5 THEN mt.[Avail-Hour] ELSE 0 END),
'jun' = SUM(CASE WHEN mt.M=6 THEN mt.[Avail-Hour] ELSE 0 END),
'jul' = SUM(CASE WHEN mt.M=7 THEN mt.[Avail-Hour] ELSE 0 END),
'aug' = SUM(CASE WHEN mt.M=8 THEN mt.[Avail-Hour] ELSE 0 END),
'sep' = SUM(CASE WHEN mt.M=9 THEN mt.[Avail-Hour] ELSE 0 END),
'oct' = SUM(CASE WHEN mt.M=10 THEN mt.[Avail-Hour] ELSE 0 END),
'nov' = SUM(CASE WHEN mt.M=11 THEN mt.[Avail-Hour] ELSE 0 END),
'dec' = SUM(CASE WHEN mt.M=12 THEN mt.[Avail-Hour] ELSE 0 END),
'tt' = SUM(mt.[Avail-Hour])
FROM OM_VALID_TIME_RECORDS mt
WHERE DATEPART(WEEKDAY,mt.DateOnlyRecord) <> 1
AND mt.y = 2020
--AND mt.m=10
GROUP BY mt.IndRegID,mt.Y
--ORDER BY mt.Y,mt.IndRegID
) a
INNER JOIN
(
select 
pi.WORKERID,
pi.WORKYEAR,
'jan' = SUM(CASE WHEN pi.WORKPERIOD = 1 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'feb' = SUM(CASE WHEN pi.WORKPERIOD = 2 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'mar' = SUM(CASE WHEN pi.WORKPERIOD = 3 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'apr' = SUM(CASE WHEN pi.WORKPERIOD = 4 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'may' = SUM(CASE WHEN pi.WORKPERIOD = 5 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'jun' = SUM(CASE WHEN pi.WORKPERIOD = 6 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'jul' = SUM(CASE WHEN pi.WORKPERIOD = 7 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'aug' = SUM(CASE WHEN pi.WORKPERIOD = 8 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'sep' = SUM(CASE WHEN pi.WORKPERIOD = 9 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'oct' = SUM(CASE WHEN pi.WORKPERIOD = 10 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'nov' = SUM(CASE WHEN pi.WORKPERIOD = 11 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'dec' = SUM(CASE WHEN pi.WORKPERIOD = 12 THEN pi.TOTAL_NORMAL_HR ELSE 0 END),
'tt' = SUM(pi.TOTAL_NORMAL_HR)
FROM PRODUCTIONJOBINFO pi
WHERE DATEPART(WEEKDAY,pi.DATETIME_START) <> 1
AND pi.WORKYEAR = 2020
--AND pi.WORKPERIOD = 10
GROUP BY pi.WORKYEAR, pi.WORKERID
--ORDER BY pi.WORKYEAR, pi.WORKERID 
) b
ON a.IndRegID = CAST(b.WORKERID AS INT)

