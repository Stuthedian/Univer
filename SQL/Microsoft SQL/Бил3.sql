use pansion2k17

--1)
select bludo from bluda
where vihod >= 
	(select avg(vihod) from bluda  join osnova
	on bluda.kod_osnova=osnova.kod_osnova
	where osnova = 'Молоко')


--2)

select distinct nazvanie from postavshiki join postavki
on postavshiki.pc=postavki.pc
where pr = any (select pr from sostav  join bluda on sostav.bl=bluda.bl where bludo='Творог')

--3)

create procedure greaterthen
@vid varchar(10),
@bludo varchar(50)
as
if (not exists (select * from bluda where bludo=@bludo) or not exists (select * from vid_blud where vid=@vid))
	print 'Ошибка'
else
	select bludo from bluda join vid_blud
	on bluda.b=vid_blud.b
	where trud > (select trud from bluda where bludo=@bludo) and vid=@vid
	
	
execute greaterthen Суп, [Уха из судака]