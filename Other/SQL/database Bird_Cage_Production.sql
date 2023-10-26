-- Tạo database Bird_Cage_Production
--USE master
--DROP DATABASE [Bird_Cage_Production];
--CREATE DATABASE [Bird_Cage_Production];
--USE [Bird_Cage_Production]

-- Tạo bảng Status
CREATE TABLE OrderStatus(
   StatusId INT PRIMARY KEY,
   [Name] VARCHAR(50)
);

CREATE TABLE AccountStatus(
   StatusId INT PRIMARY KEY,
   [Name] VARCHAR(50)
);
CREATE TABLE CustomerStatus(
   StatusId INT PRIMARY KEY,
   [Name] VARCHAR(50)
);
CREATE TABLE ProgressStatus(
   StatusId INT PRIMARY KEY,
   [Name] VARCHAR(50)
);


CREATE TABLE Role(
   RoleId INT PRIMARY KEY,
   RoleName VARCHAR(50)
);

CREATE TABLE Color(
   ColorId INT PRIMARY KEY,
   ColorName VARCHAR(50)
);

-- Tạo bảng Customer
CREATE TABLE Customer(
   CustomerId INT IdENTITY(1,1) PRIMARY KEY,
   FullName VARCHAR(50),
   [Address] VARCHAR(50),
   PhoneNumber VARCHAR(50) UNIQUE,
   Email VARCHAR(50) UNIQUE,
   StatusId INT,
);

-- Tạo bảng Account
CREATE TABLE Account(
   AccountId INT IdENTITY(1,1) PRIMARY KEY,
   FullName VARCHAR(50),   
   [Address] VARCHAR(50),
   PhoneNumber VARCHAR(50),
   Email VARCHAR(50),
   [Password] VARCHAR(50),
   RoleId INT,
   StatusId VARCHAR(50),
);

-- Tạo bảng Order
CREATE TABLE [Order](
   OrderId INT IdENTITY(1,1) PRIMARY KEY,
   DayCreated datetime,
   TotalPrice DECIMAL(10, 2),
   StatusId VARCHAR(50),
   [Address] VARCHAR(50),
   AccountId INT,
   CustomerId INT,
   FOREIGN KEY (AccountId) REFERENCES Account(AccountId),
   FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
);

-- Tạo bảng Part 
CREATE TABLE Part(
   PartId INT IdENTITY(1,1) PRIMARY KEY,
   [Name] VARCHAR(50),
   [Description] VARCHAR(100),
   Shape VARCHAR(50),
   Material VARCHAR(50),
   Size VARCHAR(10),
   ColorId INT,
   Cost FLOAT,
);

-- Tạo bảng Bird_Cage_Category
CREATE TABLE BirdCage(
   BirdCageId INT IdENTITY(1,1) PRIMARY KEY,
   [Name] VARCHAR(50),
   [Description] VARCHAR(100),
);

-- Tạo bảng Part_Item
CREATE TABLE PartItem(
   PartItemId INT IdENTITY(1,1) PRIMARY KEY,
   Quantity INT,
   PartId INT,
   BirdCageId INT,
   FOREIGN KEY (PartId) REFERENCES Part(PartId),
   FOREIGN KEY (BirdCageId) REFERENCES BirdCage(BirdCageId),
);

-- Tạo bảng Order_Detail
CREATE TABLE OrderDetail(
    OrderDetailId INT IdENTITY(1,1) PRIMARY KEY,
	Quantity INT,
	BirdCageId INT,
	OrderId INT,	
	FOREIGN KEY (BirdCageId) REFERENCES BirdCage(BirdCageId),
	FOREIGN KEY (OrderId) REFERENCES [Order](OrderId),
);

-- Tạo bảng Procedure 
CREATE TABLE [Procedure](
  ProcedureId INT IdENTITY(1,1) PRIMARY KEY,
  BirdCageId INT,
  FOREIGN KEY (BirdCageId) REFERENCES BirdCage(BirdCageId)
);

-- Tạo bảng ProcedureStep 
CREATE TABLE ProcedureStep(
   ProcedureStepId INT IdENTITY(1,1) PRIMARY KEY,   
   Description VARCHAR(50),
   TimeNeeded FLOAT,
   Cost FLOAT,
   NumOfWorker INT,
   ProcedureId INT,
   FOREIGN KEY (ProcedureId) REFERENCES [Procedure](ProcedureId),
);

-- Tạo bảng ProductionPlan
CREATE TABLE Progress(
   ProgressId INT IdENTITY(1,1) PRIMARY KEY,
   StartDay DATE,
   EndDay DATE,
   StatusId INT,
   OrderDetailId INT,
   AccountId INT,
   FOREIGN KEY (OrderDetailId) REFERENCES OrderDetail(OrderDetailId),
   FOREIGN KEY (AccountId) REFERENCES Account(AccountId)
);






