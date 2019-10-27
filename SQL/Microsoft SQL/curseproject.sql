create database prokat
use prokat

create table client
(
	cod_cli int primary key,
	fam varchar(50) not null,
	im varchar(50) not null,
	otch varchar(50),
	pol varchar(1) not null check (pol in ('�','�','�','�')),
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
	pol varchar(1) not null check (pol in ('�','�','�','�')),
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
(1,'�������������','����','����������','�','08.12.1945','�����������','89134456481'),
(2,'�������','��������','����������','�','01.12.1947','�����������','89133406481'),
(3,'���������','����','��������','�','09.12.1949','�����','89133456481'),
(4,'�������','������','����������','�','07.12.1965','������','89233456481'),
(5,'��������','�������','��������','�','05.12.1955','�����������','88133456481')

insert into doljnost
values
(1,'������� ���������',45000,'������ ����, ������������� ������������'),
(2,'��������� ��������',35000,'������ ����'),
(3,'������-���������',65000,'������ ����, ������������� ������������, �������������� ������������')

insert into automobil
values
(1,'Suzuki Ignis',2006,177000,349000,1),
(2,'Smart Forfour',2005,146000,295000,2),
(3,'Opel Astra GTC',2006,200000,285000,3),
(4,'Mazda CX-5',2013,58000,1099000,3),
(5,'Toyota Prius',2012 ,0,700000,null)

insert into sotrudnik
values
(1,'��������','������','����������','�','05.12.1951','�������','88133457481',1),
(2,'������','�����','����������','�','05.12.1935','������','88133456489',1),
(3,'Ը������','�������','����������','�','05.11.1955','������','88133456481',2),
(4,'��������','�������','����������','�','05.10.1955','�����������','85133456481',2),
(5,'�������','�����','�������������','�','06.12.1955','�����','88133458481',2),
(6,'�����','�����','�������','�','02.12.1955','�����������','88133456381',3),
(7,'Ը�����','���������','������������','�','07.10.1955','�����������','88155458481',null)

insert into prokat
values
(1,1,'29.10.2017',3,2000),
(2,1,'23.10.2017',1,1000),
(3,2,'22.10.2017',10,20000),
(4,3,'21.10.2017',9,9000)

select nazv from automobil--������ �� ����� ������� 
where year(getdate()) - god <= 5

--������ �� ���������� ������� (left,right, inner join)

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

--���������� �-��

select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio,count(prokat.cod_sotr) as kol from sotrudnik left join prokat 
on prokat.cod_sotr=sotrudnik.cod_sotr
where adr != '�������'
group by sotrudnik.cod_sotr,fam,im,otch
having count(prokat.cod_sotr) > 0

--��������������� ���������� � from,where,having,select

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
select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio, isnull((select naim from doljnost where doljnost.cod_dol=sotrudnik.cod_dol),'��� ���������') as doljnost from  sotrudnik


	--from
select fam + ' ' + left(im,1) + '.' + left(otch,1)+ '.'  as fio from 
	(select * from sotrudnik as sotr
		where  not exists (select * from prokat 
							where sotr.cod_sotr=prokat.cod_sotr)) as s2


-- ���������������� �-��
	--���������
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

	--���������
create function autoatprokat()
returns table
as
return 
	select * from automobil
	where cod_auto in (select cod_auto from prokat)

select nazv,god from dbo.autoatprokat() 
where (year(getdate()) - god) >= (year(getdate()) - (year(getdate()) - 10))

-- ���������
	--1 ������� ��������, ��������� �������
create procedure sotrinfo
@codsotr int
as
	if @codsotr not in (select cod_sotr from sotrudnik)
		print '����� ��������� �����������'
	else
	begin
	select nazv,god,probeg,automobil.cena from automobil join prokat
	on automobil.cod_auto=prokat.cod_auto
	where cod_sotr=@codsotr
	end

execute sotrinfo 1

	--2<= �������� ���������
create procedure counts
@countsotr int output,@countauto int output
as
set @countsotr = (select count(cod_sotr) from sotrudnik)
set @countauto = (select count(cod_auto) from automobil)

declare @sotr int,@auto int
execute counts @sotr output,@auto output
select @sotr as [���-�� �����������],@auto as [���-�� �����������]


--��������
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
			print '���� ���������� �� ����� ����������� � 2-� �������� ������������'
			return
			end
		end
	else
		begin
		rollback transaction
		print '�� ����� ����� ������ � insert, update �� ���'
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
		print '�� ����� ����� ������ � insert, update �� ���'
		return
		end
end



--������� � �������� �������
select count(cod_auto) as kol_zakaz, count(cod_sotr) as kol_zanyatyh_sotr,
(select count(cod_cli) from client where cod_cli in (select cod_cli from automobil)) as col_tekushih_cli
into itog 
from prokat 
*/
--������������� ����

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
		print '�� ����� ����� ������ � insert, update �� ���'
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
		print '�� ����� ����� ������ � insert, update �� ���'
		return
		end
end