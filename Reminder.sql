--drop table Employee
create table Employee
(
EId int,
FirstName varchar(50),
LastName varchar(50),
Salary float,
Department varchar(50)
primary key(EId)
);
insert into Employee select 1,'Tom','Delan',583000,'Financial'
insert into Employee select 2,'Brown','Thomas',585000,'Financial'
insert into Employee select 3,'Tom','Delan',583000,'Financial'
insert into Employee select 4,'Tony','Blar',581000,'IT'
insert into Employee select 5,'Barack','Obama',32000,'IT'
insert into Employee select 6,'The','Pope',120000,'Financial'
insert into Employee select 7,'Test','Tester',485600,'IT'
insert into Employee select 8,null,'LastName',485600,'Financial'
insert into Employee select 9,'FirstName',null,485600,'IT'
insert into Employee select 10,null,null,485600,'Financial'

--- get max salary by department
select MAX(salary),Department from Employee 
group by department

 get first name, if first name is null return last name. if last name is null select first name. if both null, return 'anoymouse'
select 
case
when firstname is null and lastname is null then 'anoymouse' 
when firstname is null and lastname is not null then lastname
when firstname is not null then firstname 
end
from employee

--delete duplicate columns and list out employ id
with GroupData as
(
	select  ee.firstname as FirstName,ee.lastname as LastName from employee ee
	group by ee.firstname, ee.lastname
	having COUNT(*)>1
)	

select e.eid, e.firstname
from GroupData g
inner join employee e on g.firstname = e.firstname and g.lastname = e.lastname

