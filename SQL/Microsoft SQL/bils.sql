-- bil 1 zad2
create database teatr
create table akter(
	cod_akt int primary key,
	fam varchar(50),
	im varchar(50),
	otsh varchar(50),
	zvan varchar(10),
	staj int
)

create table spekt(
	cod_sp int primary key,
	name varchar(50),
	god int,
	bj dec(7,2)
)

create table zan(
	cod_akt int references akter,
	cod_sp int references spekt,
	rol varchar(10),
	stoim dec(8,2)
)

insert into akter
values
(1,'a','b','c','goood',7),
(2,'a','b','c','goood',7),
(3,'a','b','c','goood',10),
(4,'a','b','c','goood',10),
(5,'a','b','c','goood',15),
(6,'a','b','c','goood',15)

insert into spekt
values
(1,'SpektA',1995, 40000),
(2,'SpektB',1995, 40000),
(3,'SpektC',1995, 50000),
(4,'SpektD',1995, 60000),
(5,'SpektE',1995, 60000)

insert into zan
values
(2,1,'rol',22),
(3,4,'rol',22),
(3,2,'rol',22),
(4,5,'rol',22),
(4,4,'rol',22),
(5,1,'rol',22),
(5,2,'rol',22),
(6,3,'rol',22),
(6,2,'rol',22)


select * from spekt 
where name like '%[^A]%'
--1
select name from spekt
where bj > 50000 and (select count(*) from zan where zan.cod_sp = spekt.cod_sp) > 10

--2
select count(*) from (select cod_akt from spekt join zan
on spekt.cod_sp = zan.cod_sp
where bj = (select max(bj) from spekt)) as t

--3
select cod_akt,fam, 'Nowhere' from akter
where cod_akt not in (select cod_akt from zan)
union
select cod_akt,fam, 'Just a little' from akter
where cod_akt in (select cod_akt from zan
where (select count(cod_sp) from zan as z where zan.cod_akt = z.cod_akt) = (select min(t.kol) from (select count(*) as kol from zan group by cod_akt) as t))

--4
select name, (select count(cod_akt) from zan where zan.cod_sp = spekt.cod_sp), 
(select count(cod_akt) from zan where zan.cod_sp = spekt.cod_sp and cod_akt in (select cod_akt from akter where staj > 10)) from spekt

-- bil 10 zad2
--1
select marka from stanki
where strana='Russia'  and cod_st in (select cod_st from remont) 
and 
(select count(*) from remont where cod_st in (select cod_st from stanki as s where s.marka = stanki.marka)) >= 5
--2
select nazvanie from vid_remont
where (select count(cod_st) from remont where remont.cod_rem = vid_remont.cod_rem) 
= (select max(t.kol) from (select count(cod_st) as kol from remont group by cod_rem) as t)
--3
select marka,'Ne remontirovalsya' from stanki
where cod_st not in (select cod_st from remont)
union
select marka, 'Ne bolee 2-h raz' from stanki
where (select count(*) from remont where remont.cod_st = stanki.cod_st) < 2
--4
select marka, 
(select count(*) from remont where cod_st in (select cod_st from stanki as s where s.marka = stanki.marka) and datepart(quarter,date) = 2),
 (select count(*) from remont where cod_st in (select cod_st from stanki as s where s.marka = stanki.marka) and year(date) = year(getdate())) from stanki
-- bil 22 zad2
--1
select fam from sotryd
where okl > 15000 and (select count(cod_vid) from rabot where rabot.cod_sot = sotryd.cod_sot) >= 5
--2
select fam from sotryd
where cod_sot in (select cod_sot from rabot where data_f - data_n  = (select max(data_f - data_n) from rabot))
--3
select fam, 'ne uchastvuet' from sotryd
where cod_sot not in (select cod_sot from remont)
union
select fam, 'min oplata' from sotryd
where cod_sot in (select cod_sot from remont where cod_vid in (select cod_vid from vid_remont where opl = (select min(opl) from vid_remont)))
--4
select fam, (select count(cod_vid) from remont where remont.cod_sot = sotryd.cod_sot and year(data_f) = year(getdate())),
(select count(cod_vid) from remont where remont.cod_sot = sotryd.cod_sot) from sotryd
--bil1(big)
--1
select fam, (select count(rol) from zan where zan.cod_akt = akter.cod_akt and zan.cod_sp in (select cod_sp from spekt where name like '__[�,�]%'))
from akter
--2
select name from spekt
where bj > 50000 and (select count(cod_akt) from zan where zan.cod_sp = spekt.cod_sp) > 70
--3
select count(distinct cod_akt) from zan
where cod_sp in (select cod_sp from spekt
				where bj = (select max(bj) from spekt))
