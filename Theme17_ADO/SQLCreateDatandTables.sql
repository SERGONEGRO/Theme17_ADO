CREATE TABLE [dbo].[Clients] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (20) NOT NULL,
    [Surname]       NVARCHAR (20) NOT NULL,
    [Lastname]      NVARCHAR (20) NOT NULL,
    [Phone]         NVARCHAR (15) NULL,
    [Email]         NVARCHAR (50) NOT NULL
);


SET IDENTITY_INSERT [dbo].[Clients] ON
INSERT INTO [dbo].[Clients] ([id], [Name], [Surname],[Lastname],[Phone],[Email] ) VALUES (1, N'Иванов 1',N'Иван', N'Иваныч', '+79539990401', 'rez1@gmail.com')
INSERT INTO [dbo].[Clients] ([id], [Name], [Surname],[Lastname],[Phone],[Email] ) VALUES (2, N'Иванов 2',N'Иван', N'Иваныч', '+79539990402', 'rez2@gmail.com')
INSERT INTO [dbo].[Clients] ([id], [Name], [Surname],[Lastname],[Phone],[Email] ) VALUES (3, N'Иванов 3',N'Иван', N'Иваныч', '+79539990403', 'rez3@gmail.com')
INSERT INTO [dbo].[Clients] ([id], [Name], [Surname],[Lastname],[Phone],[Email] ) VALUES (4, N'Иванов 4',N'Иван', N'Иваныч', '+79539990404', 'rez4@gmail.com')
INSERT INTO [dbo].[Clients] ([id], [Name], [Surname],[Lastname],[Phone],[Email] ) VALUES (5, N'Иванов 5',N'Иван', N'Иваныч', '+79539990405', 'rez5@gmail.com')
INSERT INTO [dbo].[Clients] ([id], [Name], [Surname],[Lastname],[Phone],[Email] ) VALUES (6, N'Иванов 6',N'Иван', N'Иваныч', '+79539990406', 'rez6@gmail.com')
INSERT INTO [dbo].[Clients] ([id], [Name], [Surname],[Lastname],[Phone],[Email] ) VALUES (7, N'Иванов 7',N'Иван', N'Иваныч', '+79539990407', 'rez7@gmail.com')
INSERT INTO [dbo].[Clients] ([id], [Name], [Surname],[Lastname],[Phone],[Email] ) VALUES (8, N'Иванов 8',N'Иван', N'Иваныч', '+79539990408', 'rez8@gmail.com')
INSERT INTO [dbo].[Clients] ([id], [Name], [Surname],[Lastname],[Phone],[Email] ) VALUES (9, N'Иванов 9',N'Иван', N'Иваныч', '+79539990409', 'rez9@gmail.com')
INSERT INTO [dbo].[Clients] ([id], [Name], [Surname],[Lastname],[Phone],[Email] ) VALUES (10, N'Иванов 10',N'Иван', N'Иваныч', '+79539990410', 'rez10@gmail.com')
INSERT INTO [dbo].[Clients] ([id], [Name], [Surname],[Lastname],[Phone],[Email] ) VALUES (11, N'Иванов 11',N'Иван', N'Иваныч', '+79539990411', 'rez11@gmail.com')
SET IDENTITY_INSERT [dbo].[Clients] OFF


SELECT * FROM [Clients]



SELECT 
*
FROM  [Clients]
WHERE [Clients].id > 5

