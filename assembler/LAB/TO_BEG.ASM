dosseg
.model small
.stack 100h
.data
path db 'text.txt',0
path1 db 'te.txt',0
handle dw 0 
buf db 100 dup (0)
.code
	mov ax, @data
	mov ds, ax

	mov ah, 3dh
	mov al, 0
	lea dx, path1
	int 21h
	mov handle, ax

	mov ah, 3fh
	mov bx, handle
	mov cx, 100
	lea dx, buf
	int 21h
	push ax

	mov ah, 3eh
	mov bx, handle
	int 21h

	mov ah, 3dh
	mov al, 1
	lea dx, path
	int 21h
	mov handle, ax

	mov ah, 42h
	mov al, 0
	mov bx, handle
	mov cx, 0
	mov dx, 0
	int 21h

	mov ah, 40h
	mov bx, handle
	pop cx
	lea dx, buf
	int 21h

	mov ah, 3eh
	mov bx, handle
	int 21h

	mov ah, 4ch
	int 21h
end
