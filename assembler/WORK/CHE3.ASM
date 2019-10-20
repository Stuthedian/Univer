dosseg
.model small
.stack 100h
.data
mem_b1 db '1112345672'
mem_b2 db '1114345454'

.code
	mov ax,@data
	mov ds,ax

	push ds
	pop es

	cld

	mov cx,10
	lea si,mem_b1
	lea di,mem_b2
	repe cmpsb


	mov dl,[si-1]
	mov ah,02
	int 21h

	mov dl,[di-1]
	mov ah,02
	int 21h


	mov ah,4ch
	int 21h
end
