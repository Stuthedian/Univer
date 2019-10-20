DOSSEG
.MODEL SMALL
.STACK 100h
.DATA
	Message DB 'Hello!!!',13,10,'/h'
	Mes_Length EQU $ - Message
.CODE
	mov ax,@Data
	mov ds, ax

	mov ah, 40h
	mov bx, 1
	mov cx, Mes_Length
	lea dx, Message
	int 21h

	mov ah, 4ch
	int 21h
END