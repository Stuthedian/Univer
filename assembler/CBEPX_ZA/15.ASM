.model small
.stack 100h
.data
dta db 80h dup (0)
mask_  db '*.prm',0
tab db 9,'$'
.code
.386	
prn macro 
local out_100, out_010, out_001, out_10, out_01, end_
;	mov ax, number
	mov bx, 1
	mul bx
	aam	
	cmp ah, 0Ah
	jl out_10

out_100:
	push ax
	shr ax, 8	
	mul bx
	aam

	push ax	
	or ah, 30h
	mov dl, ah
	mov ah, 02h
	int 21h

out_010:
	pop ax
	or al, 30h
	mov dl, al
	mov ah, 02h
	int 21h
	;push ax

out_001:
	pop ax
	or al, 30h
	mov dl, al
	mov ah, 02h
	int 21h
	jmp end_

out_10:
	cmp ah, 0
	je out_01
	
	push ax
	or ah, 30h
	mov dl, ah
	mov ah, 02h
	int 21h
	pop ax
	
out_01:
	or al, 30h
	mov dl, al
	mov ah, 02h
	int 21h

end_:
endm
	mov ax, @data
	mov ds, ax

	mov ah, 1ah
	lea dx, dta
	int 21h

	mov ah, 4eh
	mov cx, 00
	lea dx, mask_
	int 21h
	jc fail

info:
	mov ax, word ptr [dta+18h] 
	push ax
	shr ax, 11
	shl ax, 11
	and ax, 1111101111111111b
	
	pop bx
	shl bx, 9
	shr bx, 9
	or bx, 1111111110000000b
	and ax, bx
	mov word ptr [dta+18h], ax	

	push ax
	and ax, 0000000000011111b
	prn
		
	mov ah, 02h
	mov dl, '.'
	int 21h

	pop ax
	push ax
	shr ax, 5
	and ax, 0000000000001111b
	prn

	mov ah, 02h
	mov dl, '.'
	int 21h

	pop ax
	shr ax, 9
	add ax, 80
	sub ax, 100
	prn

	mov ah, 9
	lea dx, tab
	int 21h

	
	mov ah, 40h
	mov bx, 0
	mov cx, 13
	lea dx, [dta+1eh]
	int 21h

	mov ah, 02h
	mov dl, 13
	int 21h

	mov ah, 02h
	mov dl, 10
	int 21h

	mov ah, 4fh
	lea dx, dta
	int 21h
	jc fail
	jmp info

fail:
	mov ah, 4ch
	int 21h
end

