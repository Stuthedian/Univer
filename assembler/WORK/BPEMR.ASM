DOSSEG
.MODEL SMALL
.STACK 100h
.DATA
TimePrompt DB "����� ᥩ�� �६� ��⮪? (���/����/����/����) - [�/�/�/�] $"
GoodMorning DB 13,10,'���஥ ���!',13,10,'$'
GoodAfternoon DB 13,10,'����� ����!',13,10,'$'
GoodEvening DB 13,10,'����� ����!',13,10,'$'
GoodNight DB 13,10,'���ன ���!',13,10,'$'
SeasonPrompt DB "����� ᥩ�� �६� ����? (����/��᭠/���/�ᥭ�) - [�/�/�/�] $"
Winter DB '�� ������!',13,10,'$' 
Spring DB '�� �஬�����!',13,10,'$'
Summer DB '����� �ࠪ⨪�..',13,10,'$'
Autumn DB '���� ������..',13,10,'$'													
.CODE
Start:
	mov AX, @Data
	mov DS,AX

	mov AH, 9
	lea DX, TimePrompt
	int 21h
	
	mov AH, 01
	int 21H
	cmp AL, '�'
	jz IsMorning
	cmp AL, '�'
	jz IsMorning
	cmp AL, '�'
	jz IsAfternoon
	cmp AL, '�'
	jz IsAfternoon
	cmp AL, '�'
	jz IsEvening
	cmp AL, '�'
	jz IsEvening
	cmp AL, '�'
	jz IsNight
	cmp AL, '�'
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
	cmp AL, '�'
	jz IsWinter
	cmp AL, '�'
	jz IsWinter
	cmp AL, '�'
	jz IsSpring
	cmp AL, '�'
	jz IsSpring
	cmp AL, '�'
	jz IsSummer
	cmp AL, '�'
	jz IsSummer
	cmp AL, '�'
	jz IsAutumn
	cmp AL, '�'
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