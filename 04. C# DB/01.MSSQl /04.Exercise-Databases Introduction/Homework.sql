CREATE DATABASE Minions

GO

CREATE TABLE Minions(
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVarchar NOT NULL,
	Age INT NOT NULL
)

GO

CREATE TABLE Towns (
	Id INT NOT NULL,
	[Name] NVARCHAR NOT NULL
)

GO

ALTER TABLE Towns 
ADD CONSTRAINT PK_Towns
PRIMARY KEY(Id)


GO

ALTER TABLE Minions
DROP CONSTRAINT PK__Minions__3214EC0730FC31BB

GO

ALTER TABLE Minions
ADD CONSTRAINT PK_Minions
PRIMARY KEY(Id)

GO

ALTER TABLE Minions
ADD TownId INT

GO

ALTER TABLE Minions
ADD CONSTRAINT FK_TownID
FOREIGN KEY (TownId) REFERENCES Towns(Id)

GO

INSERT INTO Towns(Id, [Name]) VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')


INSERT INTO Minions(Id, [Name], Age, TownId) VALUES 
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

GO

DELETE FROM Minions;

GO

DROP TABLE Minions

GO

DROP TABLE Towns

GO

CREATE TABLE People(
	Id INT NOT NULL IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX)
	CHECK(DATALENGTH(Picture) <= 921600),
	[Height] DECIMAL(5,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL
	CHECK (Gender = 'f' OR Gender = 'm'),
	Birthdate DATE NOT NULL,
	Biography VARCHAR(MAX)
)

GO

ALTER TABLE People
ADD CONSTRAINT PK_People
PRIMARY KEY(Id)

GO

INSERT INTO People([Name],[Picture],[Height],[Weight],Gender,Birthdate,Biography) Values
('Stela',Null,1.65,44.55,'f','2000-09-22',Null),
('Ivan',Null,2.15,95.55,'m','1989-11-02',Null),
('Qvor',Null,1.55,33.00,'m','2010-04-11',Null),
('Karolina',Null,2.15,55.55,'f','2001-11-11',Null),
('Pesho',Null,1.85,90.00,'m','1983-07-22',Null)



GO

CREATE TABLE Users(
	ID BIGINT NOT NULL IDENTITY,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK (DATALENGTH(ProfilePicture) <= 921600),
	LastLoginTime DATETIME2,
	isDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, isDeleted) VALUES
('NickFit', 'Thatsapass', NULL, NULL, 0),
('tedsBest', '123passme', NULL, NULL, 0),
('nikolaynikolaev013', 'knowmypassgirl', NULL, NULL, 0),
('mediVet', 'HealTheAnimal', NULL, NULL, 0),
('AppleInc', 'ILoveMacbooks123', NULL, NULL, 0)

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeUsernameAndID
PRIMARY KEY(Id, Username);

ALTER TABLE Users
ADD CONSTRAINT CheckPasswordLength
CHECK(LEN([Password]) >= 5)

ALTER TABLE Users
ADD CONSTRAINT DefaultLastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users
DROP CONSTRAINT PK_CompositeUsernameAnd

ALTER TABLE Users
ADD PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CheckUsernameLength
CHECK(LEN(Username) >= 3)

-- 13. MOVIES DATABASE

CREATE DATABASE Movies

CREATE TABLE Directors(
	Id INT NOT NULL IDENTITY,
	DirectorName NVARCHAR(100) NOT NULL,
	NOTES NVARCHAR(200)
)

ALTER TABLE Directors
ADD CONSTRAINT PK_Director
PRIMARY KEY(Id)

CREATE TABLE Genres(
	Id INT NOT NULL IDENTITY,
	GenreName NVARCHAR(15) NOT NULL,
	Notes NVARCHAR(200)
)

ALTER TABLE Genres
ADD CONSTRAINT PK_Genre
PRIMARY KEY(Id)


CREATE TABLE Categories(
	Id INT NOT NULL IDENTITY,
	CategoryName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(200)
)

ALTER TABLE Categories
ADD CONSTRAINT PK_Categories
PRIMARY KEY(Id)

CREATE TABLE Movies (
	Id INT NOT NULL IDENTITY,
	Title NVARCHAR(30) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] INT,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT NOT NULL,
	Notes NVARCHAR(200)
)

ALTER TABLE Movies
ADD CONSTRAINT FK_DirectorId
FOREIGN KEY(DirectorId) REFERENCES Directors(Id)

ALTER TABLE Movies
ADD CONSTRAINT FK_GenreId
FOREIGN KEY(GenreId) REFERENCES Genres(Id)

