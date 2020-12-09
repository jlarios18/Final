ALTER TABLE [Assignment] DROP CONSTRAINT [Assignment_Fk_Course];
ALTER TABLE [Assignment] DROP CONSTRAINT [Assignment_Fk_Tag];
ALTER TABLE [Tag] DROP CONSTRAINT [Tag_Fk_Assignment];
GO

DROP TABLE [Course];
DROP TABLE [AssignmentTag];
DROP TABLE [Assignment];
DROP TABLE [Tag];