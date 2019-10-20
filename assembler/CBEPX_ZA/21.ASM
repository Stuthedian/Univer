dosseg 
.model small
.stack 100h
.data
buf1 db 1024 dup (0)
buf2 db 1024 dup (0)
maska_ db '*.asm',0
dta db 80h dup(0)
path db 'clear.cpp',0
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
	mov bx, handle
	mov cx, 1024
	lea dx, buf1
	int 21h
	
	mov cx, ax
	push cx
	mov ah, 3fh
	mov bx, handle
	lea dx, buf1
	int 21h
	
	lea si, buf1
	lea di, buf2
_loop:
	mov al, [si]
	cmp al, '/'
	jne inc_lp
	inc si
	mov al, [si]
	cmp al, '/'
	jne inc_lp2
	jmp nl
	
inc_lp:
	mov [di], al
	inc di
	inc si
	dec cx
	jnz _loop
	jmp end_
inc_lp2:
	dec si
	mov al, [si]
	mov [di], al
	inc di
	inc si
	mov al, [si]
	mov [di], al
	inc di
	inc si
	dec cx
	jnz _loop 	
	jmp end_
nl:
	inc si
	dec cx
	jz end_
	mov al, [si]
	cmp al, 10
	jne nl
	inc si
	dec cx
	jz end_
	jmp _loop

end_:
	mov ah, 3eh
	lea bx, handle
	int 21h

	lea dx, buf2
	sub di, dx

	mov ah, 3ch
	mov cx, 00
	lea dx, path
	int 21h
	mov handle, ax
	

	mov ah, 40h
	mov bx, handle
	mov cx, di
	lea dx, buf2
	int 21h

	mov ah, 3eh
	lea bx, handle
	int 21h

	mov ah, 4ch
	int 21h
end
	mov ah, 1ah
	lea dx, dta
	int 21h

	mov ah, 4eh
	mov cx, 00
	lea dx, maska_
	int 21h
	jc error
	mov [filesize], ax
	lea si, [dta+1eh]
	lea di, filename
	mov cx, 13
	rep movsb
skip:
	mov ah, 4fh
	lea dx, dta
	int 21h
	jc error

	mov ah, 02h
	mov dl, 13
	int 21h

	mov ah, 02h
	mov dl, 10
	int 21h
ÿ