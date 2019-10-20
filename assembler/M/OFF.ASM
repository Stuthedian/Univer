dosseg
.model small
.stack 100h
.data
massiv db '01234567'
db '12345678'
db '23456781'
db '34567812'
db '45678123'
.code
	mov ax, @data
	mov ds, ax
	
	cmp byte ptr es:[80h], 0
	je done

	mov al, byte ptr es:[82h]
	and al, 0fh
	mov ah, 0

	mov cx, 5
	lea si, massiv
	mov bx, 0
	add bx, ax
	dec bx
ckl:
	mov dl, [si + bx]
	mov ah, 2
	int 21h
	add bx, 8
	dec cx
	jnz ckl
done:
	mov ah, 4ch
	int 21h
end
