dosseg
.model small
.stack 100h
.data
path db 're.txt',0
line_ db 'Строка. Возможно 6-ая', 13, 10
len equ $ - line_
handle dw 0
mes db 'Не удалось создать файл!','$'
buf db 200 dup (0)
.code
	mov ax, @data
	mov ds, ax

	mov ah, 3ch
	mov cx, 00
	lea dx, path
	int 21h
	jc err_
	mov handle, ax
	
	mov cx, 6
cycle:
	push cx

	mov ah, 40h
	mov bx, handle
	mov cx, len
	lea dx, line_
	int 21h
	pop cx
	dec cx
	jnz cycle

	mov ah, 42h
	mov al, 0
	mov bx, handle
	mov cx, 0
	mov dx, 0
	int 21h

	mov ah, 3fh
	mov bx, handle
	mov cx, 200
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
	jmp exit
err_:
	mov ah, 9
	lea dx, mes
	int 21h
exit:
	mov ah, 4ch
	int 21h
end