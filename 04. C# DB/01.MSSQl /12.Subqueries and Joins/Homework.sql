--1.	Employee Address

SELECT	TOP(5) EmployeeID, JobTitle, e.AddressID, a.AddressText
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	ORDER BY AddressID

--2.	Addresses with Towns

SELECT TOP(50) FirstName, LastName, t.Name AS Town, a.AddressText
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON t.TownID = a.TownID
	ORDER BY FirstName,
			LastName

--3.	Sales Employee

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name
	FROM Employees e
	LEFT JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales'

--4.	Employee Departments

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name
	FROM Employees e
	LEFT JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY e.DepartmentID

--5.	Employees Without Project

SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM Employees AS e
	FULL JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	WHERE ep.EmployeeID IS NULL
	ORDER BY e.EmployeeID

--6.	Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName
	FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE CAST(HireDate AS DATE) > '01.01.1999'
	AND d.Name IN ('Sales', 'Finance')
	ORDER BY HireDate

--7.	Employees with Project

SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS [ProjectName]
	FROM Employees e
	JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects p ON p.ProjectID = ep.ProjectID
	WHERE p.StartDate > '2002-08-13' 
		AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

--8.	Employee 24

Write a query that selects:
•	EmployeeID
•	FirstName
•	ProjectName
Filter all the projects of employee with Id 24. If the project has started during or after 2005 the returned value should be NULL.


SELECT e.EmployeeID, e.FirstName, 
	CASE
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE p.Name
		END AS [ProjectName]
	FROM Employees e
	FULL JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	FULL JOIN Projects p ON p.ProjectID = ep.ProjectID
	WHERE e.EmployeeID = 24 

--9.	Employee Manager

SELECT e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName AS [ManagerName]
	FROM Employees e
	JOIN Employees em ON em.EmployeeID = e.ManagerID
	WHERE e.ManagerID IN (3,7)
	ORDER BY e.EmployeeID]

--10. Employee Summary

SELECT TOP(50) e.EmployeeID, CONCAT(e.FirstName, ' ', e.LastName) AS [EmployeeName], 
			CONCAT(m.FirstName, ' ', m.LastName) AS [ManagerName], d.Name
	FROM Employees e
	JOIN Employees m ON m.EmployeeID = e.ManagerID
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
	ORDER BY e.EmployeeID

--11. Min Average Salary

SELECT TOP(1) AVG(e.Salary) AS [MinAverageSalary]
	FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
	GROUP BY d.Name
	ORDER BY MinAverageSalary

---12. Highest Peaks in Bulgaria

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks p
	JOIN Mountains m ON m.Id = p.MountainId
	JOIN MountainsCountries mc ON mc.MountainId = m.Id
	WHERE mc.CountryCode = 'BG'
		AND p.Elevation > 2835
	ORDER BY p.Elevation DESC

--13. Count Mountain Ranges

SELECT mc.CountryCode, COUNT(m.MountainRange) AS MountainRanges
	FROM Mountains m
	JOIN MountainsCountries mc ON m.Id = mc.MountainId
	JOIN Countries c ON mc.CountryCode = c.CountryCode
	WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
	GROUP BY mc.CountryCode

--14. Countries with Rivers

SELECT TOP(5) c.CountryName, r.RiverName 
	FROM Countries c
	FULL JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
	FULL JOIN Rivers r ON r.Id = cr.RiverId
	JOIN Continents conts ON conts.ContinentCode = c.ContinentCode
	WHERE conts.ContinentName = 'Africa'
	ORDER BY c.CountryName

--15. *Continents and Currencies
--TODO

--16.Countries Without Any Mountains

SELECT COUNT(c.CountryCode) AS Count
	FROM Countries c
	FULL JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL

--17. Highest Peak and Longest River by Country

SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.Length) AS LongestRiverLength
FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Peaks p ON p.MountainId = mc.MountainId
	LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers r ON r.Id = cr.RiverId 
	GROUP BY c.CountryName
	ORDER BY HighestPeakElevation DESC, 
			LongestRiverLength DESC,
			c.CountryName

--18. Highest Peak Name and Elevation by Country

SELECT TOP(5) c.CountryName, ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name], ISNULL(MAX(p.Elevation), 0) AS [Highest Peak Elevation], ISNULL(m.MountainRange, '(no mountain)') AS [Mountain]
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id
	GROUP BY c.CountryName, p.PeakName, m.MountainRange
	ORDER BY c.CountryName, p.PeakName
		
	SELECT TOP (5) WITH TIES c.CountryName, ISNULL(p.PeakName, '(no highest peak)') AS 'HighestPeakName', ISNULL(MAX(p.Elevation), 0) AS 'HighestPeakElevation', ISNULL(m.MountainRange, '(no mountain)')
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, p.PeakName