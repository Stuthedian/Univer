dosseg
.model small
.stack 100h
.data
maxlen EQU 100
table db 30h dup(0), 'abcdefghij',7 dup(0),'klmnopqrstuvwxyzABCDEFGHIJ',6 dup(0),'KLMNOPQRSTUVWXYZ0123456789-=_+!@#$%^&*()/\|><'
str_ db maxlen dup(0)
.code
prn macro cim
	push ax
	mov ah,2
	mov dl,cim
	int 21h
	pop ax
endm
	
	mov ax,@data
	mov ds,ax
	
	mov ah,3fh
	mov bx,0
	mov cx,maxlen
	lea dx,str_
	int 21h

	mov cx,ax
	dec cx
	dec cx
	push cx

	lea bx,table
	pop cx
	lea si,str_

loop_:
	mov al,[si]
	xlat

	;prn [si]
	;prn '='
	prn al

	inc si
	dec cx
	jnz loop_

	prn 13
	prn 10


	mov ah,4ch
	int 21h
	
end
