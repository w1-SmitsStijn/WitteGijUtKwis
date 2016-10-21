USE master
GO

DROP DATABASE WitteGijUtKwis
GO

CREATE DATABASE WitteGijUtKwis
GO

USE WitteGijUtKwis
GO

CREATE TABLE Plaats (
	plaatsnaam 			VARCHAR(35) UNIQUE,
	carnavalsnaam 		VARCHAR(35),
	latitude 			FLOAT,
	longitude 			FLOAT,
	PRIMARY KEY(plaatsnaam)
);

CREATE TABLE Speler (
	spelersnaam 	VARCHAR(20) UNIQUE,
	wachtwoord 		VARCHAR(15) NOT NULL,
	plaatsnaam 		VARCHAR(35) NOT NULL,
	leeftijd 		INT NOT NULL,
	score			INT,
	carnavalsnaam	VARCHAR(35),
	PRIMARY KEY(spelersnaam),
	FOREIGN KEY (plaatsnaam) REFERENCES Plaats(plaatsnaam)
);

CREATE TABLE Vraag (
	spelersnaam 	VARCHAR(20) NOT NULL,
	vraagid 		INT UNIQUE,
	tijdstip 		DATETIME NOT NULL,
	antwoorden 		VARCHAR(100) NOT NULL,
	PRIMARY KEY(spelersnaam, vraagid),
	FOREIGN KEY (spelersnaam) REFERENCES Speler(spelersnaam)
);

INSERT INTO Plaats (plaatsnaam, carnavalsnaam, latitude, longitude) VALUES ('Berlicum', 'Dn Birrekoal', 1, 1);

INSERT INTO Speler (spelersnaam, wachtwoord, plaatsnaam, leeftijd, carnavalsnaam) VALUES ('Stijn', 'Stijn', 'Berlicum', 18, 'Dn Birrekoal');