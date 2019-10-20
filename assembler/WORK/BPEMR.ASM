DOSSEG
.MODEL SMALL
.STACK 100h
.DATA
TimePrompt DB "Какое сейчас время суток? (Утро/День/Вечер/Ночь) - [У/Д/В/Н] $"
GoodMorning DB 13,10,'Доброе утро!',13,10,'$'
GoodAfternoon DB 13,10,'Добрый день!',13,10,'$'
GoodEvening DB 13,10,'Добрый вечер!',13,10,'$'
GoodNight DB 13,10,'Доброй ночи!',13,10,'$'
SeasonPrompt DB "Какое сейчас время года? (Зима/Весна/Лето/Осень) - [З/В/Л/О] $"
Winter DB 'Не болейте!',13,10,'$' 
Spring DB 'Не промокните!',13,10,'$'
Summer DB 'Летняя практика..',13,10,'$'
Autumn DB 'Зима близко..',13,10,'$'													
.CODE
Start:
	mov AX, @Data
	mov DS,AX

	mov AH, 9
	lea DX, TimePrompt
	int 21h
	
	mov AH, 01
	int 21H
	cmp AL, 'У'
	jz IsMorning
	cmp AL, 'у'
	jz IsMorning
	cmp AL, 'Д'
	jz IsAfternoon
	cmp AL, 'д'
	jz IsAfternoon
	cmp AL, 'В'
	jz IsEvening
	cmp AL, 'в'
	jz IsEvening
	cmp AL, 'Н'
	jz IsNight
	cmp AL, 'н'
	jz IsNight
jmp Start

IsMorning:
	lea DX, GoodMorning
	jmp DisplayGreeting
IsAfternoon:
	lea DX, GoodAfternoon
	jmp DisplayGreeting
IsEvening:
	lea DX, GoodEvening
	jmp, DisplayGreeting
IsNight:
	lea DX, GoodNight
	jmp DisplayGreeting

	mov AH, 9
	lea DX, SeasonPrompt
	int 21h

	mov AH, 01
	int 21H
	cmp AL, 'З'
	jz IsWinter
	cmp AL, 'з'
	jz IsWinter
	cmp AL, 'В'
	jz IsSpring
	cmp AL, 'в'
	jz IsSpring
	cmp AL, 'Л'
	jz IsSummer
	cmp AL, 'л'
	jz IsSummer
	cmp AL, 'О'
	jz IsAutumn
	cmp AL, 'о'
	jz IsAutumn

IsWinter:
	lea DX, Winter
	jmp DisplayGreeting
IsSpring:
	lea DX, Spring
	jmp DisplayGreeting
IsSummer:
	lea DX, Summer
	jmp DisplayGreeting
IsAutumn:
	lea DX, Autumn

DisplayGreeting:
	mov ah, 9
	int 21h

	mov AH, 4ch
	int 21h
END