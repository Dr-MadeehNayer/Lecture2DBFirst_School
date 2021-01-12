create table Student
(
	StudentId int identity(1,1) primary key,
	FirstName nvarchar(50) null,
	LastName nvarchar(50) null,
	EnrollmentDate datetime null
)