-- Tạo database Bird_Cage_Production
  USE master
  DROP DATABASE [Bird_Cage_Production];
  CREATE DATABASE [Bird_Cage_Production];
  USE [Bird_Cage_Production]

-- Tạo bảng Status
CREATE TABLE OrderStatus(
   StatusId INT PRIMARY KEY,
   [Name] VARCHAR(50)
);
INSERT INTO OrderStatus (StatusId, [Name])
VALUES (0, 'Pending');
INSERT INTO OrderStatus (StatusId, [Name])
VALUES (1, 'Approved');
INSERT INTO OrderStatus (StatusId, [Name])
VALUES (2, 'Is producing');
INSERT INTO OrderStatus (StatusId, [Name])
VALUES (3, 'Produced');
INSERT INTO OrderStatus (StatusId, [Name])
VALUES (4, 'Delivering');
INSERT INTO OrderStatus (StatusId, [Name])
VALUES (5, 'Completed');

CREATE TABLE AccountStatus(
   StatusId INT PRIMARY KEY,
   [Name] VARCHAR(50)
);
INSERT INTO AccountStatus (StatusId, [Name])
VALUES (0, 'Active');
INSERT INTO AccountStatus (StatusId, [Name])
VALUES (1, 'Banned');

CREATE TABLE CustomerStatus(
   StatusId INT PRIMARY KEY,
   [Name] VARCHAR(50)
);
INSERT INTO CustomerStatus (StatusId, [Name])
VALUES (0, 'Active');
INSERT INTO CustomerStatus (StatusId, [Name])
VALUES (1, 'Inactive');

CREATE TABLE ProgressStatus(
   StatusId INT PRIMARY KEY,
   [Name] VARCHAR(50)
);
INSERT INTO ProgressStatus (StatusId, [Name])
VALUES (0, 'Pending');
INSERT INTO ProgressStatus (StatusId, [Name])
VALUES (1, 'On Progress');
INSERT INTO ProgressStatus (StatusId, [Name])
VALUES (2, 'Conpleted');


CREATE TABLE Role(
   RoleId INT PRIMARY KEY,
   RoleName VARCHAR(50)
);
INSERT INTO Role (RoleId, RoleName)
VALUES (0, 'Undefined');
INSERT INTO Role (RoleId, RoleName)
VALUES (1, 'Admin');
INSERT INTO Role (RoleId, RoleName)
VALUES (2, 'Manager');
INSERT INTO Role (RoleId, RoleName)
VALUES (3, 'Staff');

CREATE TABLE Color(
   ColorId INT PRIMARY KEY,
   ColorName VARCHAR(50)
);
INSERT INTO Color (ColorId, ColorName)
VALUES (0, 'Undefined');
INSERT INTO Color (ColorId, ColorName)
VALUES (1, 'Purple');
INSERT INTO Color (ColorId, ColorName)
VALUES (2, 'Pink');
INSERT INTO Color (ColorId, ColorName)
VALUES (3, 'Blue');
INSERT INTO Color (ColorId, ColorName)
VALUES (4, 'Green');
INSERT INTO Color (ColorId, ColorName)
VALUES (5, 'Beige');


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
   PhoneNumber VARCHAR(50) UNIQUE,
   Email VARCHAR(50) UNIQUE,
   [Password] VARCHAR(50),
   RoleId INT,
   StatusId INT,
);

-- Tạo bảng Order
CREATE TABLE [Order](
   OrderId INT IdENTITY(1,1) PRIMARY KEY,
   DayCreated datetime,
   TotalPrice DECIMAL(10, 2),
   StatusId INT,
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
   [Code] Varchar(10),
   [Description] VARCHAR(100),
   Shape VARCHAR(50),
   Material VARCHAR(50),
   Size VARCHAR(10),
   ColorId INT,
   Cost FLOAT,
);

-- Tạo bảng Bird_Cage
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
	CurrentStep INT,
	FOREIGN KEY (BirdCageId) REFERENCES BirdCage(BirdCageId),
	FOREIGN KEY (OrderId) REFERENCES [Order](OrderId)
);

