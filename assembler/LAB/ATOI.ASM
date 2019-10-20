dosseg
.model small
.stack 100h
.data
number dw 0091h
;32 35 35
.code
	mov ax, @data
	mov ds, ax

	mov ax, number
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
	mov ah, 4ch
	int 21h
end
