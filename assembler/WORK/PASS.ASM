dosseg
.model small
.stack 100h
.data
hand dw 0
pass db 'pass1.txt',0
error db 'ERROR!',13,10,'$'
info db 'jasperdy',13,10,'jazikyan'
len equ $- info
.code
	mov ax,@data
	mov ds,ax

	mov ah,3ch
	mov cx,00
	lea dx,pass
	int 21h
	jc err_
	mov hand,ax

	mov bx,ax
	mov ah,40h
	lea dx,info
	mov cx,len
	int 21h

	mov ah,3eh
	mov bx,hand
	int 21h
	jnc done
	
	
	
err_:
	mov ah,9
	lea dx,error
	int 21h

done:
	mov ah,4ch
	int 21h
end
