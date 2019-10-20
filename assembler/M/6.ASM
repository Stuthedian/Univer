dosseg
.model small
.stack 100h
.data
_ch db '378'
.code
.386
prn macro sym 
local ik,ir,ek,er 
	mov ah,02h
	mov dl,sym
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
	mov dl,sym
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
	mov ax,@data
	mov ds,ax

	lea si,_ch
	mov ah,0
	mov al,100
	mov bl,10
	mov dx,0
	mov cx,4
ckl:
	mov bh,[si]
	and bh,0fh
	push ax
	mul bh
	add dx,ax
	pop ax
	inc si
	div bl
	dec cx
	jnz ckl

	mov cx,dx
	prn ch
	prn cl


	mov ah,4ch
	int 21h
end

