dosseg
.model small
.stack 100h
.data
sl1 db 01h,08h,46h;10846
sl2 db 09h,83h,42h;98342
rzlt db 4 dup (0)
.code
	mov ax,@data
	mov ds,ax

	lea si,sl1+2
	lea di,sl2+2
	lea bx,rzlt+3
	mov cx,3
	clc
	pushf
ckl:
	mov al,[si]
	popf
	adc al,[di]
	daa
	pushf
	mov [bx],al
	dec si
	dec di
	dec bx
	dec cx
	jnz ckl

	mov si,5
	lea bx,rzlt

ckl2:
	mov cl,[bx]
	mov ch,[bx]
	and cl,000fh
	and ch,00f0h
	dec si
	jz done
	inc bx
	cmp ch,0
	je ckl2
	shr ch,4
	or ch,30h
	or cl,30h
	mov ah,02
	mov dl,ch
	int 21h
	mov ah,02
	mov dl,cl
	int 21h
	jmp ckl2

done:
	mov ah,4ch
	int 21h
end