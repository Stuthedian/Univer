dosseg
.model small
.stack 100h
.data
sb  db '024603'
sb1 db '708671'
sb2 db 7 dup(0)
.code
	mov ax,@data
	mov ds,ax

	lea si,sb1
	lea di,sb
	lea bx,sb2
	add si,5
	add di,5
	add bx,6
	clc

ckl:
	mov al,[si]
	and al,0fh
	mov cl,[di]
	and cl,0fh
	sbb al,cl
	aas
	or  al,30h
	mov [bx],al
	dec bx
	dec si
	dec di
	jnz  ckl

	mov ah,4ch
	int 21h
end