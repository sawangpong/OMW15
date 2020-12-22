CREATE PROC dbo.usp_ProductionMissReport AS
SELECT
a.EMPCODE,
a.fname,
'nday' = COUNT(a.dateonly)
FROM (
		SELECT
		tm.EMPCODE,
		tm.fname,
		tm.DateOnly,
		tm.Y
		FROM 
		(
					SELECT 
					--b.Badgenumber,
					--b.[Name],
					e.EMPCODE,
					'fname' = e.EMPFIRSTNAME + ' ' + e.EMPLASTNAME,
					b.DateOnly,
					'Y' = YEAR(b.DateOnly)
					--'M' = MONTH(b.DateOnly),
					--'D' = DAY(b.DateOnly),
					--b.I,
					--b.O,
					--'Avail-Hour' = b.O-b.I,
					--'TotalHours'= CASE WHEN b.Thour < 0 THEN 0 ELSE b.Thour END
					FROM (
					SELECT
					a.Badgenumber,
					a.[Name],
					a.DateOnly
					--'I' = CASE WHEN MIN(DATEPART(hour,a.[Time-Only])) <= 8 THEN 8 ELSE (CASE WHEN MIN(DATEPART(hour,a.[Time-Only])) > 17 THEN 17 ELSE MIN(DATEPART(hour,a.[Time-Only])) END) END,
					--'O' = CASE WHEN MAX(DATEPART(hour,a.[Time-Only])) >= 17 THEN 17 ELSE (CASE WHEN MAX(DATEPART(hour,a.[Time-Only])) < 8 THEN 8 ELSE MAX(DATEPART(hour,a.[Time-Only])) END) END,
					--'Thour'=(DATEDIFF(MINUTE
					--	,CASE 
					--		WHEN MIN(DATEPART(hour,a.[Time-Only])) <= 8 
					--			THEN CAST(CAST(a.DateOnly AS VARCHAR(10)) +' '+'08:00' AS datetime)  
					--			ELSE (CASE 
					--				WHEN MIN(DATEPART(hour,a.[Time-Only])) > 17 
					--					THEN CAST(CAST(a.DateOnly AS VARCHAR(10)) +' '+'17:00' AS datetime) 
					--					ELSE MIN(CAST(CAST(a.DateOnly AS VARCHAR(10)) +' '+CAST(a.[Time-Only] AS VARCHAR(10)) AS datetime)) 
					--				END) 
					--		END
	
					--	,CASE 
					--		WHEN MAX(DATEPART(hour,a.[Time-Only])) >= 17 
					--			THEN CAST(CAST(a.DateOnly AS VARCHAR(10)) +' '+'17:00' AS datetime)
					--			ELSE (CASE 
					--					WHEN MAX(DATEPART(hour,a.[Time-Only])) < 8 
					--						THEN CAST(CAST(a.DateOnly AS VARCHAR(10)) +' '+'08:00' AS datetime) 
					--						ELSE MAX(CAST(CAST(a.DateOnly AS VARCHAR(10)) +' '+CAST(a.[Time-Only] AS VARCHAR(10)) AS datetime) ) 
					--					END) 
					--		END
					--	)/60.0)
					FROM (
					SELECT 
					u.BadgeNumber,
					u.[Name],
					'DateOnly' =CAST(chk.CHECKTIME AS date)
					--'Time-Only' = CAST(chk.CHECKTIME AS time)
					FROM Fingerscan.dbo.CHECKINOUT chk 
					LEFT JOIN FingerScan.dbo.USERINFO u ON chk.USERID = u.USERID
					) a
					GROUP BY a.DateOnly,a.Badgenumber,a.[Name] ) b
					LEFT JOIN EMPLOYEE e ON CAST(b.Badgenumber AS INT) = CAST(e.EMPCODE AS INT)
					WHERE e.DEPARTMENTID <> 1
		) tm
		WHERE tm.DateOnly NOT IN (
									SELECT  CAST(pj.DATETIME_START AS Date) FROM PRODUCTIONJOBINFO pj 
									WHERE pj.WORKERID = tm.EMPCODE
									)
		AND tm.Y >= 2020 
	) a
WHERE a.EMPCODE IN (SELECT e.EMPCODE FROM EMPLOYEE e WHERE e.DEPARTMENTID IN ('111','112') AND e.STATUS IN (1,6,7,8))
GROUP BY a.EMPCODE, a.fname
