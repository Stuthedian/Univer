dosseg
.model small
.stack 100h
.data
len equ 256
hand dw 0
pass db 'ascii.txt',0
error db 'ERROR!',13,10,'$'
buff db len dup(0)
.code
	mov ax,@data
	mov ds,ax

	mov ah,3dh
	mov al,01
	lea dx,pass
	int 21h
	jc err_
	mov hand,ax
	
	mov al,00h
	lea si,buff
	mov cx,len
	;push cx

loop_:
	mov [si],al
	inc al
	inc si
	dec cx
	jnz loop_
	

	mov ah,40h
	mov bx,1
	mov cx,len
	lea dx,buff
	int 21h


	mov ah,40h
	mov bx,hand
	mov cx,len
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
