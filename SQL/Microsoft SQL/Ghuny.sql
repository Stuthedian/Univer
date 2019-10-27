create database pansion2k17
use pansion2k17
create table produkt(pr int primary key
,product varchar(30)
,belki dec(18,2)
,ziri dec(18,2)
,uglevod dec(18,2)
,k dec(18,2)
,ca dec(18,2)
,na dec(18,2)
,b2 dec(18,2)
,pp dec(18,2)
,c dec(18,2) )
create table trapezi(t int primary key
,trapeza char(10)) 
select * from  vibor
create table osnova(kod_osnova int primary key
,osnova varchar(30))	
create table vid_blud(b char(1) primary key
,vid char(10))
create table postavshiki (pc int primary key
,nazvanie varchar(50) 
,status varchar (50)
,gorod varchar (50)
,adres varchar (50)
,tel char (10)  )
create table bluda (bl int primary key
,bludo varchar (30)
,kod_osnova int references osnova
,b char(1)references vid_blud
,vihod dec (18,2) 
,trud dec (18,2)  )
create table recept (bl int references bluda 
,recept varchar (250)
,vari varchar(5) 
,primary key(bl,vari)
)
create table nalishie(pr int 
,kol_vo dec(18,2)
,stoim dec (18,2)
,primary key (pr) 
)
create table sostav(bl int references bluda
,pr int references produkt
,vec dec (18,2)
,primary key (bl,pr)
,)
create table menu(t int references trapezi
,b char(1) references vid_blud
,bl int references bluda
,primary key (t,b,bl)
)
create table postavki(pc int references postavshiki
,pr int references produkt
,kol dec (18,2)
,cena dec (18,2)
,data date
,primary key(pc,pr,data)
)
create table vibor(cm int 
,t int references trapezi
,b char(1) references vid_blud
,bl int references bluda
,primary key (cm,t,b,bl)
)

insert into trapezi(t,trapeza)
values (1,	'Завтрак')
	,(2,	'Обед')
	,(3,	'Ужин')

insert into osnova(kod_osnova,osnova)
values (1,	'Кофе')
,(2,'Крупа')
,(3,'Молоко')
,(4,'Мясо')
,(5,'Овощи')
,(6,'Рыба')
,(7,'Фрукты')
,(8,'Яйца')

alter table bluda alter column  bludo  varchar (50)
alter table osnova alter column  osnova  varchar (50)
alter table produkt alter column  product  varchar (50)
alter table bluda add unique(bludo)
alter table produkt add unique(product)
alter table vid_blud add unique(vid)
select * from vibor

alter table trapezi add unique(trapeza)
alter table bluda add check (vihod>=0)
alter table bluda add check (trud>=0)
alter table sostav add check (vec>=0)

insert into vibor (cm,t,b,bl) 
values (1,1,'З',1)
 ,(1,1,'З',8)
 ,(1,1,'Н',33)
 ,(1,1,'Н',30)
 ,(1,2,'З',1)
 ,(1,2,'Г',13)
 ,(1,2,'Н',32)

update vibor set bl=2 where cm=1 and t=2 and b='З' and bl=1
update vibor set bl=32 where cm=1 and t=1 and b='Н' and bl=30
update vibor set bl=16 where cm=1 and t=2 and b='Г' and bl=13

delete from vibor where b='Г' or b='Н'

