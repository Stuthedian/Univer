dosseg 
.model small 
.stack 100h 
.data 
digit db -10 
.code 
.386 
jmp start 
positive proc 
mov al, 3 
mul bl 
add al, 5 
mov ah,02h 
mov dl,al 
shr dl,4 
cmp dl,0 
jg ckl 
add dl,30h 
int 21h 
ret 
endp 
negative proc 
mov al, bl 
imul bl 
add al, 4 
mov bl, 2 
div bl 
mov ah,02h 
mov dl,al 
shr dl,4 
cmp dl,0 
jg ckl 
add dl,30h 
int 21h 
ret 
endp 
start: 
mov ax, @data 
mov ds, ax 

mov cx, 21 
begin: 
mov bl, digit 
cmp bl, 0 
jl neg_ 
call positive 
jmp ckl 
neg_: 
call negative 
ckl: 
inc digit 
dec cx 
jnz begin 

mov ah, 4ch 
int 21h 
end