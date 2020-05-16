
CREATE DATABASE  User_Prize
GO 

USE User_Prize  
GO 
DROP Table if Exists Users;
DROP Table if Exists Prizes;  
DROP Table if Exists User_Prize;   
GO



USE User_Prize  
GO 
ALTER DATABASE User_Prize COLLATE Cyrillic_General_100_CI_AI

CREATE TABLE Users 
	(UserID int PRIMARY KEY NOT NULL IDENTITY ,  
	Age int NOT NULL,  
    DateOfBirth  DateTime NOT NULL,
	UserName varchar(50) NOT NULL unique)  
GO  

CREATE TABLE Prizes
   (PrizeId int Primary Key Not null IDENTITY,
	Title varchar(100)  NOT NULL unique)
GO  
CREATE TABLE User_Prize
   (id int PRIMARY KEY NOT NULL IDENTITY,
   UserId int NOT NULL,  
   PrizeId int NOT NULL)  
GO 


IF OBJECT_ID ( 'dbo.[INSERT_Prize]') IS NOT NULL
    DROP PROCEDURE dbo.[INSERT_Prize]
GO
CREATE PROCEDURE [dbo].[INSERT_Prize] 
@Title varchar(100)
AS
    INSERT INTO [dbo].Prizes(Title)	values(@Title)
GO


IF OBJECT_ID ( 'dbo.[Delete_Prize]') IS NOT NULL
    DROP PROCEDURE dbo.Delete_Prize
GO
CREATE PROCEDURE [dbo].Delete_Prize 
@id int
AS
    Delete from [dbo].Prizes
	where PrizeId = @id
GO


IF OBJECT_ID ( 'dbo.[GetAll_Prize]') IS NOT NULL
    DROP PROCEDURE dbo.GetAll_Prize
GO
CREATE PROCEDURE [dbo].GetAll_Prize 
AS
    Select * from Prizes
Go
	

IF OBJECT_ID ( 'dbo.[GetById_Prize]') IS NOT NULL
    DROP PROCEDURE dbo.GetById_Prize
GO
CREATE PROCEDURE [dbo].GetById_Prize 
@ID int
AS
    Select * from Prizes where PrizeId = @ID
Go



IF OBJECT_ID ( 'dbo.[INSERT_User]') IS NOT NULL
    DROP PROCEDURE dbo.INSERT_User
GO
CREATE PROCEDURE [dbo].INSERT_User 
@UserName varchar(50),
@DateOfBirth datetime,
@Age int
AS
    INSERT INTO [dbo].Users(UserName,Age,DateOfBirth)	values(@UserName,@Age,@DateOfBirth)
GO

IF OBJECT_ID ( 'dbo.[Delete_User]') IS NOT NULL
    DROP PROCEDURE dbo.Delete_User
GO
CREATE PROCEDURE [dbo].Delete_User 
@id int
AS
    Delete from [dbo].Users
	where UserID = @id
GO

IF OBJECT_ID ( 'dbo.[GetAll_User]') IS NOT NULL
    DROP PROCEDURE dbo.GetAll_User
GO
CREATE PROCEDURE [dbo].GetAll_User 
AS
    Select * from Users
Go
	

IF OBJECT_ID ( 'dbo.[GetById_User]') IS NOT NULL
    DROP PROCEDURE dbo.GetById_User
GO
CREATE PROCEDURE [dbo].GetById_User 
@UserID int
AS
    Select * from Users where UserID = @UserID
Go



IF OBJECT_ID ( 'dbo.[INSERT_User_Prize]') IS NOT NULL
    DROP PROCEDURE dbo.INSERT_User_Prize
GO
CREATE PROCEDURE [dbo].INSERT_User_Prize 
@UserId int,
@PrizeId int
AS
    INSERT INTO [dbo].User_Prize(UserId,PrizeId)	values(@UserId,@PrizeId)
GO

IF OBJECT_ID ( 'dbo.[Delete_User_Prize]') IS NOT NULL
    DROP PROCEDURE dbo.Delete_User_Prize
GO
CREATE PROCEDURE [dbo].Delete_User_Prize 
@UserId int
AS
    Delete from [dbo].User_Prize
	where UserID = @UserId
GO
  


IF OBJECT_ID ( 'dbo.[GetOnOne_User_Prize]') IS NOT NULL
    DROP PROCEDURE dbo.GetOnOne_User_Prize
GO
CREATE PROCEDURE [dbo].GetOnOne_User_Prize 
@UserId int
AS
    Select * from User_Prize where UserId = @UserId
Go
