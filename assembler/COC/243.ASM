dosseg
.model small
.stack 100h
.data
word1 dw 0C46h
word2 dw 6392h
rzlt dw 2 dup(0)
.code
prn macro sym 
local ik,ir,ek,er 
	mov ah,02h
	mov dl,sym
	shr dl,4
	cmp dl,9
	jg ik
	add dl,30h
	int 21h
	jmp ir
ik:
	add dl,37h
	int 21h
ir:
	mov dl,sym
	and dl,0fh
	cmp dl,9
	jg ek
	add dl,30h
	int 21h
	jmp er
ek:
	add dl,37h
	int 21h
er:
endm


	mov ax,@data
	mov ds,ax

	mov ax,word1
	mul word2
	mov rzlt+2,ax
	mov rzlt,dx
	mov cx,ax
	mov bx,dx
	prn bh
	prn bl
;	prn 20h
	prn ch
	prn cl
;	prn 'h'


	mov ah,4ch
	int 21h
end 