use Project

insert into Subjects
	(Classroom, SubjectName,PhotoFile)
values
	(319,'Math','Math.png'),
	(403,'Economics','Eco.png'),
	(100,'PE','PE.png'),
	(304,'CS','CS.png'),
	(113,'Biology','Bio.png'),
	(214,'Web','Web.png'),
	(104,'Art','Art.png'),
	(307,'English','Eng.png'),
	(318,'Physics','Phy.png')

insert into Schedule
	(DayOfTheWeek)
values
	('Monday'),
	('Tuesday'),
	('Wednesday'),
	('Thusrday'),
	('Friday')

insert into Teacher 
	(TeacherName, TaughtSubject,PhotoFile)
values
	('Michael',1,'01.png'),
	('Michel',2,'02.png'),
	('Mike',3,'03.png'),
	('Moroz',4,'04.png'),
	('Mirror',5,'05.png'),
	('Katerine',6,'06.png'),
	('Bob',7,'07.png'),
	('Joe',8,'08.png'),
	('Dave',9,'09.png'),
	('Dave',3,'06.png'),
	('Clark',8,'04.png'),
	('Utop',8,'03.png')


insert into ScheduleSubject 
(ScheduleId, SubjectId)
values
	(1,2),
	(1,3),
	(1,4),
	(1,2),
	(2,3),
	(2,3),
	(2,5),
	(3,5),
	(4,6),
	(4,1),
	(4,5),
	(5,8),
	(5,9),
	(5,7)
