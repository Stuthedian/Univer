dosseg
.model small
.stack 100h
.data
mess db 61h,60h
len equ $-mess
.code
	mov ax,@data
	mov ds,ax

	mov ah,40h
	mov bx,1
	mov cx,len
	lea dx,mess
	int 21h

	mov ah,4ch
	int 21h
end