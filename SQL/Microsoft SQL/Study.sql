use study
create table v_kredit(
 cod_vkr int primary key,
 name varchar (30),
 usl varchar (20),
 stav dec(8,2),
 srok int
)

drop table disp

create table klient (
 cod_kl int primary key,
 name varchar (30),
 v_sob varchar (20),
 adres varchar (30),
 tel varchar (10),
 kon_l varchar (40)
)

create table kredit (
  cod_vkr int references v_kredit,
  cod_kl int references klient,
  ss dec(8,2),
  data date,
primary key (cod_vkr,cod_kl,ss,data)
)

insert into v_kredit values
(1,'simple','4evri1',10.2,2),
(2,'advanced','4hartplayers',8.9,3),
(3,'suprimum','onli4elitpipl',7.5,2.5)

insert into klient values
(22,'ip mkrtchyan','dacha','zdes','13212','ivan'),
(32,'ip okl','garazh','tama','123m','vers'),
(41,'holding','studio','ssweden','830','polina')

insert into kredit values
--(1,22,23000,'21.01.2016'),
(3,22,78000,'23.09.2007'),
(2,41,10000,'12.08.2017'),
(2,32,25000,'14.05.2009'),
(3,22,7800,'01.09.2001')
delete from  kredit
where cod_vkr=1
select * from kredit
--1)
select name from klient left join kredit
on klient.cod_kl=kredit.cod_kl
where v_sob='dacha'
group by name
having count(kredit.cod_kl)>2
--2)
select name,stav from v_kredit
where cod_vkr in (select cod_vkr from kredit where ss in  (select max(ss) from kredit))
--3)
select name,'never not vydavalsya' as info from v_kredit
where  not exists (select* from kredit where cod_vkr=v_kredit.cod_vkr)
union
select name,'malo raz vydavalsya' from v_kredit
where cod_vkr in 
(select cod_vkr from kredit
group by cod_vkr
having count(cod_vkr)=
(select min(colcred.col) from 
(select count(cod_vkr) as col from kredit 
group by cod_vkr) as colcred))
--4)
select name,count(distinct cod_kl), isnull(mes.info,0) from v_kredit left join kredit
on v_kredit.cod_vkr=kredit.cod_vkr
left join (select cod_vkr,count(cod_vkr ) as info from kredit where month(data)=5 group by cod_vkr) as mes on v_kredit.cod_vkr=mes.cod_vkr
group by name,mes.info


;
count(mes.cod_vkr)left join (select cod_vkr from kredit where month(data)=5) as mes on v_kredit.cod_vkr=mes.cod_vkr



/*select name,count( distinct cod_kl),(select cod_vkr,count(cod_vkr ) as info from kredit where month(data)=5 and cod_vkr=v_kredit.cod_vkr) as seom from v_kredit left join kredit
on v_kredit.cod_vkr=kredit.cod_vkr
left join (select cod_vkr,count(cod_vkr ) as info from kredit where month(data)=5 group by cod_vkr) as mes on v_kredit.cod_vkr=mes.cod_vkr
group by name,seom

select cod_vkr,cod_kl,ss from kredit 
where ss>all(select ss from kredit where cod_vkr!=kredit.cod_vkr and cod_kl!=kredit.cod_kl and ss!=kredit.ss)*/

select cod_vkr,name from v_kredit
where stav > all(select stav from v_kredit as we where  we.cod_vkr!=v_kredit.cod_vkr)

select cod_vkr,name from v_kredit
where  exists (select * from v_kredit as we where  we.cod_vkr!=v_kredit.cod_vkr and we.stav<v_kredit.stav)

select name from v_kredit
--group by name,stav
where stav=(select max(stav) from v_kredit)

select name,info from
(select cod_vkr,name,'never not vydavalsya' as info from v_kredit
where  not exists (select* from kredit as kr where kr.cod_vkr=v_kredit.cod_vkr)
union
select cod_vkr,name,'malo raz vydavalsya' from v_kredit
where cod_vkr in (
select cod_vkr from kredit
group by cod_vkr
having count(cod_vkr)=
(select min(colcred.col) from 
(select count(cod_vkr) as col from kredit 
group by cod_vkr) as colcred))) as tabl
order by tabl.cod_vkr

