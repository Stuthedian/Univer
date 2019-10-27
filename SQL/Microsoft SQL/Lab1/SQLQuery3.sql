use Pansion_2017_110
create table kassa 
(n_kas_ch int primary key
, cod_put int null
, cod_pos int null						
, summa dec(8,2) not null
, data_opl date not null)

create table Otdyhaysh 
(cod_otd int primary key
, FIO  varchar(80) not null
, pasp varchar(10) unique
, tel varchar(10)
, adress varchar(50)
, pol bit not null)

create table Putevka
(cod_put int primary key
, cod_otd int not null
, data_zaezd date not null
, kol_dnei int not null
, cena_odn_dn dec(8,2) not null)

delete from vibor

delete from kassa where cod_put = 21
select * from Putevka
select * from kassa
update Otdyhaysh set FIO = 'Воскобойников' where cod_otd = 1
insert into Putevka
values
(1,1,'21.09.2017',4,100),
(2,1,'21.09.2017',4,100),
(3,1,'21.09.2017',4,100),
(4,1,'21.09.2017',4,100)

update Putevka set kol_dnei = 1 where cod_put in (1 ,2)
update Putevka set kol_dnei = 2 where cod_put in (3 ,4)
update Putevka set cena_odn_dn = 777 where cod_put in (1 ,2)
update Putevka set cod_put = 5 where cod_put = 21 
update Putevka set cena_odn_dn=5 where cod_put = 23


