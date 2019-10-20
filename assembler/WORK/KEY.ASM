dosseg
.model small
.stack 100h
.data
.code
	mov ax,@data
	mov ds,ax

	mov al,00000111b
	push ax

	mov al,0edh
	out 60h,al

	pop ax
	out 60h,al
	

	mov ah,4ch
	int 21h
end