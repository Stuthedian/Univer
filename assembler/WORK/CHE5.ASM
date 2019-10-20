 dosseg
.model small
.stack 100h
.data
mem_b1 db 'jasperdy tryn',13,10
leng EQU $ - mem_b1 

.code
	mov ax,@data
	mov ds,ax

	push ds
	pop es

	cld

	mov al,' '
	lea di,mem_b1
	mov cx,leng
	repne scasb


	mov dl,[di]
	mov ah,02
	int 21h

	mov ah,4ch
	int 21h
end