--7
go
alter trigger trigger_putevik
on Putevka
after insert,update
as
begin
	declare @row int = @@rowcount
	declare @cod_put int,@kol_dnei int , @cena_odn_dn dec(8,2) 
	select * into #temp_inserted from inserted
	select * into #temp_deleted from deleted
	while @row > 0
	begin
		if exists (select * from #temp_deleted)
		begin
			select @cod_put = cod_put from #temp_deleted
			delete from kassa where kassa.cod_put = @cod_put
			delete from #temp_deleted where @cod_put = cod_put			
		end
		if exists (select * from #temp_inserted)
		begin
			select @cod_put = cod_put, @kol_dnei = kol_dnei, @cena_odn_dn = cena_odn_dn from #temp_inserted
			insert into kassa
			values 
			(@cod_put, null, @kol_dnei * @cena_odn_dn, convert(date, getdate()))
			delete from #temp_inserted where @cod_put = cod_put			
		end
		set @row = @row - 1
	end
end


select bluda.bl from bluda join menu 
on bluda.bl = menu.bl

select bluda.bl  from bluda 
where not exists (select * from menu where menu.bl = bluda.bl)
select * from menu
select * from vibor
select * from Putevka
select * from kassa
select * from Otdyhaysh left join Putevka
on Otdyhaysh.cod_otd = Putevka.cod_otd
where dateadd(day, kol_dnei, data_zaezd) >= getdate()
insert into Putevka
values
(12,2,'11.01.2016',4,100)
insert into Putevka
values
(24,3,getdate(),4,100),
(25,4,getdate(),4,22),
(26,5,getdate(),4,100),
(27,6,getdate(),4,22),
(28,7,getdate(),4,100)
insert into vibor--should insert
values
(1,1,1)
insert into vibor--shouldn't insert because bl not in menu
values
(1,1,2)
insert into vibor--shouldn't insert because cod_otd not in putevka
values
(6,1,1)
insert into vibor--shouldn't insert because putevka is expired
values
(2,1,1)
update vibor set bl = 2 where cod_otd = 1 and t = 1 and bl = 1
--9
go
alter trigger to_vibor
on vibor
instead of insert,update
as
begin
	declare @row int = @@rowcount
	if @row > 0
	begin
		insert into vibor
		select * from inserted
		where
		exists (select * from Otdyhaysh left join Putevka
		on Otdyhaysh.cod_otd = Putevka.cod_otd
		where Otdyhaysh.cod_otd = inserted.cod_otd and dateadd(day, kol_dnei, data_zaezd) >= getdate())
		and
		exists (select * from menu
		where menu.bl = inserted.bl)
	end
end
--10
insert into vibor
values
(3,1,19),
(4,2,21),
(5,3,3),
(6,1,6),
(7,2,31),
(3,3,32),
(4,1,14),
(5,2,19),
(6,3,14)
select * from vibor
select * from kassa
insert into kassa
values
(90, 1, 1, 100, getdate())
--11
go
drop trigger insert_into_kassa
alter trigger insert_into_kassa
on kassa
after insert
as
begin
	declare @row int = @@rowcount
	if @row > 1
	begin
		rollback transaction
		print 'Не более записи в insert за раз'
		return
	end
	if @row != 0
	begin
		if exists (select * from inserted where (cod_pos is null and cod_put is null) 
					or (cod_pos is not null and cod_put is not null))
		begin
			rollback transaction
			print 'Двусмысленная операция'
			return
		end
		if exists (select * from inserted where cod_pos is not null)
		begin
			declare @cod_pos int, @summa decimal(8,2), @data_opl date
			select @cod_pos = cod_pos, @summa = summa, @data_opl = data_opl from inserted
			if (select sum(summa) from kassa where cod_pos = @cod_pos)> (select kol * cena from postavki where cod_pos = @cod_pos)
			begin
				rollback transaction
				print 'Cумма больше суммы оплаты всей поставки'
				return
			end
			if ((select sum(summa) from kassa where cod_put is not null)
				-(select sum(summa) from kassa where cod_pos is not null)) < @summa
			begin
				rollback transaction
				print 'Недостаточно денег в кассе'
				return
			end
			update postavki set summ = @summa, data_opl = @data_opl where cod_pos = @cod_pos
		end
	end
end

--12
go
drop trigger update_delete_kassa
create trigger update_delete_kassa
on kassa
after update, delete
as
begin
	declare @row int = @@rowcount
	if @row > 1
	begin
		rollback transaction
		print 'Не более записи в update, delete за раз'
		return
	end
	if @row != 0
	begin
		if exists (select * from deleted where cod_pos is not null)
		begin
			rollback transaction
			return
		end
	end
end
select ident_current('kassa')

select * from kassa
select * from postavki
insert into kassa
values
(null,1,10,getdate())
--14
alter procedure dolg_post
@nazvanie varchar(50), @gorod varchar(50)
as
select (select produkt from produkt where pr = postavki.pr), 
(kol * cena) - isnull((select sum(summa) from kassa where kassa.cod_pos = postavki.cod_pos),0) as dolg from postavki
where pc in (select pc from postavshiki where nazvanie = @nazvanie and gorod = @gorod)
execute dolg_post 'СЫТНЫЙ','Ленинград'

--15
go
alter procedure same_year_otd
@cod_otd int, @year int
as
select (select FIO from Otdyhaysh where Otdyhaysh.cod_otd = Putevka.cod_otd) from Putevka
where cod_otd != @cod_otd and year(data_zaezd) = @year 
group by cod_otd
having sum(kol_dnei) = (select sum(kol_dnei) from Putevka where cod_otd = @cod_otd and year(data_zaezd) = @year)
go
execute same_year_otd 1,2018

select sum(kol_dnei) from Putevka 
where cod_otd = 1 and year(data_zaezd) = 2018
select * from postavki






--16
alter procedure otd_ratsion
as
select  FIO,
(select count(bl) from vibor where t = 1 and cod_otd = otd.cod_otd) as zavtrak,
(select count(bl) from vibor where t = 2 and cod_otd = otd.cod_otd) as obed,
(select count(bl) from vibor where t = 3 and cod_otd = otd.cod_otd) as uzhin
from (select * from Otdyhaysh where exists (select * from vibor where cod_otd = Otdyhaysh.cod_otd)) as otd
execute otd_ratsion