create database postavki_3_tables
use postavki_3_tables

create table Tovar
(
	idt int identity primary key,  
    name_ varchar(50) not  null unique
)

create table Postavshik
(  
	idp int identity primary key, 
	name_ varchar(50) not  null unique
)
 
create table Post
(
	np int identity primary key, 
	idt int references Tovar,   
	idp int references Postavshik,  
	ss decimal(7,2) check (ss > 0),  
	dd date
)
drop table Postavshik
select isnull((select idp from Postavshik where name_ = ' '),-1)
/*
Создать  триггер,  который  запрещает  более  3  поставок  в  один  день  одного  и  того  же 
поставщика или одного и того же товара. 
*/
select * from Tovar
select * from Postavshik
insert into Tovar values (2,'Beer')
insert into Postavshik values (2, 'Lamal')
select * from Post
delete from Post
insert into Post
values
(2,2,10,'17.01.2018')
select scope_identity()
select ident_current('post')
drop trigger post_constraint
create trigger post_constraint
on Post
after insert, update
as
begin
	declare @kol int, @dd date, @idp int, @idt int
	select @dd = dd, @idp = idp, @idt = idt from inserted
	select @kol = count(idp) from Post
	where dd = @dd and idp = @idp
	if(@kol > 3)
	begin
		rollback transaction
		print 'Нельзя ввести более 3 поставок в  один  день одного и того  же поставщика' 
	end
	else
	begin 
		select @kol = count(@idt) from Post
		where dd = @dd and idt = @idt
		if(@kol > 3)
		begin
			rollback transaction
			print 'Нельзя ввести более 3 поставок в  один  день одного и того же товара' 
		end
	end
end

select * from ((select 1 as st1 union select 5)) as m1
select (select name_ from Postavshik where idp = Post.idp), (select name_ from Tovar where idt = Post.idt),ss, dd from Post
select datename(month, dateadd(month,months.st1,-1)), isnull(sum(ss),0), count(name_t) from 
(select * from post where name_t = 'Кофе тульский') as post right join 
((select 1 as st1 union select 2 union select 3 union select 4 union select 5 union select 6 
union select 7 union select 8 union select 9 union select 10 union select 11 union select 12)) as months
on months.st1 = month(post.dd)
group by months.st1

 and month(dd) = m1.st1
select m1.st1, sum(ss), count(name_t) from post right join ((select 1 as st1 union select 5)) as m1
on m1.st1 = month(post.dd)
where name_t = 'Бастурма' and month(dd) = m1.st1

create procedure zapros_3
as
select (select name_ from Postavshik where idp = p2.idp), 
(select sum(ss) from Post as p1 where p1.idp = p2.idp and month(dd) = month(getdate())),
(select sum(ss) from Post as p1 where p1.idp = p2.idp and datepart(quarter,dd) = datepart(quarter,getdate())),
(select sum(ss) from Post as p1 where p1.idp = p2.idp and year(dd) = year(getdate()))
from Post as p2
group by idp

 select sum(ss) from post where month(dd) = month(getdate()) and name_pos = 'Лето'

 select (select name_ from Postavshik where idp = Post.idp) as n from Post
 group by idp
 select (select name_ from Postavshik where idp = Post.idp) from Post group by idp order by name_