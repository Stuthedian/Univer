dosseg
.model small
.stack 100h
.data 
tabl db 'ABCDEF'
string db 80h,81h,82h,83h,84h
leng EQU $-string
.code
mov ax,@data
mov ds,ax

lea bx,tabl
mov cx,leng
lea si,string

lop:
mov al,[si]
xlat

mov dl,al
mov ah,2
int 21h

mov dl,' '
mov ah,2
int 21h

inc si
dec cx
jnz lop

mov ah,4ch
int 21h
end
