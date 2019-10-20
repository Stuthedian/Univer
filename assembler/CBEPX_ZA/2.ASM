dosseg
.model small
.stack 100h
.data
buf db 128 dup(0)
path db 'za_warudo.txt',0
handle dw 0
.code
	mov ax, @data
	mov ds, ax

	mov ah, 3dh
	mov al, 00
	lea dx, path
	int 21h
	mov handle, ax

	mov ah, 3fh
	mov cx, 128
	mov bx, handle
	lea dx, buf
	int 21h
	push ax

	mov ah, 40h
	mov bx, 0
	pop cx
	lea dx, buf
	int 21h

	mov ah, 3eh
	mov bx, handle
	int 21h

	mov ah, 4ch
	int 21h
end