select name , (
case 
when (not exists (select * from kredit as kr where kr.cod_vkr=v_kredit.cod_vkr ) or (select ks.cod_vkr from kredit as ks where ks.cod_vkr=v_kredit.cod_vkr group by ks.cod_vkr having count(ks.cod_vkr)=0 )) then 'never not vydavalsya'
when exists (select * from kredit 
group by cod_vkr
having count(cod_vkr)=
(select min(colcred.col) from 
(select count(cod_vkr) as col from kredit
 group by cod_vkr) as colcred)) 
 then 'malo raz vydavalsya'
end
)as info from v_kredit

select janr,count(v_book.cod_b),col.mes from book left join v_book
on book.cod_b=v_book.cod_b
left join (select cod_b,count(cod_b) as mes from v_book where month(data)=1 group by cod_b) as col on  book.cod_b=col.cod_b
group by janr,col.mes


select name from otdel 
where cod_otd in (select cod_otd from (select cod_otd,sum(ss) as sym group by cod_otd) as sumras group by cod_otd having sum(ss)=max(sumras.sym))

select name from otdel left join ras
on otdel.cod_otd=ras.cod_otd
group by name
having sum(ss)>all(select sum(ss) from ras as otdras where  otdras.cod_otd!=ras.cod_otd group by otdras.cod_otd)


---
create table prepod (
	cod_prep int primary key,
	fam varchar(50),
	im varchar(50),
	otsh varchar(50),
	step varchar(10),
	dol varchar(20),
	stah  int

)
create table disp(
	cod_dis int primary key,
	name varchar(20),
	kol int
)
create table nagr(
	cod_prep int   references prepod,
	cod_dis int   references disp,
	ng char(4),
	primary key (cod_prep,cod_dis,ng)
)
drop table nagr
insert into prepod values
(1,'agyhn','iuj','ehelen','adult','kafka',3),
(2,'dsada','vbcvbc','uojg','qmvsd','xcl',5),
(3,'dada','cxv','3fcv','nhyuy','tryt',4)
insert into disp values
(22,'math',23),
(21,'toer',7),
(46,'ufo',9),
(23,'matria',4)
insert into disp values
(56,'ma',2)
insert into nagr values 
(1,22,410),
(1,21,210),
(1,46,345),
(1,23,211),
(3,22,410),
(3,21,210),
(3,46,345),
(3,23,211)
insert into nagr values 
(2,46,345),
(2,23,211)

--1)
/*select fam from prepod
where stah>2
group by fam,prepod.cod_prep
having (select count(distinct cod_dis) from nagr where nagr.cod_prep=prepod.cod_prep)>3*/

select fam from prepod left join nagr
on prepod.cod_prep=nagr.cod_prep
where stah>2
group by fam
having count(distinct cod_dis)>3
--2)
select name from disp
where cod_dis in (select cod_dis from nagr  
group by cod_dis
having count(cod_prep)=
	(select max(colt.colpr) from 
		(select count(cod_prep)as colpr from nagr 
			group by cod_dis) 
				as colt))

--3)
select name,'min(kol)' from disp as d  join nagr
on d.cod_dis=nagr.cod_dis
group by d.cod_dis,name
having sum(kol)<all(select sum(kol) from disp as d2  join nagr
					on d2.cod_dis=nagr.cod_dis
					where d2.cod_dis!=d.cod_dis
					group by d2.cod_dis)
