--1. Records’ Count

SELECT COUNT(*)
	FROM [WizzardDeposits]

--2. Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits

--3. Longest Magic Wand Per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize)
	FROM WizzardDeposits
	GROUP BY DepositGroup


--4. * Smallest Deposit Group Per Magic Wand Size
Select the two deposit groups with the lowest average wand size.

--TODO

SELECT TOP(2) DepositGroup
	FROM WizzardDeposits
	GROUP BY DepositGroup
	HAVING MagicWandSize < AVG(MagicWandSize)
	ORDER BY MagicWandSize DESC

--5. Deposits Sum

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	GROUP BY DepositGroup

	

--6. Deposits Sum for Ollivander Family

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	

--7. Deposits Filter

SELECT DepositGroup, SUM(DepositAmount)
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family' 
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY SUM(DepositAmount) DESC

--8.Deposit Charge

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator
	ORDER BY MagicWandCreator, DepositGroup


--9. Age Groups

SELECT AgeGroup, COUNT(*)
	FROM (SELECT 
		CASE	
			WHEN AGE BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN AGE BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN AGE BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN AGE BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN AGE BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN AGE BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN AGE >= 61 THEN '[61+]' 
			END AS ageGroup
		FROM WizzardDeposits) AS AgeGroup
	GROUP BY AgeGroup.ageGroup

--10. First Letter

SELECT LEFT(FirstName, 1) AS FirstLetter
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
	GROUP BY LEFT(FirstName, 1)
	ORDER BY FirstLetter

--11. Average Interest 

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
	FROM WizzardDeposits
	WHERE DepositStartDate > '1985-01-01'
	GROUP BY DepositGroup, IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired
	
SELECT * FROM WizzardDeposits

--12. * Rich Wizard, Poor Wizard

SELECT SUM(XX.DIFF) 
FROM (SELECT DepositAmount - (SELECT DepositAmount FROM WizzardDeposits WHERE Id = g.Id + 1) 
AS DIFF FROM WizzardDeposits g) AS XX

--13. Departments Total Salaries
USE SOFTUNI

SELECT e.DepartmentID, SUM(e.Salary)
	FROM Employees e
	GROUP BY e.DepartmentID
	ORDER BY e.DepartmentID

--14. Employees Minimum Salaries

SELECT DepartmentID, MIN(Salary)
	FROM Employees
	WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000-01-01' 
	GROUP BY DepartmentID

--15. Employees Average Salaries

SELECT * 
INTO #TempEmployees
FROM Employees e
WHERE Salary > 30000

DELETE
	FROM #TempEmployees
	WHERE ManagerID = 42

UPDATE #TempEmployees
	SET Salary += 5000
	WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
	FROM #TempEmployees
	GROUP BY DepartmentID

SELECT * fROM #TempEmployees
ORDER BY ManagerID

--16. Employees Maximum Salaries

SELECT DepartmentID, MAX(SALARY) AS MaxSalary
	FROM Employees
	GROUP BY DepartmentID
	HAVING MAX(SALARY) NOT BETWEEN 30000 AND 70000

--17. Employees Count Salaries

SELECT COUNT(*) AS Count
	FROM Employees
	WHERE ManagerID IS NULL
	
--18. *3rd Highest Salary
Find the third highest salary in each department if there is such. 


--19. **Salary Challenge

SELECT TOP 10 FirstName, LastName, DepartmentID
	FROM Employees e
	WHERE SALARY > (SELECT AVG(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID GROUP BY DepartmentID)