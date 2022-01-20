--1. create database
create database Helperland;

--2. create usertable
CREATE TABLE [User]
(
	UserID						int             NOT NULL PRIMARY KEY IDENTITY(1,1),
	FirstName					varchar(25)		NOT NULL,
	LastName					varchar(25),
	Email						varchar(30),
	MobileNo					varchar(15)     NOT NULL UNIQUE,
	Password					varchar(max)	NOT NULL,
	Avtar   					varchar(max),
	Gender						varchar(10)		NOT NULL,
	DateOfBirth					Date,
	IsAprroved					bit				NOT NULL DEFAULT(1),
	IsPetAtHome					bit,
	Nactionality				varchar(20),
	Distance					decimal(5,2),
	UserRegistrationDate		datetime		NOT NULL DEFAULT(25)
);

--3 create UserRole
CREATE TABLE [UserRole]
(
	UserID						int             NOT NULL FOREIGN KEY REFERENCES [User](UserID),
	RoleName					varchar(25)		Not Null 
);

--4 create Address
CREATE TABLE [Address]
(
	AddressID		int				NOT NULL PRIMARY KEY IDENTITY(1,1),
	StreetName		Varchar(max)	NOT NULL,
	HouseNumber		varchar(10)		NOT NULL,
	PostalCode		varchar(10)		NOT NULL,
	City			varchar(15)		NOT NULL,
	PhoneNumber		varchar(15)		NOT NULL

);

--5 create UserAddress
CREATE TABLE [UserAddress]
(
	UserID						int             NOT NULL FOREIGN KEY REFERENCES [User](UserID),
	AddressID					int				NOT NULL FOREIGN KEY REFERENCES [Address](AddressID)
);

--6 create Service
CREATE TABLE [Service]
(
	ServiceID			int						NOT NULL PRIMARY KEY IDENTITY(1,1),
	Date				datetime				NOT NULL,
	IsPet				bit						NOT NULL DEFAULT(0),
	AddressID			int						NOT NULL FOREIGN KEY REFERENCES [Address](AddressID),
	TotalAmount			Decimal(10,2)			NOT NULL,
	Distance			Decimal(5,2),
	ServiceActionID		int						NOT NULL FOREIGN KEY REFERENCES [ServiceAction](ServiceActionID),
	ServiceProviderID	int						NOT NULL FOREIGN KEY REFERENCES [User](UserID),
	CustomerID			int						NOT NULL FOREIGN KEY REFERENCES [User](UserID)

);

--7 create ServiceActions

CREATE TABLE [ServiceAction]
(
	ServiceActionID		int						NOT NULL PRIMARY KEY IDENTITY(1,1),
	ServiceActionName	varchar(15)				NOT NULL
);


--8 create ExtraServices
Create table [ExtraServices]
(
	ExtraServicesId		int						PRIMARY KEY NOT NULL IDENTITY(1,1),
	ServiceID			int						NOT NULL FOREIGN KEY REFERENCES [Service](ServiceID),
	ExtraServicesName	varchar(30)				NOT NULL
);

--9 create ServiceFeedBack
Create table [ServiceFeedback]
(
	ServiceFeedbackId	int						PRIMARY KEY NOT NULL IDENTITY(1,1),
	OnTimeArrival		Decimal(3,1)			NOT NULL,
	Friendly			Decimal(3,1)			NOT NULL,
	QualityOfService	Decimal(3,1)			NOT NULL,
	TotalRating			Decimal(3,1)			NOT NULL,
	Text				varchar(500),
	ServiceId			int						NOT NULL FOREIGN KEY REFERENCES [Service](ServiceID)
);

--10 create ContactUS

Create table [ContactUsDetail]
(
	Id			int								PRIMARY KEY NOT NULL IDENTITY(1,1),
	FirstName	varchar(50)						NOT NULL,
	LastName	varchar(50),
	Mobile		varchar(15),
	Email		varchar(250)					NOT NULL UNIQUE,
	Subject		varchar(50)						NOT NULL,
	Message		varchar(500)					NOT NULL
);
--11 create ResheduleServices

Create table [ResheduleServices]
(
	ResheduleServicesId	int						PRIMARY KEY NOT NULL IDENTITY(1,1),
	ServiceId			int						NOT NULL FOREIGN KEY REFERENCES [Service](ServiceID),
	Text				varchar(500)
);


