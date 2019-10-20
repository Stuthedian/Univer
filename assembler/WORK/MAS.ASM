dosseg 
.model small
.stack 100h
.data
mas db ,2,3,7,54,34
.code
mov ax,@data
mov ds,ax

mov ah,40h
mov bx,1
mov cx,2
mov dx,offset mas

mov ah,4ch
int 21h
end
