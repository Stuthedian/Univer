dosseg
.model small
.stack 100h
.data
inp db 0,0
num db 0
divs db 64h
.code
prn macro reg
	mov dl, reg
	mov ah, 2
	or dl, 30h
	int 21h
endm
	mov ax, @data
	mov ds, ax

	mov ah, 3fh
	mov bx, 0
	mov cx, 2
	lea dx, inp
	int 21h
	push ax
	prn 0Ah
	prn 0Dh
	pop ax

	mov ah, byte ptr [inp]
	mov al, byte ptr [inp + 1]
	
	cmp ah, ':'
	jg hexh
	and ah, 0fh
	jmp _al	
hexh:
	cmp ah, 47h
	jl _HEXh
	sub ah, 57h
	jmp _al
_HEXh:
	sub ah, 37h
_al:
	cmp al, ':'
	jg hexl
	and al, 0fh
	jmp conc	
hexl:
	cmp al, 47h
	jl _HEXl
	sub al, 57h
	jmp conc
_HEXl:
	sub al, 37h
conc:
	shl al, 4
	shr ax, 4
	mov num, al

	mov ah,0
	mov al, num
	mov bl, divs
	div bl
	cmp al, 0
	je _2_2
	push ax
	prn al
	pop ax	
_2:
	mov al, ah
	mov ah, 0
	mov bl, 10
	div bl
	push ax
	prn al
	pop ax
	jmp _3
_2_2:
	mov al, ah
	mov ah, 0
	mov bl, 10
	div bl
	cmp al, 0
	je _3
	push ax
	prn al
	pop ax

_3:
	prn ah
	
	mov ah, 4ch
	int 21h
end
