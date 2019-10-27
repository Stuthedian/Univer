--bilet21
create database izdel
use izdel
create table vipysk(
	nz int primary key identity,
	name varchar(50) not null,
	kol int check (kol between 0 and 1000),
	cena dec(7,2) check (cena > 0),
	dt date
)

select * from vipysk
insert into vipysk
values
('r',12,28, '12.06.2016'),
('s',12,29.5, '12.04.2016')

select name as name, sum(kol) as skol, avg(cena) srcena into itog from vipysk
group by name
select * from itog
delete from itog

go
create trigger zapisi_3
on vipysk
after insert, update
as
begin
	declare @row int = @@rowcount
	if @row = 1
	begin
		if exists (select * from inserted)
		begin
			declare @name varchar(50), @dt date
			select @name = name, @dt = dt from inserted
			if (select count(*) from vipysk where name = @name and month(dt) = month(@dt)) > 3
			begin
				rollback transaction
				print 'Не более 3-х записей с одинаковым наименованием в один и тот же месяц!'
				return
			end
		end
	end
	else if @row > 1
	begin
		rollback transaction
		print 'Не более одной строки в insert, update за раз'
		return
	end
end
go
create trigger otpusk_cena
on vipysk
after insert, update
as
begin
	declare @row int = @@rowcount
	if @row = 1
	begin
		if exists (select * from inserted)
		begin
			declare @name varchar(50), @cena dec(7,2), @dt date
			select @name = name, @cena = cena, @dt = dt from inserted
			if exists (select * from vipysk where name = @name and @cena < cena and @dt > dt)
			begin
				rollback transaction
				print 'Не допустимо снижение отпускной цены на более позднюю дату'
				return
			end
		end
	end
	else if @row > 1
	begin
		rollback transaction
		print 'Не более одной строки в insert, update за раз'
		return
	end
end
go
create trigger sum_kol
on vipysk
after insert, update
as
begin
	declare @row int = @@rowcount
	if @row = 1
	begin
		if exists (select * from inserted)
		begin
			declare @name varchar(50), @month int
			select @name = name,  @month = month(dt) from inserted
			if exists (select * from vipysk where name = @name and month(dt) = @month group by name having sum(kol) > 1000)
			begin
				rollback transaction
				print 'Не более 1000 изделий в месяц для данного наименования изделия'
				return
			end
		end
	end
	else if @row > 1
	begin
		rollback transaction
		print 'Не более одной строки в insert, update за раз'
		return
	end
end
select * from vipysk
insert into vipysk
values
('v',1, 10, '13.08.2018')
go
create trigger upd_itog
on vipysk
after insert, update, delete
as
begin
	delete from itog
	insert into itog
	select name as name, sum(kol) as skol, avg(cena) srcena from vipysk
	group by name 
end

--1
--tocombobox (select skol from itog where name = @name) >= 5
declare @name varchar(50) = 's'
select name from vipysk
group by name
having sum(kol) >= 5
select datename(month, dt), sum(kol) from vipysk
where name = @name 
group by month(dt), dt
having sum(kol) > 2
--2
select max(cena) from vipysk
group by dt
select sum(kol), (select sum(kol) from vipysk as v1
where cena = (select max(cena) from vipysk as v where v.dt = vipysk.dt) and v1.dt = vipysk.dt) from vipysk
group by dt

group by dt
select distinct dt from vipysk
select sum(kol) from vipysk
where cena = (select min(cena) from vipysk as v where v.dt = vipysk.dt)
group by dt

select t1.k, t2.k, t3.k from 
(select dt, sum(kol) as k from vipysk 
group by dt) as t1  
join 
(select dt, sum(kol) as k from vipysk
where cena = (select max(cena) from vipysk as v where v.dt = vipysk.dt)
group by dt) as t2 on t1.dt = t2.dt
join
(select dt, sum(kol) as k from vipysk
where cena = (select min(cena) from vipysk as v where v.dt = vipysk.dt)
group by dt) as t3
on t2.dt = t3.dt

select distinct dt, (select sum(kol) from vipysk as v where v.dt = vipysk.dt),
(select sum(kol) from vipysk as v where v.dt = vipysk.dt and 
cena = (select max(cena) from vipysk as v1 where v1.dt = vipysk.dt)),
(select sum(kol) from vipysk as v where v.dt = vipysk.dt and 
cena = (select min(cena) from vipysk as v1 where v1.dt = vipysk.dt)) from vipysk

