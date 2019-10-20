dosseg
.model small
.stack 100h
.data
input_ db 4 dup(0)
x dw 0,0
.code
	mov ax, @data
	mov ds, ax

	mov ah, 3fh
	mov bx, 0
	mov cx, 4
	lea dx, input_
	int 21h
	mov ax, word ptr [input_ + 2]
	or ax, 3030h
	shr ah, 4
	shr ax, 4
	mov word ptr [x + 2], ax
	mov ax, word ptr [input_]
	or ax, 3030h
	shr ah, 4
	shr ax, 4
	mov word ptr [x], ax


	mov ah, 40h
	mov bx, 1
	mov cx, 4
	lea dx, input_
	int 21h

	mov ah, 4ch
	int 21h
end
