dosseg
.model small
.stack 100h
.data
info db 'Сравнить строки и вывести текст до несовпадения:',13,10,13,10,'$'
mes1 db 'derevo yabloko grusha lug pole'
mes2 db 'derevo yabloko grusha lug pore'
len equ $-mes2
.code
	mov ax,@data
	mov ds,ax
	
	
	cmp byte ptr es:[80h],0
	je beg

	cmp word ptr es:[82h],'h/'
	jne beg

;	cmp byte ptr es:[83h],'h'
;	jne beg

	mov ah,9
	lea dx,info
	int 21h

beg:
	push ds
	pop es

	cld
	mov cx,len
	lea si,mes1
	lea di,mes2
	repe cmpsb
	
	std
ckl:
	lodsb
	inc cx
	cmp al,' '
	jne ckl
	dec cx

	mov ax,len
	sub ax,cx
	xchg ax,cx

	push cx

	mov ah,40h
	mov bx,1
	pop cx
	lea dx,mes1
	int 21h


	mov ah,4ch
	int 21h
end
