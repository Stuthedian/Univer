create procedure rez_
as
select kt, 
(select count(lombard.kt)from lombard where year(ds) = 2015 and lombard.kt = kat_tov.kt) as in_2015,
(select count(lombard.kt)from lombard where year(ds) = 2016 and lombard.kt = kat_tov.kt) as in_2016 
into rez from kat_tov

create trigger to_rez
on lombard
after insert,update,delete
as
begin
	declare @row int = @@rowcount
	if @row=0 return
	if @row=1
		begin
		declare @ds datetime, @kt int
		if exists (select * from inserted)
			begin
			select @ds = (select ds from inserted)
			select @kt = (select kt from inserted)
				if year(ds) = 2015
				update rez set in_2015 + 1 where kt=@kt
				if year(ds) = 2016
				update rez set in_2016 + 1 where kt=@kt
			end
		if exists (select * from deleted)
			begin
			select @ds = (select ds from deleted)
			select @kt = (select kt from deleted)
				if year(ds) = 2015
				update rez set in_2015 - 1 where kt=@kt
				if year(ds) = 2016
				update rez set in_2016 - 1 where kt=@kt
			end
		end
	else
		begin
		rollback transaction
		print 'Не более одной записи в insert, update, delete за раз'
		return
		end
end

create trigger new_kt
on kat_tov
after insert,update
as
begin
	declare @row int = @@rowcount
	if @row=0 return
	if @row=1
		begin
		declare @kt int
		if exists (select * from inserted)
			begin
			select @kt = (select kt from inserted)
			if @kt not in (select kt from rez)
				begin 
				insert into rez
				values
				(@kt,0,0)
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