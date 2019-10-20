dosseg
.model small
.stack 100h
.data
base10 db '1234'
base16 db 4 dup(0)
.code
	mov ax, @data
	mov ds, ax
	
;	mov ah, 3fh
;	mov bx, 0
;	mov cx, 6
;	lea dx, base10
;	int 21h
;	dec ax
;	dec ax
;	push ax
	
;	mov ah, 40h
;	mov bx, 0
;	pop cx
;	lea dx, base10
;	int 21h

	mov ax, 10	

	lea si, base10
	mov cx, 4
clear:
	mov al, [si]
	and al, 0Fh
	mov [si], al
	inc si
	dec cx
	jnz clear

	lea si, base10
	lea di, base16
;	mov 
	mov ax, word ptr [si]
	mov bl, 0Fh
	jmp st_

div_loop:
	mov [di], ah
	inc di
st_:
	div bl
	cmp al, 0
	jne div_loop
	mov [di], ah

	mov ah, 40h
	mov bx, 0
	mov cx, 4
	lea dx, base16
	int 21h


end_:	
	mov ah, 4ch
	int 21h
end