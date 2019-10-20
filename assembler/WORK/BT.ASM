dosseg;invalid program for 8,9
.model small
.stack 100h
.data
buff1 db 10 dup (0)
buff2 db 24 dup (0)
.code
 mov ax,@data
 mov ds,ax

 mov ah,3fh
 mov bx,1
 mov cx,10
 lea dx,buff1
 int 21h

 lea si,buff1
 lea di,buff2


 sub cx,ax
 cmp cx,0
 jz v0
 cmp cx,1
 jz v1
 jz v2



 v2:
 mov cx,ax
 dec cx
 dec cx
 push cx
 jmp transmitloop

 v1:
 mov cx,ax
 dec cx
 push cx
 jmp transmitloop

 
 
 v0:
 mov cx,ax
 push cx

transmitloop:
 mov al,[si]
 mov [di],al
 inc si
 inc di
 dec cx
 jnz transmitloop

pop cx
mov ax,24
xchg cx,ax
sub cx,ax
mov ax,'.'

loop2:
mov [di],ax
inc di
dec cx
jnz loop2


 mov ah,40h
 mov bx,1
 mov cx,24
 lea dx,buff2
 int 21h

 mov ah,4ch
 int 21h
END 

