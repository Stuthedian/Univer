DOSSEG
.MODEL SMALL
.STACK 100h
.DATA
TimePrompt DB "[h]$"
Otvet1 DB 13,10,'Hello!',13,10,'$'
Error1 DB 13,10,'Неверный символ',13,10,'$'
.CODE
	mov ax,@Data
	mov ds,ax

	mov ah,9
	lea dx,TimePrompt
	int 21h

	mov ah,01
	int 21h

	cmp al,'?'
	jz IsOtvet1

	jmp IsEr1
IsOtvet1:
	lea dx,Otvet1
	jmp DisplayGreeting
IsEr1:
	lea dx,Error1
DisplayGreeting:
	mov ah,9
	int 21h
	mov ah,4ch
	int 21h
END