dosseg
.model small
.stack 100h
.data
mess db 10 dup(0)
.code
	mov ax,@data
	mov ds,ax

	mov ah,2ch
	int 21h

	mov cx,0Ah

	lea di,mess

loop_:
	sub dl,38h

	mov [di],dl
	inc di
	dec cx
	jnz loop_

	mov ah,40h
	mov bx,1
	mov cx,10
	lea dx,mess
	int 21h

	mov ah,4ch
	int 21h
end