--2-я лаба
 
 select nazvanie,status ,gorod ,adres  from postavshiki
 select bludo,vihod from bluda
 select product from produkt 
 order by product
 select bludo from bluda
 order by trud desc
 select product,((belki + uglevod)*0.41 + ziri*0.93) as ccal from produkt
 select product from produkt
 order by ((belki + uglevod)*0.41 + ziri*0.93) desc
 
 select bludo,osnova,vec,product from bluda  join osnova  
 on bluda.kod_osnova = osnova.kod_osnova
  join sostav on sostav.bl=bluda.bl 
  join produkt on produkt.pr  = sostav.pr
 order by bludo

 select trapeza,bludo,vid from trapezi join menu 
  on trapezi.t=menu.t
  join vid_blud on vid_blud.b=menu.b
  join bluda on bluda.bl=menu.bl

   select trapeza from trapezi

   select bluda.bl,menu.bl,bludo from bluda  left join menu
   on bluda.bl=menu.bl

   select bluda.bl,menu.bl,bludo from bluda right join menu
   on bluda.bl=menu.bl

   select bluda.bl,menu.bl,bludo from bluda full  join menu
   on bluda.bl=menu.bl

   select bludo from bluda left join menu
   on bluda.bl=menu.bl
   where menu.bl is null

   select product from produkt
   where ziri=0 or b2=0 and  pp=0 and c=0 

   select product from produkt
   where  k=0 or  ca=0 or na=0 

   select bludo,vid from bluda  join vid_blud
   on  bluda.b=vid_blud.b
   order by vid,bludo

   select product from produkt 
   where uglevod=0 or ziri=0
   order by product

    select product from produkt 
   where belki between 10 and  50  and  ziri<100

   select product from produkt
   where uglevod=0 and na=0

   select product from produkt
   where product like '%не%' or product like '%ло%'

   select product from produkt
   where product like '%[в-ж]%' and product like '%[^о]%'
   
   select * from nalishie
  
   
   select bludo from bluda join osnova
   on bluda.kod_osnova=osnova.kod_osnova
   where bludo like 'Салат%' and osnova.kod_osnova=5
   
   select product from produkt join nalishie 
   on produkt.pr=nalishie.pr
   where kol_vo=0 or kol_vo is null
    
   select bludo from bluda join osnova
   on bluda.kod_osnova=osnova.kod_osnova
   where bluda.kod_osnova=2 or bluda.kod_osnova=5 or bluda.kod_osnova=8
   
   select nazvanie, status, gorod, product from postavshiki join postavki
   on postavshiki.pc=postavki.pc
   join produkt 
   on produkt.pr=postavki.pr
   where (month(data) between 1  and 3)  and YEAR(data) between 2004 and 2017
   
   select product from produkt join postavki
   on produkt.pr=postavki.pr 
   where YEAR(data)=2005
   
   
   select bludo from bluda join osnova
   on bluda.kod_osnova=osnova.kod_osnova
   where bludo not like '% %' and  len(osnova)<=6
   
   select bludo from bluda 
   where  left(bludo,1) = right (bludo,1)

   --3-я лаба
   
   select SUM (kol_vo) as [obshij ves],  count (distinct pc) as [vse postavshiki] from nalishie  join postavki
   on nalishie.pr=postavki.pr

   select SUM (kol_vo) as [Ves pomidorok],  count (distinct pc) as Pomidorovozy from nalishie  join postavki
   on nalishie.pr=postavki.pr
   where postavki.pr=11
   
   select SUM(kol_vo) as tvorog, COUNT(distinct pc) as tvorogovedy from nalishie  join postavki  
   on nalishie.pr=postavki.pr
   where postavki.pr=8 and (month(data) between 1  and 6)  and YEAR(data) =2004
   
   select bludo, count (produkt.pr) from bluda join sostav 
   on bluda.bl=sostav.bl
   join produkt on sostav.pr=produkt.pr
   group by bludo
   
   select product, SUM(kol_vo) as massa from nalishie  join produkt
   on produkt.pr=nalishie.pr
   join  postavki on postavki.pr=nalishie.pr
   where (month(data) between 1  and 6)  and YEAR(data) =2004
   group by product
      
	select nazvanie,sum(pr)as [kol-vo],avg(cena) as srednya from postavshiki join postavki
	on postavshiki.pc=postavki.pc
	group by nazvanie

	select sum(cena) as [obshaja cena] ,avg(cena) as srednya,count(pr)as [kol-vo],count(distinct cena)as [kol-vo raznyh cen],count (kol) as [kol-vo postavok] from postavki
	where pc=1 or pc=4 or pc=6
	group by pc
	

	select trapeza,count(bl) from trapezi join menu
	on trapezi.t=menu.t
	group by trapeza

	select trapeza,count(distinct b) from trapezi join menu
	on trapezi.t=menu.t
	group by trapeza

	select   month(data) as mesyac,sum(cena) as summa from postavki
	group by month(data)

	select product,sum(kol) as objem,count(distinct pc) as colichestvo from produkt  join  postavki
	on produkt.pr=postavki.pr
	where (month(data) between 1 and  3) and not ((ziri=0  or (b2=0 and pp=0 and c=0)) or (ziri is null or(b2 is null and pp is null and c is null)))
	group by product


	select product,sum(kol) as objem,count(pc) [kol-vo postavshikov] from produkt  join postavki 
	on produkt.pr=postavki.pr
	where not(pc=1 or pc=4 or pc=6)
	group by product
	having sum(kol)>4
	

	select trapeza,count(b) from trapezi join menu 
	on trapezi.t=menu.t
	where b='З'  or b='Н'
	group by trapeza

	select * from menu

	select product from produkt left join postavki 
	on produkt.pr=postavki.pr
	where YEAR(data)=2004 
	group by product
	having COUNT(pc)>2 

	select bludo,sum((((belki+uglevod)/1000)*4.1+(ziri/1000)*9.3)*vec) as ccal, (sum((stoim/1000)*vec))*trud as cena from bluda left join sostav
	on bluda.bl=sostav.bl
	left join produkt on  sostav.pr=produkt.pr
	left join nalishie on nalishie.pr=produkt.pr
	group by bludo,trud
	
	select cm,COUNT(b) from vibor
	where (t=1 or t=2) and (b='З' or b='Г')
	group by cm
	select * from bluda
	
	select bludo from bluda right join menu
	on bluda.bl=menu.bl
	join sostav on bluda.bl=sostav.bl
	join produkt on sostav.pr=produkt.pr
	where t=1
	group by bludo
	having SUM(ziri+belki)<sum((b2+pp+c)*1000)
	
	select trapeza,count(distinct menu.b),count(menu.bl)from trapezi right join menu
	on trapezi.t=menu.t
	join bluda on bluda.bl=menu.bl
	where trud>2
	group by trapeza
	having count(menu.bl)>1

	select avg(cena),max(cena),min(cena),count(distinct pr),sum(kol),nazvanie from postavshiki left join postavki
	on postavshiki.pc=postavki.pc
	where gorod like 'Ленинград'
	group by nazvanie
	having count(pr)>2

	select bludo,count(product),min(str((kol_vo*1000)/vec,10,2)) as portzii from bluda left join sostav
	on bluda.bl=sostav.bl
	left join produkt on sostav.pr=produkt.pr
	left join nalishie on produkt.pr=nalishie.pr
	group by bludo
	
	select product,count(sostav.pr) from produkt right join sostav
	on produkt.pr=sostav.pr
	group by product
	
	--4-я лаба

	select max(colpr),min(colpr) from 
	(select bl,count(pr) as colpr from sostav 	group by bl) as svodka


	select product from produkt
	group by product,ziri
	having ziri>(select avg(ziri) from produkt)

	select nazvanie from postavshiki right join postavki as pos
	on postavshiki.pc=pos.pc
 	where pos.pr = any(select pro.pr from sostav as stv join Produkt as pro on pro.pr=stv.pr
	where stv.bl=18) and cena=(	select MIN(cena) from postavki where pr=pos.pr)
	
	select bluda.bludo,bluda2.bludo from bluda cross join bluda as bluda2 
	where bluda.kod_osnova=bluda2.kod_osnova and bluda.bludo!=bluda2.bludo

	select   postavshiki.nazvanie,  pos2.nazvanie from postavshiki cross join postavshiki as pos2
	where postavshiki.gorod=pos2.gorod and postavshiki.nazvanie!=pos2.nazvanie

	select  postavshiki.pc,nazvanie from postavshiki
	where  exists (select * from postavki join postavshiki on postavshiki.pc=postavki.pc  where nazvanie = 'ЛЕТО')  and  nazvanie != 'ЛЕТО'
	group by postavshiki.pc,nazvanie

	select status,nazvanie from postavshiki 
	where exists (select  * from postavshiki where nazvanie like 'СЫТНЫЙ') and nazvanie not like 'СЫТНЫЙ'
	--8-e

	select bludo from bluda 
	where kod_osnova in (select kod_osnova from osnova where osnova='Мясо')

	select bludo from bluda 
	where exists (select * from osnova where osnova='Мясо' and osnova.kod_osnova=bluda.kod_osnova)

	select bludo from bluda join osnova
	on osnova.kod_osnova=bluda.kod_osnova
	where osnova='Мясо'
	--9-e
	select nazvanie from postavshiki
	where pc in (select postavshiki.pc from postavshiki join postavki on postavshiki.pc=postavki.pc where pr=11)

	select nazvanie from postavshiki 
	where exists ( select * from postavki where pr=11 and  postavki.pc=postavshiki.pc) 

	select nazvanie from postavshiki join postavki
	on postavshiki.pc=postavki.pc
	where pr=11
	--10-e
	select nazvanie from postavshiki
	where pc  not in (select postavshiki.pc from postavshiki join postavki on postavshiki.pc=postavki.pc where pr=11)

	select nazvanie from postavshiki 
	where not exists ( select * from postavki where pr=11 and  postavki.pc=postavshiki.pc)
	--11-e
	select product from produkt
	where pr in (select pr  from postavki group by pr having count(pc)=1)

	select product from produkt
	where exists (select * from postavki where postavki.pr=produkt.pr group by pr having count(pc)=1)

	select produkt from produkt join postavki 
	on produkt.pr=postavki.pr
	group by produkt
	having count(pc)=1
	
	--12-e
	select bludo from bluda
	where bl in (select bl from sostav where pr=11)

	select bludo from bluda
	where exists (select * from sostav where pr=11 and sostav.bl=bluda.bl)

	select bludo from bluda join sostav
	on sostav.bl= bluda.bl
	where pr=11
	--13-e
	select bludo from bluda
	where bl in (select bl from sostav where pr in (select pr from postavki where pc=6))

	select bludo from bluda
	where exists (select * from sostav where sostav.bl=bluda.bl and exists (select * from postavki where postavki.pr=sostav.pr and pc=6))
	--14-e
	select distinct bludo from bluda cross join menu
	where bluda.bl=menu.bl

	select bludo from bluda 
	where bluda.bl in (select bl from menu)

	select bludo from bluda 
	where exists (select * from menu where menu.bl=bluda.bl)
	--15-e
	select bludo from bluda left join menu
	on bluda.bl=menu.bl
	where menu.bl is null

	select bludo from bluda 
	where bl not in (select bl from menu )
	
	select bludo from bluda 
	where not exists (select * from menu where menu.bl=bluda.bl)
	--16-e

	select trapeza,count(menu.t) as [kol-vo blud],count (myaso.kod_osnova) as [kol-vo myasnyh blud],count (ovoshi.kod_osnova) as [kol-vo ovoshnyh blud]from trapezi join menu
	on trapezi.t=menu.t
	join bluda on menu.bl=bluda.bl
	left join (select kod_osnova from osnova where osnova='Мясо') as myaso on bluda.kod_osnova=myaso.kod_osnova
	left join (select kod_osnova from osnova where osnova='Овощи') as ovoshi on bluda.kod_osnova=ovoshi.kod_osnova
	group by trapeza

	select nazvanie,(select isnull(sum(kol),0) from postavki where postavki.pc=postavshiki.pc and DATEPART(QUARTER,data)=1) as [1cvartal],
   (select isnull(sum(kol),0) from postavki where postavki.pc=postavshiki.pc and DATEPART(QUARTER,data)=2) as [2cvartal],
   (select isnull(sum(kol),0) from postavki where postavki.pc=postavshiki.pc and DATEPART(QUARTER,data)=3) as [3cvartal],
   (select isnull(sum(kol),0) from postavki where postavki.pc=postavshiki.pc and DATEPART(QUARTER,data)=4) as [4cvartal],
   (select isnull(sum(kol),0) from postavki where postavki.pc=postavshiki.pc) as vgod
	from postavshiki

	select bludo,sum((((belki+uglevod)/1000)*4.1+(ziri/1000)*9.3)*vec) as ccal, (min(trud/100)+sum(stoim*vec/(kol_vo*1000))) as cena from bluda join sostav
	on bluda.bl=sostav.bl
	join produkt on  sostav.pr=produkt.pr
	join  nalishie on nalishie.pr=produkt.pr
	join vid_blud on bluda.b=vid_blud.b
	where bluda.bl not in (select sostav.bl from sostav where sostav.pr in  ( select nalishie.pr from nalishie where nalishie.pr in (select pr from nalishie where kol_vo=0 or kol_vo is  null)))
	group by vid,bludo
	having sum((((belki+uglevod)/1000)*4.1+(ziri/1000)*9.3)*vec)  <= 400 and (min(trud/100)+sum(stoim*vec/(kol_vo*1000))) <=1.5
	order by vid,bludo

	--19-e
	select bludo from bluda right join menu
	on menu.bl=bluda.bl
	where bluda.kod_osnova in (select kod_osnova from osnova where osnova='Овощи') and t=1

	select bludo from bluda right join menu
	on menu.bl=bluda.bl
	where exists (select * from osnova where osnova='Овощи' and bluda.kod_osnova=osnova.kod_osnova ) and t=1
	--20-e
	select bludo,count(pr)  from bluda left join sostav 
	on bluda.bl=sostav.bl
	group by bludo
	union
	select product,count(bl)  from produkt left join sostav
	on produkt.pr=sostav.pr
	group by product
	
	select  product,nazvanie,cena,data from produkt  join postavki  
	on produkt.pr=postavki.pr 
	 join postavshiki on postavki.pc=postavshiki.pc
	where cena=(select min (cena) from postavki where produkt.pr=postavki.pr )

	select product, nazvanie,str(cena/kol,6,2) from produkt join postavki 
	on produkt.pr=postavki.pr 
	join postavshiki on postavki.pc=postavshiki.pc     
	where cena/kol=(select MIN(cena/kol) from postavki where produkt.pr=postavki.pr)

	--22-e
	select product, 
	case  
	when  (ziri=0 or ziri is null)   then  'нет жиров'  
	when  pr  in (select pr from sostav where bl  in 
	(select bl from bluda where bludo like 'Салат%' or bludo like 'Паштет%')) then ' входит в салаты или паштеты'
	else   NULL  
	end 
	from produkt  
	where (ziri=0 or ziri is null)  or  pr  in (select pr from sostav where bl  in 
	(select bl from bluda where bludo like 'Салат%' or bludo like 'Паштет%')) 

	select product,'нет жиров' from produkt 
	where ziri=0 or ziri is  null
	union
	select product,' входит в салаты или паштеты' from produkt 
	where	pr in 		(select pr from sostav 
	 join bluda on sostav.bl=bluda.bl
	where bludo like 'Салат%' or bludo='Паштет%')

	
	select product, 'не входит в салаты, паштеты' 
	from produkt 
	where  pr not in (select pr from sostav where bl  in 
	(select bl from bluda where bludo like '%Салат%' or bludo like '%Паштет%'))
	union
	select product, 'нет жиров' 
	from produkt 
	where (ziri=0 or ziri is null)



	
	
	
	
	
	select * from postavshiki
	/*select bludo ,nazvanie   from bluda,postavshiki 
	where not exists (select pr from sostav where sostav.bl=bluda.bl)
	and   in (select pr from postavki where pc=postavshiki.pc)
	*/
	select bludo ,nazvanie   from bluda,postavshiki
	where not exists 
	(select prp.pr from
		(select pr from bluda as b1 join sostav on b1.bl=sostav.bl
			where b1.bl=bluda.bl) as prb
				left join
		(select pr from postavki
			where postavki.pc=postavshiki.pc) as prp
			on prb.pr=prp.pr
			where prp.pr is null)

