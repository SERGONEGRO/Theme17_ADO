CREATE TABLE [dbo].[Workers] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [workerName]    NVARCHAR (50) NOT NULL,
    [idBoss]        INT           NOT NULL,
    [idDescription] INT           NOT NULL
);



CREATE TABLE [dbo].[Bosses] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [workerName]     NVARCHAR (50) NOT NULL,
    [departmentName] NVARCHAR (50) NOT NULL
);



CREATE TABLE [dbo].[Workers] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [workerName]    NVARCHAR (50) NOT NULL,
    [idBoss]        INT           NOT NULL,
    [idDescription] INT           NOT NULL
);


SET IDENTITY_INSERT [dbo].[Workers] ON
INSERT INTO [dbo].[Workers] ([id], [workerName], [idBoss], [idDescription]) VALUES (1, N'Сотрудник 1', 1, 1)
INSERT INTO [dbo].[Workers] ([id], [workerName], [idBoss], [idDescription]) VALUES (2, N'Сотрудник 2', 1, 2)
INSERT INTO [dbo].[Workers] ([id], [workerName], [idBoss], [idDescription]) VALUES (3, N'Сотрудник 3', 1, 1)
INSERT INTO [dbo].[Workers] ([id], [workerName], [idBoss], [idDescription]) VALUES (4, N'Сотрудник 4', 1, 1)
INSERT INTO [dbo].[Workers] ([id], [workerName], [idBoss], [idDescription]) VALUES (5, N'Сотрудник 5', 1, 1)
INSERT INTO [dbo].[Workers] ([id], [workerName], [idBoss], [idDescription]) VALUES (6, N'Сотрудник 6', 2, 1)
INSERT INTO [dbo].[Workers] ([id], [workerName], [idBoss], [idDescription]) VALUES (7, N'Сотрудник 7', 2, 1)
INSERT INTO [dbo].[Workers] ([id], [workerName], [idBoss], [idDescription]) VALUES (8, N'Сотрудник 8', 2, 2)
INSERT INTO [dbo].[Workers] ([id], [workerName], [idBoss], [idDescription]) VALUES (9, N'Сотрудник 9', 2, 2)
INSERT INTO [dbo].[Workers] ([id], [workerName], [idBoss], [idDescription]) VALUES (10, N'Сотрудник 10', 3, 3)
SET IDENTITY_INSERT [dbo].[Workers] OFF


SELECT * FROM Workers



SET IDENTITY_INSERT [dbo].[Bosses] ON
INSERT INTO [dbo].[Bosses] ([id], [workerName], [departmentName]) VALUES (1, N'Начальник 1', N'Отдел 1')
INSERT INTO [dbo].[Bosses] ([id], [workerName], [departmentName]) VALUES (2, N'Начальник 2', N'Отдел 2')
INSERT INTO [dbo].[Bosses] ([id], [workerName], [departmentName]) VALUES (3, N'Начальник 3', N'Отдел 3')
SET IDENTITY_INSERT [dbo].[Bosses] OFF

SELECT * FROM Bosses


SET IDENTITY_INSERT [dbo].[Description] ON
INSERT INTO [dbo].[Description] ([id], [value]) VALUES (1, N'Замечание 1')
INSERT INTO [dbo].[Description] ([id], [value]) VALUES (2, N'Замечание 2')
INSERT INTO [dbo].[Description] ([id], [value]) VALUES (3, N'Замечание 3')
INSERT INTO [dbo].[Description] ([id], [value]) VALUES (4, N'Замечание 1')
INSERT INTO [dbo].[Description] ([id], [value]) VALUES (5, N'Замечание 2')
INSERT INTO [dbo].[Description] ([id], [value]) VALUES (6, N'Замечание 3')
INSERT INTO [dbo].[Description] ([id], [value]) VALUES (7, N'Замечание 1')
INSERT INTO [dbo].[Description] ([id], [value]) VALUES (8, N'Замечание 2')
INSERT INTO [dbo].[Description] ([id], [value]) VALUES (9, N'Замечание 3')
SET IDENTITY_INSERT [dbo].[Description] OFF


SELECT * FROM [dbo].[Description]




SELECT 
Workers.id as 'ID',
Workers.workerName as 'Имя сотрудника',
Bosses.workerName  as 'Имя начальника',
Bosses.departmentName  as 'Имя отдела',
[Description].[value] as 'Замечание'
FROM  Workers, Bosses, [Description]
WHERE Workers.idBoss = Bosses.id and Workers.idDescription = [Description].id


SELECT 
*
FROM  Workers
WHERE Workers.id > 5

