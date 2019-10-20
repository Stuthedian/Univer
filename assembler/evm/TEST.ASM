dosseg 
.model small
.stack 100h
.data
max_len EQU 100
strk db max_len dup(0)
digit db 0
.code

print_02 macro sym
	mov ah,2
	mov dl,sym
	int 21h
endm

start:	
	mov ax,@data
	mov ds,ax
	mov es,ax

	mov ah,3fh
	mov bx,0
	mov cx,max_len
	lea dx,strk
	int 21h

	cmp ax,0
	jz done
	mov cx,ax
	push cx
	mov digit,'0'

new_digit:
	mov bx,0
	lea di,strk
	pop cx
	push cx

repeat:
	mov al,digit
	repne scasb
	jnz ddd
	inc bx
	jmp repeat

ddd:
	print_02 al
	or  bl,30h
	print_02 bl
	print_02 10
	print_02 13
	inc digit
	cmp digit,'9'
	jz done
	jmp new_digit

done:
	mov ah,4ch
	int 21h
end
