dosseg
.model small
.stack 100h
.data
.code
mov ax,@data
mov ds,ax

cikl:
mov cx,5
mov ah,86h
int 15h

mov ah,02h
mov dl,'.'
int 21h

mov ah,01h
int 16h
jz cikl

mov ah,00h
int 16h

mov ah,02h
mov dl,al
int 21h

cmp al,'q'
jnz cikl


mov ah,4ch
int 21h
end

