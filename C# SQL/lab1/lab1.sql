create database Postavki_2018
use Postavki_2018
create table Tovar 
(idt int primary key identity,
name varchar(50) not null unique)
create table Postavshik 
(idp int primary key identity,
name varchar(50) not null unique)
create table Post 
(np int primary key identity,
idt int foreign key references Tovar,
idp  int foreign key references Postavshik,
ss dec(7,2) check (ss > 0),
dd date)

create trigger post_constraint
on Post
after insert, update
as
begin
	declare @kol int, @dd date, @idp int, @idt int, @ss dec(7,2)
	select @dd = dd, @idp = idp, @idt = idt, @ss = ss from inserted
	select @kol = count(idp) from Post
	where dd = @dd and idp = @idp
	if(@kol > 3)
	begin
		rollback transaction
		print 'Ќельз€ ввести более 3 поставок в  один  день одного и того  же поставщика' 
	end
	else
	begin 
		select @kol = sum(@ss) from Post
		where dd = @dd and idt = @idt
		if(@kol > 1000)
		begin
			rollback transaction
			print 'Ќе более 1000 кг в один  день одного и того же товара' 
		end
	end
end
insert into Tovar
values
('Tomato'),('Potato')
insert into Postavshik
values
('Cargo'), ('Khali')
select * from Tovar
select * from Postavshik
select * from Post
insert into Post
values
(1,2,999,'05.09.2018')
exec Zad1 Cargo
exec Zad2 Tomato
exec Zad4 Cargo
alter procedure Zad1
@name varchar(50)
as
begin
	select dd, SUM(ss), COUNT(*) from Post
	where idp = (select idp from Postavshik where name = @name)
	group by dd
end


alter procedure Zad2
@name varchar(50)
as
select datename(month, dateadd(month,months.st1,-1)), isnull(sum(ss),0), count(post.dd) from 
(select * from Post where idt = (select idt from Tovar where name = @name)) as post right join 
((select 1 as st1 union select 2 union select 3 union select 4 union select 5 union select 6 
union select 7 union select 8 union select 9 union select 10 union select 11 union select 12)) as months
on months.st1 = month(post.dd)
group by months.st1

alter procedure Zad3
as
select name,
isnull((select sum(ss) from Post where idp = Postavshik.idp and month(dd) = month(getdate())),0),
isnull((select sum(ss) from Post where idp = Postavshik.idp and datepart(quarter,dd) = datepart(quarter,getdate())),0),
isnull((select sum(ss) from Post where idp = Postavshik.idp and year(dd) = year(getdate())),0) from Postavshik 

alter procedure Zad4
@name varchar(50)
as
select name from Postavshik as p
where name != @name and 
exists (select t2.idt from (select idt from Post where idp = (select idp from Postavshik where name = @name)) as t1 left join
(select idt from Post where idp = (select idp from Postavshik where name = p.name)) as t2
on t1.idt = t2.idt) and 
not exists (select top 1 t2.idt from (select idt from Post where idp = (select idp from Postavshik where name = @name)) as t1 left join
(select idt from Post where idp = (select idp from Postavshik where name = p.name)) as t2
on t1.idt = t2.idt
where t2.idt is null)

select name from Postavshik
where name in 
 (select name from Postavshik where idp in 
  (select idp from Post where idt in (select idt from Post where idp = (select idp from Postavshik where name = @name)))) and name != @name



declare @name varchar(50) ='Fedex'
select name from Postavshik as o
where name != @name and 
is null all(select t2.idt from (select idt from Post where idp = (select idp from Postavshik where name = @name)) as t1 left join
(select idt from Post where idp = (select idp from Postavshik where name = o.name)) as t2
on t1.idt = t2.idt)

