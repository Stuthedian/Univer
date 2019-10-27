create database prokat
use prokat

create table client
(
	cod_cli int primary key,
	fam varchar(50) not null,
	im varchar(50) not null,
	otch varchar(50),
	pol varchar(1) not null check (pol in ('м','ж','М','Ж')),
	dr date not null,
	adr varchar(100) not null,
	tel varchar(50) not null
)

create table doljnost
(
	cod_dol int primary key,
	naim varchar(100) not null,
	oklad int not null check (oklad >= 0),
	obyaz varchar(100) not null
)

create table automobil
(
	cod_auto int primary key,
	nazv varchar(50) not null,
	god int not null check ((year(getdate()) - god) >= 0 and (year(getdate()) - god) <= 15),
	probeg int not null check(probeg >= 0),
	cena int not null check(cena >= 0),
	cod_cli int references client
)


create table sotrudnik
(
	cod_sotr int primary key,
	fam varchar(50) not null,
	im varchar(50) not null,
	otch varchar(50),
	pol varchar(1) not null check (pol in ('м','ж','М','Ж')),
	dr date not null,
	adr varchar(100) not null,
	tel varchar(50) not null,
	cod_dol int references doljnost
)

create table prokat
(
	cod_auto int references automobil,
	cod_sotr int references sotrudnik,
	data_v date,
	srok int not null check(srok >= 0),
	cena int not null check(cena >= 0),
	primary key (cod_auto, cod_sotr, data_v)
)

insert into client
values 
(1,'Воскобойников','Юрий','Евгеньевич','м','08.12.1945','Новосибирск','89134456481'),
(2,'Вальгер','Светлана','Алексеевна','ж','01.12.1947','Новосибирск','89133406481'),
(3,'Воробьева','Алла','Петровна','ж','09.12.1949','Бийск','89133456481'),
(4,'Данилов','Максим','Николаевич','м','07.12.1965','Бердск','89233456481'),
(5,'Кисленко','Николай','Петрович','м','05.12.1955','Новосибирск','88133456481')

insert into doljnost
values
(1,'Старший прокатчик',45000,'Прокат авто, сопровождение документации'),
(2,'Прокатный служащий',35000,'Прокат авто'),
(3,'Мастер-прокатчик',65000,'Прокат авто, сопровождение документации, стратегическое планирование')

insert into automobil
values
(1,'Suzuki Ignis',2006,177000,349000,1),
(2,'Smart Forfour',2005,146000,295000,2),
(3,'Opel Astra GTC',2006,200000,285000,3),
(4,'Mazda CX-5',2013,58000,1099000,3),
(5,'Toyota Prius',2012 ,0,700000,null)

insert into sotrudnik
values
(1,'Литвинов','Леонид','Алексеевич','м','05.12.1951','Искитим','88133457481',1),
(2,'Мухина','Ирина','Николаевна','ж','05.12.1935','Бердск','88133456489',1),
(3,'Фёдорова','Наталья','Николаевна','ж','05.11.1955','Бердск','88133456481',2),
(4,'Баланчук','Татьяна','Тимофеевна','ж','05.10.1955','Новосибирск','85133456481',2),
(5,'Бедарев','Игорь','Александрович','м','06.12.1955','Бийск','88133458481',2),
(6,'Гошко','Елена','Юрьевна','ж','02.12.1955','Новосибирск','88133456381',3),
(7,'Фёдоров','Александр','Владимирович','м','07.10.1955','Новосибирск','88155458481',null)

insert into prokat
values
(1,1,'29.10.2017',3,2000),
(2,1,'23.10.2017',1,1000),
(3,2,'22.10.2017',10,20000),
(4,3,'21.10.2017',9,9000)

select nazv from automobil--запрос из одной таблицы 
where year(getdate()) - god <= 5

--запрос из нескольких таблицы (left,right, inner join)

select nazv from   automobil left join client
on client.cod_cli=automobil.cod_cli
where client.cod_cli is null

	--right
select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio from  automobil right join client
on client.cod_cli=automobil.cod_cli
where automobil.cod_cli is null


	--simple join
select nazv,fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio from  client  join automobil
on client.cod_cli=automobil.cod_cli

--агрегатные ф-ии

select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio,count(prokat.cod_sotr) as kol from sotrudnik left join prokat 
on prokat.cod_sotr=sotrudnik.cod_sotr
where adr != 'Искитим'
group by sotrudnik.cod_sotr,fam,im,otch
having count(prokat.cod_sotr) > 0

--коррелированные подзапросы в from,where,having,select

	--where
select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio from sotrudnik join doljnost
on sotrudnik.cod_dol=doljnost.cod_dol
where oklad > (select max(oklad) from doljnost as d
				where d.oklad<>doljnost.oklad)
				
				
select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio from sotrudnik 
where (select oklad from doljnost where sotrudnik.cod_dol=doljnost.cod_dol)= (select min(oklad) from doljnost)

	--having
select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio ,count(prokat.cod_sotr) as kol from sotrudnik as s left join prokat 
on prokat.cod_sotr=s.cod_sotr
group by s.cod_sotr,fam,im,otch
having count(prokat.cod_sotr) > (select max(col.col) from (select count(prokat.cod_sotr) as col from sotrudnik left join prokat 
								 on prokat.cod_sotr=sotrudnik.cod_sotr
								 where s.cod_sotr<>sotrudnik.cod_sotr
								 group by sotrudnik.cod_sotr) as col)
								 
								 
