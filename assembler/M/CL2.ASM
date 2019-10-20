dosseg
.model small
.stack 100h
.data
digit db -10
.code
.386
	jmp start
positive proc near
	mov al, 3
	mul bl
	add al, 5
	mov ah,02h
	mov dl,al
	push dx
	shr dl,4
	cmp dl,9
	jg ik
	add dl,30h
	int 21h
	jmp ir
ik:
	add dl,37h
	int 21h
ir:
	pop dx	
	and dl,0fh
	cmp dl,9
	jg ek
	add dl,30h
	int 21h
	jmp er
ek:
	add dl,37h
	int 21h
er:
	mov ah, 2
	mov dl, 13
	int 21h
	mov ah, 2
	mov dl, 10
	int 21h
	ret
endp
negative proc near
	mov al, bl
	imul bl
	add al, 4
	mov bl, 2
	div bl
	mov ah,02h
	mov dl,al
	push dx
	shr dl,4
	cmp dl,9
	jg ik_
	add dl,30h
	int 21h
	jmp ir_
ik_:
	add dl,37h
	int 21h
ir_:
	pop dx	
	and dl,0fh
	cmp dl,9
	jg ek_
	add dl,30h
	int 21h
	jmp er_
ek_:
	add dl,37h
	int 21h
er_:
	mov ah, 2
	mov dl, 13
	int 21h
	mov ah, 2
	mov dl, 10
	int 21h
	ret
endp


start:
	mov ax, @data
	mov ds, ax

	mov cx, 21
begin:
	mov bl, digit
	cmp bl, 0
	jl neg_
	call positive
	jmp ckl
neg_:
	call negative
ckl:
	inc digit
	dec cx
	jnz begin

	mov ah, 4ch
	int 21h
end