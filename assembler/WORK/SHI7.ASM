dosseg
.model small
.stack 100h
.data
tabl db 256 dup (0)
str_ db 100 dup (0)
buf db 100 dup(0)
ascii db 'ascii.txt',0
shifr db 'getpass.txt',0
pass db 'gotpass.txt',0
hascii dw 0
hshifr dw 0
hpass dw 0
.code
	
	mov ax,@data
	mov ds,ax
	
	mov ah,3dh 
	mov al,00
	lea dx,ascii
	int 21h
	mov hascii,ax

	mov ah,3dh
	mov al,00
	lea dx,shifr
	int 21h
	mov hshifr,ax

	mov ah,3ch
	mov cx,00
	lea dx,pass
	int 21h
	mov hpass,ax

	mov ah,3fh
	mov bx,hascii
	mov cx,256
	lea dx,tabl
	int 21h

	mov ah,3fh
	mov bx,hshifr
	mov cx,100
	lea dx,str_
	int 21h



 	mov cx,ax
	push ax
	push cx

	lea bx,tabl
	lea si,str_
	lea di,buf
	mov bp,0

	pop cx

loop_:
	mov al,[si]
	xlat


	mov [di],al
	cmp bp,2
	jz tan
	jmp lcon
tan:
	add bx,5
	mov bp,0
lcon:

	inc si
	inc di
	inc bp
	dec bx
	dec cx
	jnz loop_

	pop ax
	mov cx,ax
	push cx

	mov ah,40h
	mov bx,hpass
	pop cx
	lea dx,buf
	int 21h

	mov ah,3eh
	mov bx,hascii
	int 21h

	mov ah,3eh
	mov bx,hshifr
	int 21h

	mov ah,3eh
	mov bx,hpass
	int 21h
	
done:
	mov ah,4ch
	int 21h
	
end