ALTER TABLE Movies
ADD CONSTRAINT FK_CaterogoryId
FOREIGN KEY(CategoryId) REFERENCES Categories(Id)

INSERT INTO Directors(DirectorName) VALUES
('KJ Appa'),
('Lili Reinhart'),
('Casey Cott'),
('Medalime'),
('Terry Crews')

INSERT INTO Genres(GenreName) VALUES
('Horror'),
('Novel'),
('Adventure'),
('Romance'),
('Sitcom')

INSERT INTO Categories(CategoryName) VALUES
('Thriller'),
('Romance'),
('Historical'),
('Fantasy'),
('Experimental')




INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating) VALUES
('IT', 1, '2019', 136, 1, 3, 10),
('Riverdale', 1, '2016', 116, 1, 3, 8),
('Brooklyn nine-nine', 5, '2015', NULL, 4, 2, 9.5),
('How I met your mother', 5, '2010', NULL, 5, 2, 7.8),
('American Horror Story', 1, '2015', NULL, 1, 3, 10)


--14. Car Rental Database

CREATE DATABASE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(30) NOT NULL,
	DailyRate Decimal(5,2) NOT NULL,
	WeeklyRate Decimal(5,2) NOT NULL,
	MonthlyRate Decimal(5,2) NOT NULL,
	WeekendRate Decimal(5,2) NOT NULL
)


CREATE TABLE Cars(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	PlateNumber NVARCHAR(8) NOT NULL,
	Manufacturer NVARCHAR(15) NOT NULL,
	Model NVARCHAR(15) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(30),
	Available BIT NOT NULL
)

ALTER TABLE Cars
ADD CONSTRAINT FK_Cars_CategoryId
FOREIGN KEY(CategoryId) REFERENCES Categories(Id)

CREATE TABLE Employees(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	FirstName NVARCHAR(15) NOT NULL,
	LastName NVARCHAR(15) NOT NULL,
	Title NVARCHAR(15) NOT NULL,
	Notes NVARCHAR(200)
)


CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	[Address] NVARCHAR(100),
	City NVARCHAR(20),
	ZIPCode NVARCHAR(10) NOT NULL,
	NOTES NVARCHAR(200)
)

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL(6,2) NOT NULL,
	TaxRate INT NOT NULL,
	OrderStatus NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(200)
)


ALTER TABLE RentalOrders
ADD CONSTRAINT FK_RentalOrders_EmployeeId FOREIGN KEY(EmployeeId) REFERENCES Employees(Id);

ALTER TABLE RentalOrders
ADD CONSTRAINT FK_RentalOrders_CustomerId FOREIGN KEY(CustomerId) REFERENCES Customers(Id);

ALTER TABLE RentalOrders
ADD CONSTRAINT FK_RentalOrders_CarId FOREIGN KEY(CarId) REFERENCES Cars(Id)

ALTER TABLE RentalOrders
ADD CONSTRAINT RentalOrders_StartDate DEFAULT GETDATE() FOR StartDate;

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Minivan', 15.0, 64.5, 350.40, 42.30),
('Electric', 30.0, 112.30, 994.0, 99.90),
('Sedan', 14.0, 70.20, 250.0, 29.0)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available) VALUES
('Â4221ÐÍ', 'Mitsubishi', 'Space star', 2000, 1, 5, 1),
('Ê2983ÐÎ', 'Opel', 'Corsa C', 2003, 2, 5, 1),
('Â7777ÂÍ', 'Mercedes', 'E550', 2020, 3, 5, 0)

INSERT INTO Employees(FirstName, LastName, Title) VALUES
('Nikolay', 'Nikolaev', 'CEO'),
('Nikola', 'Nikolov', 'CO-CEO'),
('Dian', 'Donev', 'Hygiene expert')

INSERT INTO Customers(DriverLicenceNumber, FullName, ZIPCode) VALUES
(123929, 'Zdravko Naidenov Naidenov', 9000),
(183628, 'Pavel Dochev Pavlinov', 60001),
(156323, 'Kalin Dimitrov Nikolaev', 4044)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, 
			KilometrageEnd, TotalKilometrage, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus) VALUES
(1, 2, 3, 12.4, 1023, 1102, 80, '2021-01-15', 2, 10.2, 20, 'Progress'),
(1, 2, 3, 12.4, 1023, 1102, 80, '2021-01-17', 2, 10.2, 20, 'Completed'),
(1, 2, 3, 12.4, 1023, 1102, 80, '2021-01-19', 2, 10.2, 20, 'Progress')


