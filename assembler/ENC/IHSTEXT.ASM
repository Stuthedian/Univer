dosseg
.model small
.stack 100h
.data
tabl db 256 dup (0)
inv db 100 dup(0)
str_ db 100 dup (0)
buf db 100 dup(0)
ascii db 'ascii.txt',0
shifr db 'gotpass.txt',0
pass db 'getpass.txt',0
hascii dw 0
hshifr dw 0
hpass dw 0
hand dw 0
fil db 'hold.txt',0
cont db 300 dup(0)
fraza db 100 dup(0)
erro db 13,10,'Not found$'
.code
	mov ax,@data
	mov ds,ax

	mov ah,3dh
	mov al,00
	lea dx,fil
	int 21h
	mov hand,ax

	mov ah,3ch
	mov cx,00
	lea dx,shifr
	int 21h
	mov hshifr,ax


	mov ah,3fh
	mov bx,0
	mov cx,100
	lea dx,fraza
	int 21h
	mov bx,ax
	push bx

	mov ah,3fh
	mov bx,hand
	mov cx,300
	lea dx,cont
	int 21h
	mov cx,ax


	pop bx
	push bx

	lea si,fraza
	lea di,cont

	mov al,[si]
	dec si
	mov [si],al
	mov al,[di]
	dec di
	mov [di],al
	inc si
	inc di	
	
progon:
	mov al,[si]
	cmp al,[di]
	jne notequal

	dec bx
	jz found
	inc si
	inc di
	dec cx
	jnz progon
	jmp notfound

notequal:
	dec si
	dec di
	mov al,[si]
	cmp al,[di]
	je zzz
	add di,2
	inc si
	dec cx
	jnz progon	
	jmp notfound

zzz:
	lea si,fraza
	pop bx
	add di,2
	dec cx
	jnz progon
	jmp notfound

found:
	cmp bx,1
	je found2
	lea si,str_
	mov cx,0
	mov bx,1

found2:
	inc di
	mov al,13
	cmp [di],al
	je prod
	mov ah,[di]
	mov [si],ah
	inc si
	inc cx
	jmp found2

notfound:

	mov ah,9
	lea dx,erro
	int 21h
	jmp done


prod:
	sub cx,0Ah
	mov ax,cx
	push ax
	push cx
	

	mov ah,3dh 
	mov al,00
	lea dx,ascii
	int 21h
	mov hascii,ax

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

	pop cx
	lea si,str_
	add si,4
	add si,cx
	dec si
	lea di,inv
	push cx
tran:
	mov al,[si]
	mov [di],al
	dec si
	inc di
	dec cx
	jnz tran

	lea si,inv
	lea di,buf

	mov bp,0
	lea bx,tabl
	pop cx
	mov ah,22h
	sub [si],ah

loop_:
	mov al,[si]
	xlat


	mov [di],al
	cmp bp,2
	jz tan
	jmp lcon
tan:
	sub bx,5
	mov bp,0
lcon:

	inc si
	inc di
	inc bp
	add bx,2
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
	mov ah,3eh
	lea bx,hand
	int 21h

	mov ah,4ch
	int 21h
	
end
