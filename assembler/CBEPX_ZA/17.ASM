dosseg
.model small
.stack 100h
.data
path db 'file.asm',0
handle dw 0
.code
	mov ax, @data
	mov ds, ax

	mov ah, 43h
	mov al, 1
	mov cx, 02
	lea dx, path
	int 21h

	mov ah, 4ch
	int 21h
end
