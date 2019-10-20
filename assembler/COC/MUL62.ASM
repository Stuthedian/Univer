dosseg
.model small
.stack 100h
.data
bcd1 db 05h,78h,36h
bcd2 db 05h,94h,27h
bcd3 db 4 dup(0)
.code
.286
begin:
	mov ax,@data
	mov ds,ax

	mov ah,0
	lea si,bcd1+2
	lea di,bcd2+2
	lea bx,bcd3+3
	mov cx,03
	clc
	pushf	
c20:
	mov al,[si]
	popf
	adc al,[di]
	daa
	pushf
	mov [bx],al
	dec si
	dec di
	dec bx
	dec cx
	jnz c20

	mov ah,4ch
	int 21h
end begin