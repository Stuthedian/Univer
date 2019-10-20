dosseg
.model small
.stack 100h
.data
maska_ db '*.asm',0
dta db 80h dup(0)
.code
.386

printn macro sym 
local ik,ir,ek,er 
	mov ah,02h
	mov dl,sym
	push dx
	shr dl,4
	cmp dl,9
	jg ik
	add dl,30h
	int 21h
	jmp ir
ik:
	add dl,37h
	int 21h
ir:
;	mov dl,sym
	pop dx
	and dl,0fh
	cmp dl,9
	jg ek
	add dl,30h
	int 21h
	jmp er
ek:
	add dl,37h
	int 21h
er:
endm

	mov ax, @data
	mov ds, ax

	mov ah, 1ah
	lea dx, dta
	int 21h

	mov ah, 4eh
	mov cx, 00
	lea dx, maska_
	int 21h
	jc error

info:	
	mov ah, 40h
	mov bx, 0
	mov cx, 13
	lea dx, [dta+1eh]
	int 21h

	mov ah, 02h
	mov dl, 9
	int 21h

	mov al, byte ptr [dta + 15h]
	printn al

	mov ah, 02h
	mov dl, 'h'
	int 21h
	
	mov ah, 4fh
	lea dx, dta
	int 21h
	jc error

	mov ah, 02h
	mov dl, 13
	int 21h

	mov ah, 02h
	mov dl, 10
	int 21h

	jmp info
	

error:
	mov ah, 4ch
	int 21h
end
