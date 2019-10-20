dosseg
.model tiny
.code
org 100h
ckl:
	mov ah,0
	int 16h
	cmp al,1bh
	je done

	mov cl,60h
	add cl,22h
	mul cl
	mov cx,ax

	mov al,0b6h
	out 43h,al
	mov ax,cx
	out 42h,al
	mov al,ah
	out 42h,al

	in al,61h
	mov ah,al
	or al,03
	out 61h,al
	jmp ckl

	
done:
	mov al,ah
	out 61h,al
	mov ah,4ch
	int 21h
end ckl
