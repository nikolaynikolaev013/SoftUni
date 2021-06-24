CREATE DATABASE MinionsDB 

CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30) NOT NULL)

CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30),CountryCode INT FOREIGN KEY REFERENCES Countries(Id)

CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30),Age INT,TownID INT FOREIGN KEY REFERENCES Towns(Id))

CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30))

CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), EvilnessFactorID INT FOREIGN KEY REFERENCES EvilnessFactors(Id))

CREATE TABLE MinionsVillains(MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))


insert into Countries (Name) values ('Kirk'),('Joelle'),('Rem'),('Xylina'),('Mae'),('Felicdad'),('Lynde'),('Austina'),('Meta'),('Mead')

insert into Towns (Name, CountryCode) values ('Janelle', 2), ('Davis', 6),('Neilla', 2),('Ibrahim', 10),('Ernestus', 7),('Wilhelm', 2),('Angie', 4),('Alisa', 8),('Moritz', 2),('Benji', 5);


insert into Minions (Name, Age, TownID) values ('Archibald', 80, 10),('Cecilla', 86, 1),('Conrade', 45, 8),('Oliy', 76, 6),('Fleurette', 57, 5),('Diandra', 17, 3),('Tandie', 14, 5),('Valina', 21, 4),('Lavinia', 91, 5),('Mufi', 12, 6);


insert into EvilnessFactors (Name) values ('Mabelle'), ('Cchaddie'), ('Jasen'), ('Patti'), ('Moritz'), ('Julie'), ('Alys'), ('Stevy'), ('Crystie'), ('Nial');



insert into Villains (Name, EvilnessFactorID) values ('Antonin', 7), ('Krispin', 8), ('Rori', 1), ('Berty', 8), ('Moreen', 3), ('Amelie', 10), ('Sammy', 2), ('Justus', 4), ('Gaven', 6), ('Sly', 2);


insert into MinionsVillains (MinionId, VillainId) values (9, 7), (8, 8), (1, 6), (5, 4), (8, 10), (9, 6), (10, 7), (4, 6), (5, 6), (9, 4);


--2.	Villain Names

SELECT v.[Name], COUNT(mv.MinionId) AS [Count]
	FROM Villains v
JOIN MinionsVillains mv ON mv.VillainId = v.Id
GROUP BY v.Id, v.Name
HAVING COUNT(mv.MinionId) > 3
ORDER BY COUNT(mv.MinionId) DESC

--3.	Minion Names

SELECT COUNT(*) FROM Villains
	WHERE Id = 4;

SELECT m.Name, m.Age
	FROM Villains v
JOIN MinionsVillains mv ON mv.VillainId = v.Id
JOIN Minions m ON m.Id = mv.MinionId
WHERE v.Id = 4
ORDER BY m.Name