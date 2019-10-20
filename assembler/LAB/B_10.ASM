dosseg
.model small
.stack 100h
.data
base10 db 10 dup(0)
;base16 db 4 dup(0)
mult_ dw 10
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
	
	mov ah, 3fh
	mov bx, 0
	mov cx, 10
	lea dx, base10
	int 21h
	dec ax
	dec ax
	push ax
	
	mov cx, ax
	lea si, base10
	add si, cx
	dec si
clear:
	mov al, [si]
	and al, 0Fh
	mov [si], al
	dec si
	dec cx
	jnz clear
;	base10: 0605050305
	
	mov di, 0; accumulator
	mov bx, 1;multiplier/1,10,100,1000
	pop ax
	mov cx, ax
	lea si, base10
	add si, cx
	dec si
to_reg:
	mov ax, 0
	mov al, [si]
	mul bx
	add di, ax
	mov ax, bx
	mul mult_
	mov bx, ax
	dec si
	dec cx
	jnz to_reg
	
	mov cx, di
	push cx
	push cx
	printn ch
	pop cx
	printn cl

	mov ah, 2
	mov dl, 13
	int 21h
	mov ah, 2
	mov dl, 10
	int 21h

	mov cx, 16
	pop bx 
b2_prn:
	shl bx, 1
	jnc zero_
	mov ah, 2
	mov dl, '1'
	int 21h
	jmp lg	
zero_:
	mov ah, 2
	mov dl, '0'
	int 21h
lg:
	dec cx
	jnz b2_prn
;	mov ah, 40h
;	mov bx, 0
;	mov cx, 4
;	lea dx, base16
;	int 21h


end_:	
	mov ah, 4ch
	int 21h
end
ÿ