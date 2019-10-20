dosseg
.model small
.stack 100h
.data
max_len EQU 100
tabl db 'ABCDEFGHIKLMOPQRSTUVWXYZtytytytytythdjretunvpoazr'
str_ db max_len dup(0)
.code
	mov ax,@data
	mov ds,ax

	mov ah,3fh
	mov bx,0
	mov cx,2
	lea dx,str_
	int 21h

	;dec ax
	;dec ax
	mov ax,2

	mov ah,40h
	mov bx,1
	mov cx,ax
	lea dx,str_
	int 21h

	mov ah,4ch
	int 21h
end