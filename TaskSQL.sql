CREATE TABLE Pupil
(
    Id int NOT NULL IDENTITY PRIMARY KEY,
    FName nvarchar(20),
	LName nvarchar(20),
	Sex nvarchar(5),
);

CREATE TABLE Teacher
(
    Id int NOT NULL IDENTITY PRIMARY KEY,
    FName nvarchar(20),
	LName nvarchar(20),
	Sex nvarchar(5),
);

CREATE TABLE Subjects(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	FName nvarchar(20)
);

CREATE TABLE Grades(
	StudentID int NOT NULL FOREIGN KEY REFERENCES Pupil(Id),
	TeacherID int NOT NULL FOREIGN KEY REFERENCES Teacher(Id),
	SubjectID int NOT NULL FOREIGN KEY REFERENCES Subjects(Id),
	Grade nvarchar(10),
	PRIMARY KEY(StudentID, TeacherID, SubjectID)
);

INSERT Pupil VALUES
		(N'გიორგი',N'ჯიბლაძე','M'),
		(N'ლაშა',N'ჩიხლაძე','M'),
		(N'ვალერი',N'ჭავჭავაძე','M'),
		(N'მარი',N'სიმონიშვილი','F')

INSERT Teacher VALUES
		(N'ლელა',N'ჯიბლაძე','F'),
		(N'დალი',N'ჩიხლაძე','F'),
		(N'ინგა',N'ჭავჭავაძე','F'),
		(N'ეკა',N'სიმონიშვილი','F')

INSERT Subjects VALUES
		(N'მათემატიკა'),
		(N'ფიზიკა'),
		(N'ქიმია'),
		(N'ისტორია')

INSERT Grades VALUES
		('1','1','1',N'10ა'),
		('1','2','2',N'11ბ'),
		('1','3','3',N'12გ'),
		('2','1','1',N'12გ'),
		('3','2','2',N'12გ')

SELECT FName,LName FROM Teacher 
WHERE Id IN (SELECT TeacherID FROM Grades
WHERE StudentID IN (SELECT Id FROM Pupil
WHERE FName = N'გიორგი')
);
