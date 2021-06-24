CREATE DATABASE TEST;
USE TEST

--Problem 1.	One-To-One Relationship

CREATE TABLE Passports (
	Id INT IDENTITY PRIMARY KEY,
	PassportNumber VARCHAR(10) UNIQUE NOT NULL
)

CREATE TABLE Persons (
	PersonId INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(30),
	Salary Decimal(10,2),
	PassportID INT UNIQUE REFERENCES Passports(Id)
)

SET IDENTITY_INSERT Passports ON

INSERT INTO Passports(Id, PassportNumber) VALUES 
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

SET IDENTITY_INSERT Passports OFF

INSERT INTO Persons(FirstName, Salary, PassportID) VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

--Problem 2.	One-To-Many Relationship

CREATE TABLE Manufacturers(
	ManufacturerId INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(30), 
	EstablishedOn DATE
)

INSERT INTO Manufacturers([Name], EstablishedOn) VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

CREATE TABLE Models(
	ModelID INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(30),
	ManufacturerID INT REFERENCES Manufacturers(ManufacturerId)
)

SET IDENTITY_INSERT Models ON

INSERT INTO Models(ModelID, [Name], ManufacturerID) VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

SET IDENTITY_INSERT Models ON

-- Problem 3.	Many-To-Many Relationship

CREATE TABLE Students (
	StudentID INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(30) NOT NULL
)

INSERT INTO Students([Name]) VALUES
('Mila'),
('Toni'),
('Ron')

CREATE TABLE Exams (
	ExamID INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL
)

INSERT INTO Exams([Name]) VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

CREATE TABLE StudentsExams(
	StudentID INT REFERENCES Students(StudentID),
	ExamID INT REFERENCES Exams(ExamID),
	PRIMARY KEY(StudentID, ExamID) 
)

INSERT INTO StudentsExams(StudentID, ExamID) VALUES
(1, 101),
(1, 102), 
(2, 101), 
(3, 103), 
(2, 102), 
(2, 103)

--Problem 4.	Self-Referencing 

CREATE TABLE Teachers(
	TeacherID INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL,
	ManagerID INT REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers([Name], ManagerID) VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

--Problem 5.	Online Store Database

CREATE TABLE ItemTypes(
	ItemTypeID INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items(
	ItemID INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL,
	ItemTypeID INT REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Cities(
	CityID INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Customers(
	CustomerID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50),
	Birthday DATE,
	CityID INT REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
	OrderID INT IDENTITY PRIMARY KEY,
	CustomerID INT REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems(
	OrderID INT REFERENCES Orders(OrderID),
	ItemID INT REFERENCES Items(ItemID),
	PRIMARY KEY(OrderID, ItemID)
)

--Problem 6.	University Database

CREATE TABLE Subjects(
	SubjectID INT IDENTITY PRIMARY KEY,
	SubjectName NVARCHAR(30)
)

CREATE TABLE Majors(
	MajorID INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Students(
	StudentID INT IDENTITY PRIMARY KEY,
	StudentNumber NVARCHAR(30),
	StudentName NVARCHAR(30),
	MajorID INT REFERENCES Majors(MajorID)
)


CREATE TABLE Payments(
	PaymentsID INT IDENTITY PRIMARY KEY,
	PaymentDate DATE,
	PaymentAmount DECIMAL(10,2),
	StudentID INT REFERENCES Students(StudentID)
)

CREATE TABLE Agenda(
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID),
	PRIMARY KEY(StudentID, SubjectID)
)

--Problem 9.	*Peaks in Rila

SELECT m.MountainRange, p.PeakName, p.Elevation 
	FROM Peaks p
	JOIN Mountains m ON p.MountainId = m.Id
	WHERE m.MountainRange = 'Rila'
	ORDER BY p.Elevation DESC