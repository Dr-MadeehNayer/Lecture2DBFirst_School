create table Enrollment
(
	EnrollmentId int identity(1,1) primary key,
	Grade decimal(5,2) null,
	CourseId int not null,
	StudentId int not null,
	foreign key (CourseId)  references Course  (CourseId)  on delete cascade,
	foreign key (StudentId) references Student (StudentId) on delete cascade
)