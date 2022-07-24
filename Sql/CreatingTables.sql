use Project

create table Subjects(
	SubjectId int identity(1,1) constraint PK_Subjects primary key,
	Classroom int,
	SubjectName nvarchar(30),
	PhotoFile nvarchar(500)
) 

create table Schedule(
	ScheduleId int identity(1,1) constraint  PK_Schedule primary key,
	DayOfTheWeek nvarchar(20)
)

create table ScheduleSubject(
	ScheduleSubjectId int identity(1,1) constraint PK_ScheduleSubject primary key,
	ScheduleId int constraint FK_ScheduleSubject_Schedule references Schedule(ScheduleId),
	SubjectId int constraint FK_ScheduleSubject_Subjects references Subjects(SubjectId) on delete cascade
)

create table Teacher(
	TeacherId int identity(1,1) constraint PK_Teachers primary key,
	TeacherName nvarchar(50),
	TaughtSubject int constraint FK_Teacher_Subjects references Subjects(SubjectId) on delete cascade,
	PhotoFile nvarchar(500)
)