-- Tạo bảng Procedure 
CREATE TABLE [Procedure](
  ProcedureId INT IdENTITY(1,1) PRIMARY KEY,
  BirdCageId INT,
  Quantity INT,
  FOREIGN KEY (BirdCageId) REFERENCES BirdCage(BirdCageId)
);

-- Tạo bảng ProcedureStep 
CREATE TABLE ProcedureStep(
   ProcedureStepId INT IdENTITY(1,1) PRIMARY KEY, 
   StepNum INT,
   Description VARCHAR(50),
   TimeNeeded INT,
   Cost FLOAT,
   NumOfWorker INT,
   ProcedureId INT,
   FOREIGN KEY (ProcedureId) REFERENCES [Procedure](ProcedureId),
);

-- Tạo bảng ProductionPlan
CREATE TABLE Progress(
   ProgressId INT IdENTITY(1,1) PRIMARY KEY,
   ProgressNum INT UNIQUE,
   StartDay DATE,
   EndDay DATE,
   StatusId INT,
   OrderDetailId INT,
   AccountId INT,
   FOREIGN KEY (OrderDetailId) REFERENCES OrderDetail(OrderDetailId),
   FOREIGN KEY (AccountId) REFERENCES Account(AccountId)
);


--Account sample data
INSERT INTO Account (FullName, [Address], PhoneNumber, Email, [Password], RoleId, StatusId)
VALUES ('Nguyen Van Chi', '135 Le Than Ton', '0123456789', 'admin1@birdcage.com', '@123', 0, 0);
INSERT INTO Account (FullName, [Address], PhoneNumber, Email, [Password], RoleId, StatusId)
VALUES ('Pham Nhat Mai', '99 Bui Thi Xuan', '0987654321', 'admin2@birdcage.com', '@123', 0, 0);


--Customer sample data
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('John Doe', '123 Main St', '555-1111', 'johndoe1@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Jane Smith', '456 Elm St', '555-1112', 'janesmith2@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('David Johnson', '789 Oak St', '555-1113', 'davidjohnson3@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Sarah Williams', '321 Maple St', '555-1114', 'sarahwilliams4@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Michael Brown', '654 Pine St', '555-1115', 'michaelbrown5@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Emily Wilson', '987 Cedar St', '555-1116', 'emilywilson6@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Daniel Thompson', '654 Birch St', '555-1117', 'danielthompson7@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Olivia Davis', '321 Oak St', '555-1118', 'oliviadavis8@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('James Anderson', '789 Maple St', '555-1119', 'jamesanderson9@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Sophia Martinez', '456 Elm St', '555-1120', 'sophiamartinez10@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Ethan Clark', '987 Pine St', '555-1121', 'ethanclark11@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Ava Rodriguez', '654 Cedar St', '555-1122', 'avarodriguez12@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Logan Lee', '321 Birch St', '555-1123', 'loganlee13@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Mia Turner', '789 Oak St', '555-1124', 'miaturner14@example.com', 1);
INSERT INTO customer (FullName, Address, PhoneNumber, Email, StatusId)
VALUES ('Lucas Scott', '456 Maple St', '555-1125', 'lucasscott15@example.com', 1);

--Birdcage Sample Data
INSERT INTO BirdCage([Name],[Description]) 
VALUES('A very nice bird cage', 'This bird cage is very nice'); 
INSERT INTO BirdCage([Name],[Description]) 
VALUES('A very bad bird cage', 'This bird cage is very bad');
INSERT INTO BirdCage([Name],[Description]) 
VALUES('A very handsome bird cage', 'This bird cage is very handsome');

--Order Sample Data
INSERT INTO [Order](DayCreated,TotalPrice,StatusId,[Address],AccountId,CustomerId) 
VALUES('2021-12-01 14:30:15', 9999, 1, 'sample address', 1, 1); 
--Order Detail Sample Data
INSERT INTO OrderDetail(Quantity,BirdCageId,OrderId) 
VALUES(10, 1, 1);
INSERT INTO OrderDetail(Quantity,BirdCageId,OrderId) 
VALUES(20, 2, 1);
INSERT INTO OrderDetail(Quantity,BirdCageId,OrderId) 
VALUES(30, 3, 1);

