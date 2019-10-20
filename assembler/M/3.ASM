dosseg
.model small
.stack 100h
.data
massiv db 1Ch, 0DFh, 3Bh, 0A3h
.code
prn macro sym

	or sym, 30h
	mov ah, 2
	mov dl, sym
	int 21h 
endm
	mov ax, @data
	mov ds, ax

	lea si, massiv
ckl:
	mov ah, 0
	mov al, [si]
	push ax
	mov bl, 100
	div bx; ax:bx
	pop cx
	sub cx, ax
	cmp ax, 0
	jmp _2
	mov bl, al
	prn bl
_2:
	mov ax, cx
	mov bl, 10
	div bx; ax:bx
	cmp ax, 0
	jmp _3
	mov bl, al
	prn bl
_3:
	mov ax, cx
	mov bl, 10
	div bl;
	mov bl, ah
	prn bl

	mov ah, 4ch
	int 21h
end
