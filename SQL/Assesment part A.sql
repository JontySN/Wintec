create table STAFF
(
StaffID int identity(1, 1) primary key,
FirstName Varchar(20) not null,
LastName varchar(20) not null,
StaffRole varchar(15) check (StaffRole in ('Admin','GP','Surgeon','Reception','GP Intern','Nurse','Senior Nurse','Nurse Intern','Marketing')) not null,
Gender char(1) check(Gender in ('F','M','O')),
DateJoined date not null,
DateLeft date
)

create table PATIENT
(
PatientID int identity(1, 1) primary key,
FirstName varchar(20) not null,
LastName varchar(20) not null,
DOB date,
Phone varchar(15) not null,
StaffID int foreign key references STAFF(StaffID),
Gender char(1) check(Gender in ('F','M','O')) not null,
Primary key (StaffID)
)

Create table SPECIALITY
(
SpecialityID int identity(1, 1) primary key,
SpecName varchar(30) not null,
SpecNotes varchar(100)
)

Create table CHARGES
(
ChargeID int identity(1, 1) primary key,
ChrgDescription varchar(80) not null,
Duration numeric(4,2) check(duration <=60),
HourlyRate int check(HourlyRate <=399)
)
Select *
from CHARGES

create table STAFF_SPECIALITY
(
StaffID int foreign key references STAFF(StaffID),
SpecialityID int foreign key references SPECIALITY(SpecialityID),
DateQualified date,
ValidTillDate date,
Details varchar(100),
primary key (StaffID, SpecialityID)
)

create table CONSULTATION
(
ChargeID int foreign key references Charges(ChargeID),
StaffID int foreign key references Staff(StaffID),
DateConsultated date,
StartTime numeric(4,2),
PatientID int foreign key references Patient(PatientID),
primary key(ChargeID, StaffID, PatientID)
)
select *
from CONSULTATION

insert into STAFF values
('Homer','Robbins','GP','M','21-Apr-2015', null),
('Marge','Johnson','Reception','F','27-Apr-2015', null),
('Patty','Reyes','Reception','F','23-Mar-2016', null),
('Selma','Bouvier','Admin','F','27-Mar-2016', null),
('Ned','Flanders','Nurse','M','18-Oct-2016', null),
('Lisa','Simpson','GP','F','04-Dec-2017', null),
('Disco','Stu','Nurse Intern','M','27-Mar-2018','17-Aug-2018'),
('Jonty','Southcombe-Nguyen','Nurse Intern','M','21-Aug-2023', null)

insert into PATIENT values
('Caroline','Smith','21-Jun-1981','0271234567',1,'F'),
('James','Miller','23-May-1972','0221234567',6,'M'),
('Sarah','Walker','09-Apr-1991','0211234567',6,'F'),
('Sam','Paul','18-Jan-1988','0272345678',1,'M'),
('Jack','Johnson','26-Oct-1974','0212345678',1,'M')

insert into SPECIALITY values
('GP License','General GP Consultation for registered patients'),
('Certified Assistance','Certified assistance'),
('Renew License','Renewed License'),
('Training','Intern under training')

insert into CHARGES values
('General GP consultation for registered paitents','30','55'),
('General GP consultation for casual patients','30','90'),
('Emergency medical care for registered or casual patients','30',null),
('Vaccination or test collection for registered patients','15','0'),
('Vaccination or test collection for casual patients','15','40'),
('Repeat perscription','5','5')

insert into CONSULTATION values
(2,1,'01-Sep-2018','8.30',2),
(5,3,'04-Sep-2018','9.45',3),
(5,7,'06-Sep-2018','9.45',4),
(6,7,'07-Sep-2018','10.30',3),
(4,5,'07-Sep-2018','10.45',5)

insert into STAFF_SPECIALITY values
(1,3,'23-Apr-2014','23-Apr-2024','License renewed until 31/3/2026'),
(1,4,'14-May-2016','14-Nov-2022','Intern on rotation in surgical unit'),
(3,4,'01-Aug-2015','31-Jul-2023','Intern on rotation in medical unit'),
(6,1,'01-Aug-2015','31-Aug-2026','General GP'),
(7,4,'03-Sep-2018','31-Jul-2025','Intern on rotation with GP')

