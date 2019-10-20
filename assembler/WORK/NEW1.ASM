dosseg
.model small
.stack 100h
.data
max_len EQU 100
buff1 db max_len dup (0)
buff2 db max_len dup (0)
.code
start:
 mov ax,@data
 mov ds,ax

 mov ah,3fh
 mov bx,0
 mov cx, max_len
 mov dx,offset buff1
 int 21h
 
 cmp ax,0
 jz Done
 mov cx,ax
 push cx

 lea si,buff1
 lea di,buff2
 
 add di,cx
 dec di
 
TransmitLoop:
 mov al,[si]
 mov [di],al
 inc si
 dec di
 dec cx
 jnz TransmitLoop

 mov ah,40h
 mov bx,1
 pop cx
 lea dx,buff2
 int 21h

Done:
 mov ah,4ch
 int 21h
END start