select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio, (select count(prokat.cod_sotr) from sotrudnik left join  prokat on sotrudnik.cod_sotr=prokat.cod_sotr  where sotrudnik.cod_sotr=s.cod_sotr) as kol  from sotrudnik as s
group by s.cod_sotr,fam,im,otch
having 
	(select count(prokat.cod_sotr) from sotrudnik left join  prokat on sotrudnik.cod_sotr=prokat.cod_sotr  where sotrudnik.cod_sotr=s.cod_sotr) = 
		(select min(col) from (select count(prokat.cod_sotr ) as col from sotrudnik left join  prokat on sotrudnik.cod_sotr=prokat.cod_sotr group by sotrudnik.cod_sotr) as n)


	--select
select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio, isnull((select naim from doljnost where doljnost.cod_dol=sotrudnik.cod_dol),'Нет занятости') as doljnost from  sotrudnik


	--from
select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio from 
	(select * from sotrudnik as sotr
		where  not exists (select * from prokat 
							where sotr.cod_sotr=prokat.cod_sotr)) as s2


-- пользовательские ф-ии
	--скалярная
create function numberofprokat (@cod_sotr int)
returns int
as
begin
	declare @ret int
	select @ret=count(cod_sotr) from prokat
	where cod_sotr=@cod_sotr
	return @ret
end

select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio, dbo.numberofprokat(cod_sotr) as col from sotrudnik

	--табличная
create function autoatprokat()
returns table
as
return 
	select * from automobil
	where cod_auto in (select cod_auto from prokat)

select nazv,god from dbo.autoatprokat() 
where (year(getdate()) - god) >= (year(getdate()) - (year(getdate()) - 10))

-- процедуры
	--1 входной параметр, результат таблица
create procedure sotrinfo
@codsotr int
as
	if @codsotr not in (select cod_sotr from sotrudnik)
		print 'Такой сотрудник отсутствует'
	else
	begin
	select nazv,god,probeg,automobil.cena from automobil join prokat
	on automobil.cod_auto=prokat.cod_auto
	where cod_sotr=@codsotr
	end

execute sotrinfo 1

	--2<= выходных параметра
create procedure counts
@countsotr int output,@countauto int output
as
set @countsotr = (select count(cod_sotr) from sotrudnik)
set @countauto = (select count(cod_auto) from automobil)

declare @sotr int,@auto int
execute counts @sotr output,@auto output
select @sotr as [кол-во сотрудников],@auto as [кол-во автомобилей]


--триггеры
create trigger limitauto
on prokat
after insert,update
as
begin
	declare @row int =@@rowcount
	if @row=0 return
	if @row=1
		begin
		declare @cod_auto int, @count_auto int
		select @cod_auto=cod_auto from inserted
		set @count_auto = (select count(cod_auto) from prokat where @cod_auto=cod_auto)
		if @count_auto >= 2
			begin
			rollback transaction
			print 'Один автомобиль не может участвовать в 2-х прокатах одновременно'
			return
			end
		end
	else
		begin
		rollback transaction
		print 'Не более одной записи в insert, update за раз'
		return
		end
	end

	

create trigger clearauto
on prokat
after update,delete
as
begin
	declare @row int = @@rowcount
	if @row=0 return
	if @row=1
		begin
		declare @cod_auto int
		select @cod_auto=cod_auto from deleted
		update automobil set cod_cli=null where cod_auto=@cod_auto
		end  
	else
		begin
		rollback transaction
		print 'Не более одной записи в insert, update за раз'
		return
		end
end



--триггер и итоговая таблица
select count(cod_auto) as kol_zakaz, count(cod_sotr) as kol_zanyatyh_sotr,
(select count(cod_cli) from client where cod_cli in (select cod_cli from automobil)) as col_tekushih_cli
into itog 
from prokat 
*/
--эффективность сотр

select cod_sotr, fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio, 
(select COUNT(cod_sotr) from prokat where prokat.cod_sotr=sotrudnik.cod_sotr and DATEPART(QUARTER,data_v) in (1,2)  ) as kol_halfyear_1,
(select COUNT(cod_sotr) from prokat where prokat.cod_sotr=sotrudnik.cod_sotr and DATEPART(QUARTER,data_v) in (3,4)  ) as kol_halfyear_2
into itog from sotrudnik


create trigger halfyearitog
on prokat
after insert,update
as
begin
	declare @row int = @@rowcount
	if @row=0 return
	if @row=1
		begin
		declare @halfyear int, @codsotr int
		if exists (select * from inserted)
			begin
			select @halfyear=(select DATEPART(QUARTER,data_v) from inserted)
			select @codsotr=(select cod_sotr from inserted)
				if @halfyear in (1,2)
				update itog set kol_halfyear_1=kol_halfyear_1+1 where cod_sotr=@codsotr
				if @halfyear in (3,4)
				update itog set kol_halfyear_2=kol_halfyear_2+1 where cod_sotr=@codsotr
			end
		end
	else
		begin
		rollback transaction
		print 'Не более одной записи в insert, update за раз'
		return
		end
end

create trigger newsotr
on sotrudnik
after insert,update
as
begin
	declare @row int = @@rowcount
	if @row=0 return
	if @row=1
		begin
		declare @codsotr int, @fiosotr varchar(55)
		if exists (select * from inserted)
			begin
			select @codsotr=(select cod_sotr from inserted)
			if @codsotr not in (select cod_sotr from itog)
				begin 
				select @fiosotr=(select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.' from inserted)
				insert into itog
				values
				(@codsotr,@fiosotr,0,0)
				end
			end
		end
	else
		begin
		rollback transaction
		print 'Не более одной записи в insert, update за раз'
		return
		end
end