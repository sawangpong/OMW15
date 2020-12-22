ALTER PROC dbo.usp_DateMissProductionReport(@WorkerId nvarchar(10)= '')
AS
	SELECT
	tm.EMPCODE,
	tm.fname,
	tm.DateOnly,
	tm.Y
	FROM 
	(
		SELECT 
		e.EMPCODE,
		'fname' = e.EMPFIRSTNAME + ' ' + e.EMPLASTNAME,
		b.DateOnly,
		'Y' = YEAR(b.DateOnly)
		FROM (
		SELECT
		a.Badgenumber,
		a.[Name],
		a.DateOnly
		FROM (
		SELECT 
		u.BadgeNumber,
		u.[Name],
		'DateOnly' =CAST(chk.CHECKTIME AS date)
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
	AND tm.EMPCODE = @WorkerId