/*
select name from disp
where cod_dis in (select cod_dis from nagr as n
					where (select cod_dis  from nagr where nagr.cod_dis=n.cod_dis and  sum(kol) in 
					(select min(ne.sk) from (select sum(kol) as sk from nagr)as ne)))

*/
select name,'min(kol)' from disp as d   join nagr
on d.cod_dis=nagr.cod_dis
group by /*d.cod_dis,*/name
having sum(kol)=(select min(ne.sk) from (select sum(kol) as sk from disp join nagr on disp.cod_dis=nagr.cod_dis group by  disp.cod_dis)as ne)
union
select name,'not exists' from disp
where  not exists (select * from nagr where nagr.cod_dis=disp.cod_dis)
--4)
select name,count(distinct gr.ng)as groups,count(distinct pr.cod_prep) as profs from disp left join (select cod_dis,ng from nagr) as gr
on gr.cod_dis=disp.cod_dis
left join (select cod_dis,cod_prep from nagr) as pr
on pr.cod_dis=disp.cod_dis
group by name


select fam from sotryd
where cod_sot in  (select cod_sot from from rabot join vid_rabot on rabot.cod_vid=vid_rabot.cod_vid where opl =(select min(opl) from vid_rabot))

select fam,count(distinct r.cod_vid),count(distinct r2.cod_vid) from sotryd join (select cod_sot,cod_vid from rabot where year(data_f)=2k17) as r on sotryd.cod_sot=r.cod_sot
join (select cod_sot,cod_vid from rabot ) as r2 on sotryd.cod_sot=r2.cod_sot
group by fam
--bil18 zad2
create table postavshiki(	
	cod_post  int primary key,
	name varchar(50),
	adres varchar(30),
	tel varchar(10)
)
create table detail(
	cod_det int primary key,
	name varchar(50),
	artikl varchar(20),
	cena dec(8,2)
)
create table postavki(
	cod_post int,
	cod_det int,
	kol  int,
	data date,
	primary key (cod_post,cod_det,kol,data)
)
insert into postavshiki values
(1,'korushka','pasmana3','17683'),
(2,'leto','olodsayueva3','712'),
(3,'terte','gorohova3','583')
insert into postavki values
(1,1,10,'01.03.2015'),
--(2,1,38,'01.03.2015'),
(3,1,23,'01.03.2015'),
(3,2,23,'01.03.2015')
delete from postavki
where cod_post=2
insert into detail values
(1,'careburator','A1',100.2),
(2,'refridgerator','C3',34.7)
update postavki set  data='01.02.2007' where cod_post=1


--1)
select name from postavshiki join postavki
on postavshiki.cod_post=postavki.cod_post
where tel like '*1*' and tel like  '*3*'
group by name
having count(postavki.cod_post)>=10
--2)
select name from detail
where cod_det in (select cod_det from postavki group by cod_det 
	having count(kol)=
	(select max(kdet.kdet) from 
		(select count(kol) as kdet from postavki 
		 group by cod_det ) as kdet ))



--
select name from detail
where exists (select * from postavki where postavki.cod_det=detail.cod_det
			  group by cod_det 
			  having count(kol)=
				(select max(kdet.kdet) from 
					(select count(kol) as kdet from postavki 
							group by cod_det ) as kdet ))
--
select name from detail join postavki
on detail.cod_det=postavki.cod_det
group by postavki.cod_det,name
having count(kol)>all(select count(kol) from detail  join postavki as p
						on detail.cod_det=p.cod_det 
						where p.cod_det!=postavki.cod_det
						group by p.cod_det)

--3)
select name,'nothing' from postavshiki
where not exists (select * from postavki where postavki.cod_post=postavshiki.cod_post)
union
select name,'lower amount' from postavshiki 
where cod_post in (select cod_post from postavki
					group by cod_post
					having sum(kol)=
					(select min(kkol.kkol) from 
					(select sum(kol) as kkol from postavki
						group by cod_post) as kkol))

--4)
select name,count(p.cod_post) as [2k07] ,count(postavki.cod_post) as entirelife from postavshiki  left join (select cod_post from postavki where year(data)=2007) as p
on postavshiki.cod_post=p.cod_post
left join postavki
on postavshiki.cod_post=postavki.cod_post
group by name





select name from zakaz 
where cod_zak in (select cod_zak from zakazi 
				  where cod_tov in(select cod_tov from zakazi
								    group by cod_tov	
									having sum(kol)=
							(select max(kkol.kkol) from (select sum(kol) as kkol from zakaz
							 group by cod_tov) as kkol)
								)
							 )