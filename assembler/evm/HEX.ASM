Dosseg
.model small
.stack 100h
.data
ch1 dw 000bh, 31f7h
ch2 dw 001bh
res dw 3 dup(0)
.code 
prn macro sym 
local ik,ir,ek,er 
	mov ah,02h
	mov dl,sym
	shr dl,1
	shr dl,1
	shr dl,1
	shr dl,1
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
	mov ax, @data
	mov ds, ax
	
	mov ax, ch1+2
	mul ch2
	mov res+4, ax
	mov res+2, dx
	
	mov ax, ch1+1
	mul ch2
	add res+2, ax
	adc res, dx

	mov cx,ax
	mov bx,dx
	prn bh
	prn bl
	prn ch
	prn cl
	
	
	mov ah, 4ch
	int 21h
END
		
	
	
	
