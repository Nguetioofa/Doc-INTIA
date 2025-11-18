CREATE database AntiaAppDB

USE AntiaAppDB;
GO


--  Sites
CREATE TABLE Sites
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nom NVARCHAR(200) NOT NULL,
    Ville NVARCHAR(100) NOT NULL,
    Adresse NVARCHAR(300) NULL,
    Telephone NVARCHAR(20) NULL,
    CONSTRAINT PK_Sites PRIMARY KEY (Id),
);
GO


-- Clients
CREATE TABLE Clients
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nom NVARCHAR(100) NOT NULL,
    Prenom NVARCHAR(100) NOT NULL,
    Telephone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(150) NULL,
    Adresse NVARCHAR(300) NULL,
    SiteId INT NOT NULL,
    DateCreation DATETIME2(7) NOT NULL DEFAULT GETUTCDATE(),
    DateModification DATETIME2(7) NULL,
    CONSTRAINT PK_Clients PRIMARY KEY (Id),
    CONSTRAINT FK_Clients_Sites FOREIGN KEY (SiteId)  REFERENCES Sites(Id)
);
GO

-- Assurances
CREATE TABLE Assurances
(
    Id INT IDENTITY(1,1) NOT NULL,
    Type NVARCHAR(20) NOT NULL, 
    Montant DECIMAL(18,2) NOT NULL,
    DateDebut DATE NOT NULL,
    DateFin DATE NOT NULL,
    Statut NVARCHAR(20) NOT NULL,
    Description NVARCHAR(500) NULL,
    ClientId INT NOT NULL,
    DateCreation DATETIME2(7) NOT NULL DEFAULT GETUTCDATE(),
    DateModification DATETIME2(7) NULL,
    CONSTRAINT PK_Assurances PRIMARY KEY (Id),
    CONSTRAINT FK_Assurances_Clients FOREIGN KEY (ClientId) REFERENCES Clients(Id),
    CONSTRAINT CHK_Assurances_Montant CHECK (Montant >= 0),
    CONSTRAINT CHK_Assurances_Dates CHECK (DateFin > DateDebut)
);
GO

INSERT INTO Sites (Nom, Ville, Adresse, Telephone)
VALUES 
    ('Direction Generale', 'Yaounde', '-', '696999999'),
    ('Succursale Douala', 'Douala', '-', '696999999'),
    ('Succursale Yaounde', 'Yaounde', '-', '696999999');
GO
