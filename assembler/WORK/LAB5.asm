dosseg
.model small
.stack 100h
.data
len EQU 100
leng db len dup(0)
.code
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

	mov ah,3fh
	mov bx,0
	mov cx,len
	lea dx,leng
	int 21h
	sub ax,2
	mov cx,ax

	cld
	mov bx,0

	lea di,leng
	push ds
	pop es

ckl:
	mov al,' '
	repne scasb
	inc bx
	cmp cx,0
	je done
	dec di

ckl2:
	inc di
	mov al,' '
	cmp [di],al
	je ckl2
	jmp ckl

	
done:
	prn bh
	prn bl
	mov ah,4ch
	int 21h
end
