INSERT INTO [Course](Name)
	VALUES
	('CS 460'),
	('MTH 354'),
	('CS 407');

INSERT INTO [Assignment](Name,Due,Completion,Priority,Notes,CourseID)
	VALUES
	('Homework #2: Graph Theory','2020-01-15 11:59:00',0,9,'Understanding paths, circuits, and cycles.',2),
	('Homework #1: HTML and CSS','2020-01-15 11:59:00',0,5,'Creating and styling a webpage',1),
	('Homework #1: Kotlin','2020-01-18 11:59:00',0,3,'Solving basic problems with Kotlin code',3);

INSERT INTO [Tag](Name)
	VALUES
	('Reading'),
	('Coding'),
	('Hard');

INSERT INTO [AssignmentTag](AssignmentID,TagNameID)
	VALUES
	(1,3),
	(2,1),
	(2,2);