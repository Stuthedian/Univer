create database Radiostation
use Radiostation

create table Ispolnitel
(
	cod_isp int primary key identity,
	naim varchar(50) not null
)

create table Janr
(
	cod_janr int primary key identity,
	naim varchar(50) not null
)

create table Sotrudnik
(
	cod_sotr int primary key identity,
	fam varchar(50) not null,
	im varchar(50) not null,
	otch varchar(50),
	dr date not null,
	pol varchar(1) not null check (pol in ('ì','æ'))
)
alter  table Sotrudnik 
add constraint polcheck check (pol in ('ì','æ'))
create table Zapis
(
	cod_zap int primary key identity,
	naim_zapis varchar(50) not null,
	data date not null,
	cod_isp int foreign key references Ispolnitel,
	cod_janr int foreign key references Janr,
	cod_sotr int foreign key references Sotrudnik
)

create procedure Query1
@cod int
as
select distinct naim_zapis from Zapis
where cod_isp = @cod

exec Query1 'Äåëüôèí'

create procedure Query2
@d1 date, @d2 date
as
select naim_zapis, data, 
(select naim from Ispolnitel where Ispolnitel.cod_isp = Zapis.cod_isp),
(select naim from Janr where Janr.cod_janr = Zapis.cod_janr),
(select fam + ' ' + left(im,1) + '.' + left(otch,1) from Sotrudnik where Sotrudnik.cod_sotr = Zapis.cod_sotr) from Zapis
where data >= @d1 and data <= @d2

exec Query2 '01.12.2018','13.12.2018'

create procedure Query3
@q int
as
select fam + ' ' + left(im,1) + '.' + left(otch,1), 
(select count(*) from Zapis where datepart(quarter, data) = @q and Zapis.cod_sotr = Sotrudnik.cod_sotr) 
from Sotrudnik

exec Query3 1

create procedure Query4
@count_max int output
as
set @count_max = (select max(t.b) from
(select 
(select count(*) from Zapis where datepart(quarter, data) = datepart(quarter, GETDATE()) and Zapis.cod_janr = Janr.cod_janr) as b
from Janr) as t)
select naim from Janr
where
(select count(*) from Zapis where datepart(quarter, data) = datepart(quarter, GETDATE()) and Zapis.cod_janr = Janr.cod_janr)
= @count_max

exec Query4

create procedure Query5
as
select naim, dbo.func_query5(cod_isp) from Ispolnitel

create function func_query5 (@cod_isp int)
returns varchar(max)
as
begin
	declare @ret varchar(500)
	set @ret = ''
	select @ret = @ret + naim + CHAR(13) + CHAR(10) from Janr where cod_janr in 
	(select cod_janr from Zapis where Zapis.cod_isp = @cod_isp)
	return @ret
end

exec Query5


create procedure Query6
as
select fam + ' ' + left(im,1) + '.' + left(otch,1),
dbo.func_query6(cod_sotr,1),
dbo.func_query6(cod_sotr,2),
dbo.func_query6(cod_sotr,3),
dbo.func_query6(cod_sotr,4),
dbo.func_query6(cod_sotr,5),
dbo.func_query6(cod_sotr,6),
dbo.func_query6(cod_sotr,7),
dbo.func_query6(cod_sotr,8),
dbo.func_query6(cod_sotr,9),
dbo.func_query6(cod_sotr,10),
dbo.func_query6(cod_sotr,11),
dbo.func_query6(cod_sotr,12)
from Sotrudnik

exec Query6

create function func_query6 (@cod_sotr int, @month int)
returns varchar(max)
as
begin
	declare @ret varchar(500)
	set @ret = ''
	select @ret = @ret + naim_zapis + CHAR(13) + CHAR(10) from Zapis 
		where Zapis.cod_sotr = @cod_sotr and MONTH(data) = @month and year(data) = year(GETDATE())
	return @ret
end

print dbo.func_query6(2,12)

--INSERT
alter procedure ins_isp
@cod int output, @naim varchar(50) 
as 
begin 
	insert into Ispolnitel
	values (@naim) 
	set @cod = @@identity
end 

--declare @cod int, @naim varchar(max)  = 'Rety'
--exec ins_isp @cod , @naim 

alter procedure ins_janr
@cod int output, @naim varchar(50) 
as 
begin 
	insert into Janr
	values (@naim) 
	set @cod = @@identity
end

create procedure ins_sotr
@cod int output, @fam varchar(50), @im varchar(50), @otch varchar(50), @dr date, @pol varchar(1)
as 
begin 
	insert into Sotrudnik
	values (@fam, @im, @otch, @dr, @pol) 
	set @cod = @@identity
end

create procedure ins_zap
@cod int output, @naim_zapis varchar(50), @data date, @cod_isp int, @cod_janr int, @cod_sotr int
as 
begin 
	insert into Zapis
	values (@naim_zapis, @data, @cod_isp, @cod_janr, @cod_sotr) 
	set @cod = @@identity
end

--UPDATE
create procedure upd_isp
@cod int, @naim varchar(50)
as 
begin 
	update Ispolnitel set naim = @naim where  cod_isp = @cod 
end 

create procedure upd_janr
@cod int, @naim varchar(50)
as 
begin 
	update Janr set naim = @naim where  cod_janr = @cod 
end 

create procedure upd_sotr
@cod int, @fam varchar(50), @im varchar(50), @otch varchar(50), @dr date, @pol varchar(1)
as 
begin 
	update Sotrudnik set fam = @fam, im = @im, otch = @otch, dr = @dr, pol = @pol where  cod_sotr = @cod 
end 

create procedure upd_zap
@cod int, @naim_zapis varchar(50), @data date, @cod_isp int, @cod_janr int, @cod_sotr int
as 
begin 
	update Zapis set naim_zapis = @naim_zapis, data = @data, cod_isp = @cod_isp, 
		cod_janr = @cod_janr, cod_sotr = @cod_sotr where  cod_zap = @cod 
end 
exec upd_zap 1, 'âèíî', '19.12.2018', 3, 2, 1
--DELETE

create procedure del_isp
@cod  int
as 
begin 
  delete from Ispolnitel where cod_isp = @cod
end

create procedure del_janr
@cod  int
as 
begin 
  delete from Janr where cod_janr = @cod
end

create procedure del_sotr
@cod  int
as 
begin 
  delete from Sotrudnik where cod_sotr = @cod
end

create procedure del_zap
@cod  int
as 
begin 
  delete from Zapis where cod_zap = @cod
end

--CHECKS

create procedure chk_isp
@cod  int
as 
begin 
  select count(*) from Zapis where cod_isp = @cod
end
