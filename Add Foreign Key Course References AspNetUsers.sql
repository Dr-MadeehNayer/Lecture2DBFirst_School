create view v_getTrainers
as
select AspNetUsers.Id,username
from AspNetRoles,AspNetUserRoles,AspNetUsers
where AspNetRoles.Id= AspNetUserRoles.RoleId
and AspNetUserRoles.UserId=AspNetUsers.Id
and name='trainer'

select * from v_getTrainers

alter table course
add InstructorId nvarchar(128);

alter table course
add constraint fk_course_instructor_user 
foreign key (InstructorID) references AspNetUsers(Id)