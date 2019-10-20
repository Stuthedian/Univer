DOSSEG
.MODEL SMALL
.STACK 100h
.DATA
Message DB 'hi!',13,10
	DB 'some information',13,10
	DB 'bullshit',13,10
	DB 'piece of trash',13,10,'$'
Dlina EQU ($-Message)-1
.CODE
	mov ax, @Data
	mov ds, ax

	mov ah, 40h
	mov bx, 1
	mov cx, Dlina
	lea dx, Message
	int 21h
	
	mov ah, 4ch
	int 21h
END
