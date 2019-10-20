dosseg
.model small
.stack 100h
.data
len equ 50
op1 db len dup (0)
len1 db 0
op2 db len dup (0)
;len2 db 0
rzlt db len dup (0)
.code
	mov ax,@data
	mov ds,ax

	mov ah,3fh
	mov bx,0
	mov cx,len
	lea dx,op1
	int 21h
	sub ax,2
	mov len1,al

	mov ah,3fh
	mov bx,0
	mov cx,len
	lea dx,op2
	int 21h
;	sub ax,2
;	mov len2,al

	mov ah,0
	mov al,len1
	dec ax
	mov ch,0
	mov cl,len1
	lea si,op1
	lea di,op2
	lea bx,rzlt
	add si,ax
	add di,ax
	add bx,ax
	clc
	pushf 
ckl:
	mov ah,[si]
	mov al,[di]
	and ah,0fh
	and al,0fh
	popf
	sbb ah,al
	pushf
	aas
	or ah,30h
	mov [bx],ah
	dec si
	dec di
	dec bx
	dec cx
	jnz ckl

	mov ah,40h
	mov bx,0
	mov ch,0
	mov cl,len1
	lea dx,rzlt
	int 21h

	mov ah,4ch
	int 21h
end
