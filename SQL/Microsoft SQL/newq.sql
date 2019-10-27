use pansion2k17

--1

select * into #VREM_POST
from postavki

select * from #VREM_POST 

/*update #VREM_POST  set cena=0, kol=0 where (select gorod from #VREM_POST as s join postavshiki on postavshiki.pc=s.pc 
												group by s.pc,gorod) in ('Паневежис','Резекне'
*/

UPDATE #VREM_POST
set kol=0, cena=0
where pc=(select pc from postavshiki where gorod like 'Паневежис')
or pc=(select pc from postavshiki where gorod like 'Резекне')

update #VREM_POST set cena=cena*3 where pr in (select pr from produkt where product!='Кофе')

delete from #VREM_POST where (select COUNT(gorod) from #VREM_POST join postavshiki on #VREM_POST.pc=postavshiki.pc group by gorod) >  5

delete from #VREM_POST where pr in (select produkt.pr from produkt left join sostav on produkt.pr=sostav.pr where sostav.pr is null) 

select * from vibor
--2
	select vid,bludo,sum((((belki+uglevod)/1000)*4.1+(ziri/1000)*9.3)*vec) as ccal, (sum((stoim/1000)*vec))*trud as cena into #V_MENU from bluda left join sostav
	on bluda.bl=sostav.bl
	left join produkt on  sostav.pr=produkt.pr
	left join nalishie on nalishie.pr=produkt.pr
	left join vid_blud on vid_blud.b=bluda.b
	group by bludo,vid,trud
	
	--3
	create view DOP_BLUD
	as
	select bluda.bl, bludo, osnova, vid, vihod, sum((((belki+uglevod)/1000)*4.1+(ziri/1000)*9.3)*vec) as ccal, min((kol_vo*1000)/vec) as portzii  from bluda
	left join osnova on osnova.kod_osnova=bluda.kod_osnova
	left join vid_blud on vid_blud.b=bluda.b
	left join sostav on bluda.bl=sostav.bl
	left join produkt on  sostav.pr=produkt.pr
	left join nalishie on nalishie.pr=produkt.pr
	group by bluda.bl, bludo, osnova, vid, vihod
	
	create view MYAS_BLUD 
	as 
	select bl, bludo, vid, vihod from DOP_BLUD where osnova='Мясо' and ccal>200 and portzii>=9.0
	
	drop view MYAS_BLUD
	
	select * from MYAS_BLUD 
	
	
	
	
	
	
	--4
	
	
	create function ccal_blud (@cod_blud int)
	returns int
	as  
	begin 
	declare @ccal_blud int
	select @ccal_blud = (sum((((belki+uglevod)/1000)*4.1+(ziri/1000)*9.3)*vec)) from bluda
	left join sostav on bluda.bl=sostav.bl
	left join produkt on  sostav.pr=produkt.pr
	where bluda.bl=@cod_blud
	group by bluda.bl
	return @ccal_blud 
	end
	 
	select dbo.ccal_blud (bl) as ccal from bluda 
	where bludo like '%[С,с]алат%'
	select * from bluda
	
	
	
	
	
	alter function stoimostb (@cod_blud int)
	returns int
	as  
	begin 
	declare @ccal_blud int
	select @ccal_blud = (sum((stoim/1000)*vec))*trud from bluda
	join sostav on bluda.bl=sostav.bl
	join nalishie on  sostav.pr=nalishie.pr
	where bluda.bl=@cod_blud  
	group by trud
	return @ccal_blud 
	end

	
	select dbo.stoimostb (bl) as stoimost from bluda 
	where bludo like '%[С,с]алат%'
	
	--5
	
	
	create function kol_prod (@nazvanie varchar (50))
	returns int
	as
	begin
	declare @kol int
	select @kol = count(pr) from bluda 
	join sostav on bluda.bl=sostav.bl
	where bludo=@nazvanie
	return @kol
	end
	
	select dbo.kol_prod (bludo) from bluda
	
	
	--6
	
	alter function raznost (@prod_nazv varchar (50))
	returns int
	as
	begin
	declare @dif int
	select @dif = SUM(kol) - kol_vo from produkt
	join nalishie on nalishie.pr=produkt.pr
	join [pansion2k17].[dbo].[postavki] on postavki.pr=produkt.pr
	where product=@prod_nazv
	group by produkt.pr,kol_vo
	return @dif
	end
	
	select dbo.raznost(product) from produkt
	
	--7
	
	alter function withoutprod(@prod_nazv varchar (50))
	returns table
	as
	return
	select bludo from bluda 
	where bl not in 
	(select bluda.bl from bluda join sostav on sostav.bl=bluda.bl
	join produkt on produkt.pr=sostav.pr where product=@prod_nazv )
	
	select * from dbo.withoutprod('Лук')
	
	--8
	
	create function spisok_blud ()
	returns table
	as
	return
	select bludo from bluda
	inner join sostav on sostav.bl=bluda.bl
	group by sostav.bl, bludo, vihod
	having vihod > SUM(vec)
	
	select * from dbo.spisok_blud ()
	
	--9
	
	create function CBEPX_bludo (@bludniy varchar (50))
	returns varchar (50)
	as
	begin 
	declare @postvshik varchar (50)
    select @postvshik =(select nazvanie   from bluda,postavshiki
	where not exists 
	(select prp.pr from
		(select pr from bluda as b1 join sostav on b1.bl=sostav.bl
			where b1.bl=bluda.bl) as prb
				left join
		(select pr from postavki
			where postavki.pc=postavshiki.pc) as prp
			on prb.pr=prp.pr
			where prp.pr is null) and bludo=@bludniy)
	return @postvshik
	end

select bludo, dbo.CBEPX_bludo (bludo) from bluda 
where dbo.CBEPX_bludo (bludo) is not NULL


--10

	create procedure CBEPX_postavshik 
	as 
	select postavshiki.nazvanie from postavshiki
	where (select COUNT(pc) from postavshiki as sp where sp.gorod = postavshiki.gorod) > 1
	
	execute CBEPX_postavshik

--11


	alter procedure CBEPX_produkt 
	@nam_prod varchar(50)
	as
	if exists (select product from produkt
	where product=@nam_prod)
	
	select bludo from bluda 
	join sostav
	on sostav.bl=bluda.bl
	join produkt
	on produkt.pr=sostav.pr
	where product=@nam_prod 
	else print 'Продукт отсутствует. Беда.'
	
	execute CBEPX_produkt 'Мазик'
	
	--12
	
	create procedure same_post 
	@nazv_post varchar(50)
	as
	select nazvanie from postavshiki as p
	join postavki 
	on postavki.pc=p.pc
	group by nazvanie, p.pc
	having (select pr from postavshiki
	join postavki 
	on postavki.pc=postavshiki.pc
	where postavshiki.pc=p.pc) = all(select pr from postavshiki
										join postavki 
										on postavki.pc=postavshiki.pc
										where postavshiki.nazvanie=@nazv_post)
	
	
	EXECUTE same_post 'ТУЛЬСКИЙ'
	
	
	
	
	
	--13
	
	create function kol_prod_post (@nazvanie varchar(50))
	returns table 
	as
	return 
	select nazvanie from postavshiki as p
	group by nazvanie
	having (select COUNT (pr) from postavshiki 
	join postavki
	on postavki.pc=postavshiki.pc
	where postavshiki.nazvanie=p.nazvanie)
	=(select COUNT (pr) from postavshiki 
	join postavki
	on postavki.pc=postavshiki.pc
	where postavshiki.nazvanie=@nazvanie)
	
	select * from dbo.kol_prod_post ('ПОРТОС')
	select * from postavshiki