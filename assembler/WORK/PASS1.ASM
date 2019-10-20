dosseg
.model small
.stack 100h
.data
len equ 100
hand dw 0
pass db 'getpass.txt',0
error db 'ERROR!',13,10,'$'
buff db len dup(0)
;mess db 13,10,'importante!$'
.code
	mov ax,@data
	mov ds,ax

	mov ah,3dh
	mov al,00
	lea dx,pass
	int 21h
	jc err_
	mov hand,ax

	mov bx,ax
	mov ah,3fh
	lea dx,buff
	mov cx,len
	int 21h

	mov cx,ax
	push cx

	mov ah,40h
	mov bx,1
	pop cx
	lea dx,buff
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
