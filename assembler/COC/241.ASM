dosseg
.model small
.stack 100h
.data
vch1 db 0,'024603'
vch2 db 0,'708671'
rzlt db 7 dup(0)
.code
	mov ax,@data
	mov ds,ax

	lea si,vch2
	lea di,vch1
	lea bx,rzlt
	add si,6
	add di,6
	add bx,6
	clc
	pushf

drd:

	mov al,[si]
	mov cl,[di]
	and al,0fh	
	and cl,0fh
	popf
	sbb al,cl
	aas
	pushf
	or al,30h
	mov [bx],al
	dec bx
	dec si
	dec di
	jnz drd		
	popf
	mov al,2dh
	mov [bx],al
	lea si,rzlt
	mov cx,8
ckl:
	mov bl,[si]
	inc si
	dec cx
	jz done	
	cmp bl,0
	jz ckl
	mov ah,02h
	mov dl,bl
	int 21h
	jmp ckl	

done:
	mov ah,4ch
	int 21h

end