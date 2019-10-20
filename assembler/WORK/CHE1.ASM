dosseg
.model small
.stack 100h
.data
mem_b1 db 10 dup('*')

.code
	mov ax,@data
	mov ds,ax

	push ds
	pop es

	cld

	lea di,mem_b1
	mov cx,05
	mov ax,1448h
	rep stosw

	mov ah,40h
	mov bx,1
	lea dx,mem_b1
	mov cx,10
	int 21h
	
	mov ah,4ch
	int 21h
end
