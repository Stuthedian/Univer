dosseg
.model small
.stack 100h
.data
hgot dw 0
gotpass db 'gotpass.txt',0
hhold dw 0
hold db 'hold.txt',0
nl db 13,10
len equ $-nl
opis db 100 dup(0)
keyr db 100 dup(0)
.code

	
	mov ax,@data
	mov ds,ax

	mov ah,3dh
	mov al,0
	lea dx,gotpass
	int 21h
	mov hgot,ax

	mov ah,3dh
	mov al,1
	lea dx,hold
	int 21h
	mov hhold,ax



	mov ah,3fh
	mov bx,0
	mov cx,100
	lea dx,opis
	int 21h
	sub ax,2
	mov cx,ax
	push cx

	mov ah,42h
	mov bx,hhold
	mov cx,0
	mov dx,0
	mov al,2
	int 21h

	mov ah,40h
	mov bx,hhold
	mov cx,len
	lea dx,nl
	int 21h

	mov ah,40h
	mov bx,hhold
	mov cx,len
	lea dx,nl
	int 21h


	mov ah,40h
	mov bx,hhold
	pop cx
	lea dx,opis
	int 21h

	mov ah,40h
	mov bx,hhold
	mov cx,len
	lea dx,nl
	int 21h

	mov ah,3fh
	mov bx,hgot
	mov cx,100
	lea dx,keyr
	int 21h
	mov cx,ax
	push cx


	mov ah,40h
	mov bx,hhold
	pop cx
	lea dx,keyr
	int 21h

	mov ah,40h
	mov bx,hhold
	mov cx,len
	lea dx,nl
	int 21h

	
	mov ah,4ch
	int 21h
end