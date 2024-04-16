USE appClean
GO


CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(30) NOT NULL,
    LastName VARCHAR(50),
    Email VARCHAR(150) NOT NULL,
    Password VARCHAR(20) NOT NULL,
	AccessToken VARCHAR(MAX),
	Expiration DATETIME,
    Active BIT NOT NULL
)
GO