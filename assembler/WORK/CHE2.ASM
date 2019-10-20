dosseg
.model small
.stack 100h
.data
mem_b1 db 'jizn strannaya shtuka'

.code
	mov ax,@data
	mov ds,ax

	push ds
	pop es

	cld

	lea di,mem_b1
a1:	lodsb
	cmp al,'i'
	jnz a1

	mov dl,al
	
	mov ah,02
	int 21h

	mov ah,4ch
	int 21h
end
