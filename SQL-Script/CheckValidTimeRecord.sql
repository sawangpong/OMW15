SELECT 
a.IndRegID,
'fname' = e.EMPFIRSTNAME + ' ' + e.EMPLASTNAME,
a.DateOnlyRecord,
'Y' = YEAR(a.DateOnlyRecord),
'M' = MONTH(a.DateOnlyRecord),
'D' = DAY(a.DateOnlyRecord),
a.[I],
a.[O],
'Avail-Hour' = a.O-a.I
FROM (
SELECT 
mt.IndRegID,
mt.DateOnlyRecord,
CASE WHEN MIN(DATEPART(HOUR,mt.TimeOnlyRecord)) <= 8 THEN 8 ELSE CASE WHEN MIN(DATEPART(HOUR,mt.TimeOnlyRecord)) > 17 THEN 17 ELSE MIN(DATEPART(HOUR,mt.TimeOnlyRecord)) END END AS I,
CASE WHEN MAX(DATEPART(HOUR,mt.TimeOnlyRecord)) <= 8 THEN 8 ELSE CASE WHEN MAX(DATEPART(HOUR,mt.TimeOnlyRecord)) > 17 THEN 17 ELSE MAX(DATEPART(HOUR,mt.TimeOnlyRecord)) END END AS O
FROM MemberTimeRecord mt
GROUP BY mt.IndRegID,mt.DateOnlyRecord ) a
LEFT JOIN EMPLOYEE e ON CAST(a.IndRegID AS VARCHAR(10)) = e.EMPCODE
ORDER BY a.DateOnlyRecord,a.IndRegID
