create database ado_crud
use ado_crud

create table Students 
(
id int primary key identity,
Name varchar(50),
Gender varchar(50),
Age int,
Salary int,
City varchar(50)
)
select * from Students

insert into Students(Name,Gender,Age,Salary,City)values('Raghav','Male',23,25000,'Gorakhapur')
insert into Students(Name,Gender,Age,Salary,City)values('Soumya','Female',33,62000,'Noida')
insert into Students(Name,Gender,Age,Salary,City)values('Rajan','Male',26,525000,'Mohali')
insert into Students(Name,Gender,Age,Salary,City)values('Rahul','Male',25,65000,'Gonda')
insert into Students(Name,Gender,Age,Salary,City)values('Sakshi','Female',24,45000,'Basti')
insert into Students(Name,Gender,Age,Salary,City)values('Parul','Female',26,95000,'Hyderabad')
insert into Students(Name,Gender,Age,Salary,City)values('Robina','Female',29,65000,'Chennai')
insert into Students(Name,Gender,Age,Salary,City)values('Jack','Male',30,35000,'Pune')
insert into Students(Name,Gender,Age,Salary,City)values('Sunil','Male',33,55000,'Lucknow')
insert into Students(Name,Gender,Age,Salary,City)values('mmahesh','Male',32,56200,'Delhi')

create procedure sp_Get_Student
as
begin 
  select * from Students 
  end
   execute sp_Get_Student

   create procedure sp_Add_Student
   (
         @Name varchar(50),
         @Gender varchar(50),
         @Age int,
         @Salary int,
         @City varchar(50)     
   )
   as 
   begin
   insert into Students(Name,Gender,Age,Salary,City)values(@Name,@Gender,@Age,@Salary,@City)
   end

   execute sp_Add_Student 'Shiva','Male',36,23500,'Chandigarh';


   create procedure sp_Update_Student
   (     @id int,
         @Name varchar(50),
         @Gender varchar(50),
         @Age int,
         @Salary int,
         @City varchar(50)     
   )
   as 
   begin
   update Students set Name=@Name,Gender=@Gender,Age=@Age,Salary=@Salary,City=@City where id=@id
   end

   execute sp_Update_Student 10,'Mahesh','Male',35,56000,'Mumbai';

 alter procedure sp_Delete_Student
   (
   @id int
   )
   as   
   begin
     delete from Students where id = @id
   end

   execute sp_Delete_Student 13;