--15.Hotel Database

CREATE DATABASE Hotel

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(20) NOT NULL
)

INSERT INTO Employees(FirstName, LastName, Title) VALUES
('Pesho', 'Peshov', 'Seller'),
('Dimiter', 'Dimitrov', 'Manager'),
('Irina', 'Dimitrova', 'Manager')

CREATE TABLE Customers(
	AccountNumber VARCHAR(10) PRIMARY KEY NOT NULL,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber VARCHAR(12),
	EmergencyName NVARCHAR(20),
	EmergencyNumber VARCHAR(12),
	Notes NVARCHAR(200)
)

INSERT INTO Customers(AccountNumber, FirstName, LastName, EmergencyName, EmergencyNumber) VALUES
(9260, 'Teodora', 'Lucheva', 'Svetlana', 0892371238),
(1023, 'Svetlana', 'Stancheva', 'Peter', 0892372318),
(1025, 'Peter', 'Luchev', 'Svetlana', 0823923718)

CREATE TABLE RoomStatus(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	RoomStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO RoomStatus(RoomStatus) VALUES
('Needs Cleaning'),
('Ready'),
('Out of order')

CREATE TABLE RoomTypes(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	RoomType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO RoomTypes(RoomType) VALUES
('Single'),
('Double'),
('Apartament')

CREATE TABLE BedTypes(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	BedType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO BedTypes(BedType) VALUES
('Single'),
('Double'),
('Baby')


CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType INT NOT NULL,
	FOREIGN KEY(RoomType) REFERENCES RoomTypes(Id),
	BedType INT NOT NULL,
	FOREIGN KEY(BedType) REFERENCES BedTypes(Id),
	Rate DECIMAL(6,2) NOT NULL,
	RoomStatus BIT NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus) VALUES
(23, 2, 2, 20.0, 0),
(223, 3, 1, 18.0, 1),
(431, 2, 1, 40.0, 0)

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT,
	PaymentDate DATETIME,
	AccountNumber INT,
	FirstDateOccupied DATETIME,
	LastDateOccupied DATETIME, 
	TotalDays INT, 
	AmountCharged DECIMAL(15,2),
	TaxRate INT, 
	TaxAmount INT,
	PaymentTotal DECIMAL(15,2),
	Notes NVARCHAR(200)
)


INSERT INTO Payments(EmployeeID)VALUES 
(9260),
(1234),
(1111)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME,
	AccountNumber INT, 
	RoomNumber INT, 
	RateApplied DECIMAL(15,2),
	PhoneCharge VARCHAR(10),
	Notes NVARCHAR(200)
)

INSERT INTO Occupancies(EmployeeId) VALUES
(9260),
(1223),
(1123)


-- Create SoftUni Database

CREATE DATABASE SoftUni
USE SoftUni


CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AddressText NVARCHAR(200),
	TownId INT NOT NULL,
	CONSTRAINT FK_Addresses_TownId FOREIGN KEY(TownId) REFERENCES Towns(Id)
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30),
	LastName NVARCHAR(30),
	JobTitle NVARCHAR(20) NOT NULL,
	DepartmantId INT NOT NULL,
	CONSTRAINT FK_Employees_DepartmentId FOREIGN KEY(DepartmantId) REFERENCES Departments(Id),
	HireDate DATE,
	Salary DECIMAL(15,2), 
	AddressId INT NOT NULL,
	CONSTRAINT FK_Employees_AddressId FOREIGN KEY(AddressId) REFERENCES Addresses(Id)
)


INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmantId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '01-02-2013', 3500.00)
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '09-12-2007', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '08-28-2016', 599.88),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08-28-2016', 525.25)


INSERT INTO Towns([Name])VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments([Name])VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

--•	Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments 
SELECT * FROM Employees

--•	Basic Select All Fields and Order Them
SELECT * FROM Towns ORDER BY [Name]
SELECT * FROM Departments ORDER BY [Name]
SELECT * FROM Employees ORDER BY Salary DESC

--•	Basic Select Some Fields


SELECT [Name] FROM Towns ORDER BY [Name]
SELECT [Name] FROM Departments ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC


--•	Increase Employees Salary

UPDATE Employees
	SET Salary *= 1.10

SELECT Salary FROM Employees

--•	Decrease Tax Rate

UPDATE Payments
	SET TaxRate *= 0.97

SELECT TaxRate FROM Payments

--•	Delete All Records

DELETE FROM Occupancies