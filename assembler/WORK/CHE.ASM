dosseg
.model small
.stack 100h
.data
mem_b1 db 10 dup('*')
mem_b2 db 10 dup(' ')

.code
	mov ax,@data
	mov ds,ax

	push ds
	pop es

	cld

	mov cx,10
	lea di,mem_b2
	lea si,mem_b1
	rep movsb

	mov ah,40h
	mov bx,1
	lea dx,mem_b2
	mov cx,10
	int 21h
	
	mov ah,4ch
	int 21h
end
