/*Write a query (or queries) to show the number of entries in each table in the database*/
select count(*) from STAFF  /* count(*) means to count how many objects are in the table */
select count(*) from PATIENT
select count(*) from SPECIALITY
select count(*) from CHARGES
select count(*) from STAFF_SPECIALITY
select count(*) from CONSULTATION

/*Write a query to show all information of staff in the STAFF table that started before 23-Jan-2017*/
SELECT *
FROM STAFF
WHERE DateJoined<('23-Jan-2017'); /* this means where date join is before 23-Jan-2017 */

/*Write a query to show the staff in the STAFF table that have left. Show all columns*/
SELECT * 
FROM STAFF 
WHERE DateLeft is not null; /* "is not null" means where the section for date left is filled in */

/*Write a query to show all details of female staff in the STAFF table that have left*/
SELECT *
FROM STAFF
WHERE Gender=('F') and DateLeft is not null; /* means where the gender is female and date left has been filled out */

/*Write a query to show the Charge Code, Description and Hourly Rate of all charges for casual patients (in the description).*/
SELECT chargeID as "Charge Code", /* AS renames the the word and displays it as the word in " " */
chrgDescription as "Charge Description",
HourlyRate as "Hourly Rate"
FROM CHARGES
WHERE ChrgDescription LIKE '%Casual%'; /* LIKE searches for a specific word and %WORD$ defines the word its searching for*/ 

/* Write a query to show the Charge Code, Description and Hourly Rate of all charges for all charges that does NOT have casual patients (in the description). */
SELECT chargeID as "Charge Code",
chrgDescription as "Charge Description",
HourlyRate as "Hourly Rate"
FROM CHARGES
WHERE ChrgDescription NOT LIKE '%Casual%'; /* NOT LIKE searches for the carges excluding the word in the % sign */

/* Write a query to show the highest hourly rate, the lowest hourly rate and the average hourly rate for the charges applicable. Name the columns Highest Rate, Lowest Rate, Average Rate respectively. Format all the columns to show the dollar sign and 2 decimal places ($99.99) */
SELECT format(max(HourlyRate), 'C') as "Highest Rate", /* 'C' stands for currency and displayshourly rate in currency format */
format(min(HourlyRate), 'C') as "Lowest Rate",
format(avg(hourlyRate),'C') as "Average rate"
FROM CHARGES  

/* Write a query to show the duration rate for each charge. Show the Charge Code, Hourly Rate, Duration and Duration Rate. Duration Rate will be calculated (=HourlyRate * Duration/60). Format the Duration Rate column to show the dollar sign and 2 decimal places ($99.99) */
select chargeID as "Charge Code",
HourlyRate as "Hourly Rate",
Duration as "Duration",
format((hourlyRate * Duration / 60),'C') as "Duration Rate" /* hourlyrate x duration divided by 60 = duration rate */
from charges

/* Write a query to show the Staff ID, Speciality ID, Date Qualified, Valid Till Date and Days Valid. Days Valid will be calculated using the Date Qualified and Valid Till Date. */
Select StaffID as "Staff ID",
SpecialityID as "speciality ID",
DateQualified as "Date Qualified",
ValidTillDate as "Valid Till Date",
datediff(day, DateQualified, validtilldate) as "Days Valid" /* datediff counts the days between the 2 dates stated */
from STAFF_SPECIALITY

/* All charges are due within 21 days after the patient has had the consultation (Date Consulted). Write a query to show the Staff ID, Charge Code, Date Consulted, Start Time and Hourly Rate for all consultations.*/
select StaffID as "Staff ID",
ChargeID as "Charge Code",
DateConsultated as "Date Consulted",
StartTime as "Start Time"
from CONSULTATION

/* Write a query to show the Staff ID, Speciality ID, Speciality Name, Date Qualified and Valid Till Date for all consultations.*/
select s.StaffID as "Staff ID",
ChargeID as "Charge Code",
DateConsultated as "Date Consulted",
StartTime as "Start Time",
ValidTillDate as "Valid Till Date"
from CONSULTATION, STAFF_SPECIALITY, STAFF s /* this is to tell what tables to select from. the "s." and "STAFF s" is to specify what table to use that column from */

/* Write a query to show the Staff ID, Speciality ID, Speciality Name, Date Qualified and Valid Till Date for all consultations.*/
select StaffID as "Staff ID",
SpecName as "Speciality Name",
DateQualified as "Date Qualified",
ValidTillDate as "Valid Till Date"
from STAFF_SPECIALITY, SPECIALITY /* when it says "from <table>, <table>" it means its using more than 1 table */

