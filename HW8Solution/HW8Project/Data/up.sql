CREATE TABLE [Course] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [Assignment] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(50) NOT NULL,
  [Due] datetime,
  [Completion] bit NOT NULL,
  [Priority] int,
  [Notes] nvarchar(256),
  [CourseID] int
)
GO

CREATE TABLE [Tag] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [AssignmentTag] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [AssignmentID] int,
  [TagNameID] int
)
GO

ALTER TABLE [Assignment] ADD FOREIGN KEY ([CourseID]) REFERENCES [Course] ([ID])
GO

ALTER TABLE [AssignmentTag] ADD FOREIGN KEY ([AssignmentID]) REFERENCES [Assignment] ([ID])
GO

ALTER TABLE [AssignmentTag] ADD FOREIGN KEY ([TagNameID]) REFERENCES [Tag] ([ID])
GO
