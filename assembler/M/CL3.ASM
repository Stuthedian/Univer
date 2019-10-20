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
	push ax
	and al, 0f0h
	shr al, 4
	cmp al, 10
	sbb al, 69h
	das
	mov ah, 02
	mov dl, al
	int 21h
	pop ax
	and al, 0fh
	cmp al, 10
	sbb al, 69h
	das
	mov ah, 02
	mov dl, al
	int 21h
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
	push ax
	and al, 0f0h
	shr al, 4
	cmp al, 10
	sbb al, 69h
	das
	mov ah, 02
	mov dl, al
	int 21h
	pop ax
	and al, 0fh
	cmp al, 10
	sbb al, 69h
	das
	mov ah, 02
	mov dl, al
	int 21h
	mov ah, 02
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