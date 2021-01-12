create table Course
(
	CourseId int identity(1,1) primary key,
	Title nvarchar(50) null,
	Credits int null
)