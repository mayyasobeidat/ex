-- Create User Table
CREATE TABLE User_Table(
  ID INT IDENTITY PRIMARY KEY,
  Server_DateTime DATETIME,
  DateTime_UTC DATETIME,
  Update_DateTime_UTC DATETIME,
  Username VARCHAR(255) NOT NULL,
  Email NVARCHAR(255) NOT NULL,
  First_Name NVARCHAR(255) NOT NULL,
  Last_Name NVARCHAR(255) NOT NULL,
  Status INT NOT NULL,
  Gender INT NOT NULL,
  Date_Of_Birth DATETIME NOT NULL
);


-- Create Account Table
CREATE TABLE Account (
  ID INT IDENTITY PRIMARY KEY,
  User_ID INT,
  Server_DateTime DATETIME,
  DateTime_UTC DATETIME,
  Update_DateTime_UTC DATETIME,
  Account_Number VARCHAR(255) NOT NULL,
  Balance MONEY NOT NULL,
  Currency VARCHAR(255) NOT NULL,
  Status INT NOT NULL,
  FOREIGN KEY (User_ID) REFERENCES User_Table(ID)
);