declare @name varchar(50) ='Khali'
select name from Postavshik as p
where name != @name and 
exists (select t2.idt from (select idt from Post where idp = (select idp from Postavshik where name = @name)) as t1 left join
(select idt from Post where idp = (select idp from Postavshik where name = p.name)) as t2
on t1.idt = t2.idt) and 
not exists (select top 1 t2.idt from (select idt from Post where idp = (select idp from Postavshik where name = @name)) as t1 left join
(select idt from Post where idp = (select idp from Postavshik where name = p.name)) as t2
on t1.idt = t2.idt
where t2.idt is null)

declare @name varchar(50) ='CargoShip'
select name from Postavshik as o
where name != @name and 
if exists (select t2.idt from (select idt from Post where idp = (select idp from Postavshik where name = @name)) as t1 left join
(select idt from Post where idp = (select idp from Postavshik where name = o.name)) as t2
on t1.idt = t2.idt) 

select top 1 t2.idt from (select idt from Post where idp = (select idp from Postavshik where name = 'Fedex')) as t1 left join
(select idt from Post where idp = (select idp from Postavshik where name = 'Khali')) as t2
on t1.idt = t2.idt
where t2.idt is null


select (select name from Tovar where idt = Post.idt), (select name from Postavshik where idp = Post.idp) as t from Post
order by t

/*
returns empty Ч don't show names(false)
returns some nulls or all nulls Ч don't show name(false)
returns no nulls Ч show name(true)
*/
--¬вод и корректировка
create procedure all_tovar  
as 
begin 
  select * from tovar
  order by name 
end

create procedure  vvod_tovar 
@idt int output, @name varchar(max) 
as 
begin 
	insert into tovar 
	values (@name) 
	set @idt=@@identity
end 

create procedure  update_tovar  
@idt int, @name varchar(max) 
as 
begin 
	update tovar set name=@name where  idt=@idt 
end 
 
create procedure  del_tovar 
@idt int 
as 
begin 
	delete from tovar where idt=@idt 
end  

create procedure  kol_tovar 
@name varchar(max) 
as 
begin 
	select count(idt) from tovar where name = @name 
end  
 
create  procedure kol1_tovar 
@idt int 
as 
begin 
	select count(idt) from post where idt=@idt 
end 
--postavshik
exec all_postavshik  
create procedure all_postavshik  
as 
begin 
  select * from postavshik
  order by name 
end

create procedure  vvod_postavshik 
@idp int output, @name varchar(max) 
as 
begin 
	insert into postavshik 
	values (@name) 
	set @idp=@@identity
end 

create procedure  update_postavshik  
@idp int, @name varchar(max) 
as 
begin 
	update postavshik set name=@name where  idp=@idp 
end 
 
create procedure  del_postavshik 
@idp int 
as 
begin 
	delete from postavshik where idp=@idp 
end  

create procedure  kol_postavshik 
@name varchar(max) 
as 
begin 
	select count(idp) from postavshik where name = @name 
end  
 
create  procedure kol1_postavshik 
@idp int 
as 
begin 
	select count(idp) from post where idp=@idp
end

create procedure find_postavshik
@idp int output, @name varchar(max) 
as 
begin 
	select @idp = idp from postavshik where name=@name
end 
--post
alter procedure all_post
as 
begin 
  select np, (select name from Tovar where Tovar.idt = Post.idt), 
   (select name from Postavshik where Postavshik.idp = Post.idp), ss, dd from post
  order by dd
end

create procedure del_post
@np int
as 
begin 
  delete from Post where np = @np
end

create procedure idp_post
@name varchar(max)
as
begin
	select idp from postavshik where name = @name
end

create procedure idt_post
@name varchar(max)
as
begin
	select idt from tovar where name = @name
end

create procedure vvod_post
@np int output, @idt int, @idp int, @ss dec(7,2), @dd date
as 
begin 
	insert into post
	values (@idt, @idp, @ss, @dd) 
	set @np = @@identity
end 

create procedure update_post
@np int , @idt int, @idp int, @ss dec(7,2), @dd date
as 
begin 
	update post set idt = @idt, idp = @idp, ss = @ss, dd = @dd where  np = @np 
end 