/* Write a query to show the Staff ID, Patient Num, Date Consulted, Start Time and Hourly Rate for all consultations. */
select StaffID as "Staff ID",
PatientID as "Patient Num",
DateConsultated as "Date Consulted",
StartTime as "Start Time",
HourlyRate as "Hourly Rate"
from CONSULTATION, CHARGES

/* Write a query to show the Staff ID, Staff Full Name and Speciality ID of all male staff */
select s.StaffID as "Staff ID",
s.FirstName + ' ' + s.LastName as "Full Name", /* this will print out as <first name> <last name>, put it in a column under "Full Name" and take it from the staff table specifically */
ss.SpecialityID as "Speciality ID"
From STAFF s, SPECIALITY ss
WHERE Gender LIKE '%M%'; /* searches through the gender column for M */

/* Write a query to show the Staff ID, Speciality Name, Speciality Notes of all staff which relate to surgery or surgeon. Name this column Details. (Hint: look up for Surge or surge) */
Select s.StaffID as "Staff ID",
SpecName as "Speciality Name",
SpecNotes as "Details"
from SPECIALITY, STAFF s
WHERE SpecNotes LIKE '%surg%'; /* searches for "surge" */

/* Write a query to show the Staff ID, Patient Num, Charge Description, Time for all consultations after 9.45, in descending order of the Staff ID. */
Select StaffID as "Staff ID",
PatientID as "Patient Num",
chrgDescription as "Charge Description",
StartTime as "Consultations after 9.45"
from CHARGES ch, CONSULTATION c
where ch.ChargeID = c.ChargeID and StartTime>('9.45')
order by StaffID desc; /* orders the staff id in descent so 3, 2, 1. */

/* Write a query to show the Staff ID, Number of Consultations. Name the new column Num of Consults. */
Select StaffID as "Staff ID",
count(*) as "Num of Consults"
from CONSULTATION
group by StaffID

/* 17. Write a query to show the Staff ID, Num of Consults only for staff that have more than 2 consults */
Select StaffID as "Staff ID",
count(*) as "Num of Consults"
from CONSULTATION
group by StaffID
having count(*) > 2 /* searches for a count larger than 2 */

/* 18. Write a query to show the Speciality ID, Num with Speciality (i.e. the number of staff with that speciality). Display in descending order of Num with Speciality. */
select SpecialityID as "Speciality ID",
count(*) as "Num with Speciality"
from STAFF_SPECIALITY
group by SpecialityID
order by count(*) desc /* counts them in descent format */

/* 19. Write a query to show the Speciality ID, Num with Speclality with specialities having more than 2 staff. Display in descending order of Num with Speciality. */
select SpecialityID as "Speciality ID",
count(*) as "Num with Speciality"
from STAFF_SPECIALITY
group by SpecialityID
having count(*) > 2
order by [Num with Speciality] desc /* the previously counted column is being displayed in descenting order */

/* 20. Write a query to show the Staff Full Name, Num of Specialities. Sort in ascending order by Staff Full Name. */
select s.FirstName + ' ' + s.LastName as "Full Name",
count(*) as "Num of Specialities"
from STAFF s, STAFF_SPECIALITY ss
where s.staffID = ss.StaffID
group by s.firstname + ' ' + s.lastname
order by "Full Name" asc /* orders in ascending order */

/* 21. Write a query to show the Staff Full Name, Num. Specialities of all male staff with more than one speciality */
select s.FirstName + ' ' + s.LastName as "Full Name",
count(*) as "Num of Specialities"
from STAFF s, STAFF_SPECIALITY ss
where s.StaffID = ss.StaffID and s.Gender = 'M'
group by s.FirstName + ' ' + s.LastName
having count(*) > 1 /* counting that have more than one speciality */
order by [Full Name] asc

/* 22. Write a query to show the Staff ID, Staff Full Name, Speciality ID, Speciality Name for all staff */
select s.StaffID as "Staff ID",
s.FirstName + ' ' + s.LastName as "Staff Full Name",
sp.specialityID as "Speciality ID",
sp.SpecName as "Speciality Name"
from STAFF s, SPECIALITY sp, STAFF_SPECIALITY ss
where s.StaffID = ss.StaffID and sp.SpecialityID = ss.SpecialityID