--3
declare @month int = 6, @year int = 2016
select name from vipysk
where month(dt) = @month and year(dt) = @year
group by name
having sum(kol) = 
(select max(t.k) from
(select sum(kol) as k from vipysk
where month(dt) = @month and year(dt) = @year
group by name) as t)

declare @month int = 6, @year int = 2016
select name from vipysk
where month(dt) = @month and year(dt) = @year
group by name
having sum(kol) = 
(select max((select sum(kol) as k from vipysk
where month(dt) = @month and year(dt) = @year
group by name)))
--bilet 29
--1
declare @name varchar(50)
select dat, count(*) from proish
where name = @name
group by dat
having count(*) > 2
--2
select distinct dat, (select count(*) from proish as p where p.dat = proish.dat and ss < 50), 
(select count(*) from proish as p where p.dat = proish.dat and ss >= 5 and ss <= 1000),
(select count(*) from proish as p where p.dat = proish.dat and ss > 1000) from proish
--3
declare @ss dec(7,2)
select name from proish
where 
(select count(*) from proish as p
where ss > @ss and p.name = proish.name)
=
(select min(t.kol) from (select count(*) as kol from proish
where ss > @ss
group by name) as t)
declare @ss dec(7,2)
select name from proish
where ss > @ss
group by name
having count(*) =
(select min(t.kol) from (select count(*) as kol from proish
where ss > @ss
group by name) as t)
--bilet 23
--1
declare @name varchar(50) = 's'
select dt, (select sum(kol)from vipysk where name = @name), count(*)  from vipysk
where name = @name
group by dt
having count(*) > 10
--2
select month(dt), (select count(*) from vipysk as v where month(v.dt) = month(vipysk.dt)) from vipysk
group by month(dt)
select month(dt) from vipysk
group by month(dt)
--3
declare @quart int = 2, @year int = 2016
select distinct name from vipysk
where (select sum(kol) from vipysk as v where v.name = vipysk.name 
and datepart(quarter,dt) = @quart and year(dt) = @year) = 
(select max(t.kol) from (select sum(kol) as kol from vipysk
where datepart(quarter,dt) = @quart and year(dt) = @year
group by name) as t)
--bilet 22
--1
declare @name varchar(50)
select dat, (select sum(sn) from vipysk where name = @name),count(*) from vipysk
where name = @name
group by dat
having sum(sn) > 6
--2
select distinct dat, (select count(*) from vipysk as v where v.dat = vipysk.dat and vv < 40), 
(select count(*) from vipysk as v where v.dat = vipysk.dat and vv between 40 and 60),
(select count(*) from vipysk as v where v.dat = vipysk.dat and vv > 60) from vipysk
--3
declare @beg date, @end date
select distinct name from vipysk
where (select sum(sn) from vipysk as v
where v.name = vipysk.name and dat between @beg and @end) =
(select max(t.s) from (select sum(sn) as s from vipysk
where dat between @beg and @end
group by name) as t)

--bilet 24
--1
declare @name varchar(50)
select month(dat), (select sum(ss) from sbros where name = @name),count(*) from sbros
where name = @name
group by month(dat)
having count(*) >= 2
--2
select distinct month(dat), (select sum(rz) from sbros as s where month(s.dat) = month(sbros.dat) and ss < 1000),
(select sum(rz) from sbros as s where month(s.dat) = month(sbros.dat) and ss between 1000 and 5000),
(select sum(rz) from sbros as s where month(s.dat) = month(sbros.dat) and ss > 8000) from sbros
--3
declare @beg date, @end date
select distinct name from sbros
where (select sum(ss) from sbros as s where dat between @beg and @end and s.name = sbros.name) = 
(select min(t.k) from (select sum(ss) as k from sbros
where dat between @beg and @end
group by name) as t)
--bilet 33
--1
declare @name varchar(50)
select dd, count(*) from person
where name = @name
group by dd
having count(*) >= 2
--2
select distinct dd, (select count(*) fom person as p where p.dd = person.dd and okl < 10000),
(select count(*) fom person as p where p.dd = person.dd and okl between 10000 and 20000),
(select count(*) fom person as p where p.dd = person.dd and okl > 20000) from person
--3
declare @okl dec(6,2)
select name from person
where okl > @okl
group by name
having count(*) = (select max(t.kol) from 
	(select count(*) as kol from person 
	where okl > @okl group by name) as t)