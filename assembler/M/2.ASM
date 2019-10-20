dosseg
.model small
.stack 100h
.data
.code
.386
prn macro sym 
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
	pop dx	
;	mov dl,sym
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
prn_nl macro 
	mov ah, 2
	mov dl, 13
	int 21h
	mov ah, 2
	mov dl, 10
	int 21h
endm
	mov ax, @data
	mov ds, ax

	mov cx, 10
	mov bh, 0 
	mov bl, -10
	push bx
	jmp beg
ckl:
	pop bx
	inc bx

	push bx
beg:
	mov al, bl

	imul bl
	add al, 3
	mov bl, 4
	div bl
	prn al
	prn_nl
	dec cx
	jnz ckl

;	pop bx
	mov cx, 11
	mov bh, 0 
	mov bl, 0
	push bx
	jmp beg_
ckl_:
	pop bx
	inc bx
	push bx
beg_:
	mov al, 8
	mul bl
	add al, 5
	prn al
	prn_nl
	dec cx
	jnz ckl_
	mov ah, 4ch
	int 21h
end
ÿ