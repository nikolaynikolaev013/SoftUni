--Problem 1.	Find Names of All Employees by First Name

SELECT FirstName, LastName
	FROM Employees
	WHERE FirstName LIKE 'Sa%'


--Problem 2.	  Find Names of All employees by Last Name 

SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'

--Problem 3.	Find First Names of All Employees

SELECT FirstName
	FROM Employees
	WHERE DepartmentID = 3 
		OR DepartmentID = 10
		AND YEAR(HireDate) BETWEEN 1995 AND 2005

--Problem 4.	Find All Employees Except Engineers

SELECT FirstName, LastName
	FROM Employees
	WHERE NOT JobTitle LIKE '%engineer%'

--Problem 5.	Find Towns with Name Length

SELECT Name
	FROM Towns
	WHERE LEN(Name) = 5 OR LEN(Name) = 6
	ORDER BY Name

--Problem 6.	 Find Towns Starting With

SELECT TownID, Name
	FROM Towns
	WHERE LEFT(Name, 1) = 'M'
		OR LEFT(Name, 1) = 'K'
		OR LEFT(Name, 1) = 'B'
		OR LEFT(Name, 1) = 'E'
	ORDER BY Name

--Problem 7.	 Find Towns Not Starting With

SELECT TownID, Name
	FROM Towns
	WHERE NOT LEFT(Name, 1) = 'R'
		AND NOT LEFT(Name, 1) = 'B'
		AND NOT LEFT(Name, 1) = 'D'
	ORDER BY Name

--Problem 8.	Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000  AS
SELECT FirstName, LastName
	FROM Employees
	WHERE Year(HireDate) > 2000

--Problem 9.	Length of Last Name

SELECT FirstName, LastName
	FROM Employees
	WHERE LEN(LastName) = 5

--Problem 10.	Rank Employees by Salary

SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

--Problem 11.	Find All Employees with Rank 2 *

SELECT *
	FROM (
		SELECT EmployeeID, FirstName, LastName, Salary,
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank] 
		FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000) AS MyTable
	WHERE Rank = 2
	ORDER BY Salary DESC

--Problem 12.	Countries Holding ‘A’ 3 or More Times
SELECT CountryName, IsoCode
	FROM Countries
	WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'A', '')) >= 3
ORDER BY IsoCode

--Problem 13.	 Mix of Peak and River Names

SELECT p.PeakName, r.RiverName, LOWER(CONCAT(SUBSTRING(p.PeakName, 1, LEN(p.PeakName)-1), r.RiverName)) Mix
	FROM Peaks p
JOIN Rivers r ON RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix

--Problem 14.	Games from 2011 and 2012 year

SELECT TOP(50) Name, FORMAT(Start, 'yyyy-MM-dd') AS Start
	FROM Games
	WHERE YEAR(Start) BETWEEN 2011 AND 2012
ORDER BY Start, Name

--Problem 15.	 User Email Providers

SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
	FROM Users
	ORDER BY [Email Provider], Username

--Problem 16.	 Get Users with IPAdress Like Pattern

SELECT Username, IpAddress AS [IP Address]
	FROM Users
	WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--Problem 17.	 Show All Games with Duration and Part of the Day

SELECT [Name] as Game, 
	CASE
		WHEN (DATEPART(HOUR, Start) >= 0) AND (DATEPART(HOUR, Start) < 12) THEN 'Morning'
		WHEN (DATEPART(HOUR, Start) >= 12) AND (DATEPART(HOUR, Start) < 18) THEN 'Afternoon'
		WHEN (DATEPART(HOUR, Start) >= 18) AND (DATEPART(HOUR, Start) < 24) THEN 'Evening'
END AS [Part of the Day],
	(CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
		END) AS Duration
	FROM Games
	ORDER BY Name, Duration, Start

--Problem 18.	 Orders Table