--4
select fam from akter
where (select count(rol) from zan where zan.cod_akt = akter.cod_akt and 
	zan.cod_sp in (select cod_sp from spekt where god = year(getdate()))) >
	(select count(rol) from zan where zan.cod_akt = akter.cod_akt and 
	zan.cod_sp in (select cod_sp from spekt where god = year(getdate()) - 1)) 
--5
select fam, 'ne igraet' from akter
where cod_akt not in (select cod_akt from zan)
union
select fam, 'malo spekt' from akter
where (select count(cod_sp) from zan where zan.cod_akt = akter.cod_akt) =
(select min(t.kol) from
(select count(cod_sp) as kol from zan
group by cod_akt) as t)
--6
select name, (select count(cod_akt) from zan where zan.cod_sp = spekt.cod_sp), 
(select count(cod_akt) from zan where zan.cod_sp = spekt.cod_sp 
	and cod_akt in (select cod_akt from akter where staj > 10)) from spekt
--bil4 (big)
--1
select fam, (select count(cod_avto) from v_avto as v where v.cod_kl = klient.cod_kl 
	and cod_avto in (select cod_avto from avto where stoim_pr > 200)) from klient
--2
select adres from klient
where (fam not like '%[�,�]%' or fam not like '%[�,�]%')
	and (select count(cod_avto) from v_avto as v where v.cod_kl = klient.cod_kl) >= 2
--3
select marka, stoim_av from avtomobil
where (select count(*) from v_avto as v where v.cod_avto = cod_avto) 
=
(select max(t.kol) from (select count(*) as kol from v_avto
group by cod_avto) as t)
--4
select fam from klient
where (select count(*) from v_avto as v where v.cod_kl = cod_kl and datepart(quarter, datan) = datepart(quarter, getdate)) 
	< (select count(*) from v_avto as v where v.cod_kl = cod_kl and datepart(quarter, datan) = datepart(quarter, getdate) - 1)
--5
select distinct tip, 'ne vydavalsya' from avto
where cod_avto not in (select cod_avto from v_avto)
union
select distinct tip, 'malo vydavalsya' from avto
where (select count(*) from v_avto as v where v.cod_avto = cod_avto) = 
(select min(t.kol) from (select count(*) as kol from v_avto
group by cod_avto) as t)
--6
select distinct tip, 
(select count(*) from v_avto where cod_avto in (select cod_avto from avto as a where a.tip = avto.tip)), from avto
(select count(*) from v_avto where datepart(quarter, datan) = datepart(quarter, getdate) 
	and cod_avto in (select cod_avto from avto as a where a.tip = avto.tip))



create table clienty(
	cod_cl int primary key,
	nazv varchar(50),
	tel varchar(10)
)
create table credity(
	cod_cr int,
	cod_cl int references clienty,
	summa int,
	data_v date,
	primary key (cod_cr, cod_cl, summa, data_v) 
)
insert into clienty
values
(1, 'ООО ТРУД', '8(383)234-56-67')
insert into credity
values
(1,1,4000, '09.03.2016')

select cod_cr, nazv, tel, summa, data_v from clienty join credity
on clienty.cod_cl = credity.cod_cl
where year(data_v) = 2016 and summa > 1000
--1
select adr from pokyp
where adr = 'Омск' and (select sum(kol) from sdelki where sdelki.kp = kp) > 10
--2
select name from tovar
where (select max(ds) from sdelki where sdelki.kt = kt) = (select max(ds) from sdelki)
--3
select tel, 'не заключали сделок' from pokyp
where kp not in (select kp from sdelki)
union
select tel, 'макс. количество сделок' from pokyp
where (select count(*) from sdelki where sdelki.kp = kp) =
(select max(t.kol) from (select count(*) as kol from sdelki
group by kp) as t)
--4
select name, (select count(*) from sdelki where sdelki.kt = kt and month(ds) = month(getdate())),
(select count(*) from sdelki where sdelki.kt = kt ) from tovar






























