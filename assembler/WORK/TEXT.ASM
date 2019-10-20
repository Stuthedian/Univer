dosseg
.model small
.stack 100h
.data
hand dw 0
fil db 'hold.txt',0
cont db 1000 dup(0)
fraza db 100 dup(0)
erro db 13,10,'Not found$'

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

	mov ah,3dh
	mov al,00
	lea dx,fil
	int 21h
	mov hand,ax

	mov ah,3fh
	mov bx,0
	mov cx,100
	lea dx,fraza
	int 21h
	mov bx,ax
	push bx

	mov ah,3fh
	mov bx,hand
	mov cx,1000
	lea dx,cont
	int 21h
	mov cx,ax


	pop bx
	push bx

	lea si,fraza
	lea di,cont

	mov al,[si]
	dec si
	mov [si],al
	mov al,[di]
	dec di
	mov [di],al
	inc si
	inc di	
	mov bp,0
progon:
	inc bp
	mov al,[si]
	cmp al,[di]
	jne notequal

	dec bx
	jz found
	inc si
	inc di
	dec cx
	jnz progon
	jmp notfound

notequal:
	dec si
	dec di
	mov al,[si]
	cmp al,[di]
	je zzz
	add di,2
	inc si
	dec cx
	jnz progon	
	jmp notfound

zzz:
	lea si,fraza
	pop bx
	add di,2
	dec cx
	jnz progon
	jmp notfound



found:
	inc di
	mov al,10
	cmp [di],al
	je done
	mov ah,02
	mov dl,[di]
	int 21h

	jmp found

notfound:

	mov ah,9
	lea dx,erro
	int 21h

done:

	mov ah,3eh
	lea bx,hand
	int 21h
	
	mov cx,bp
	prn ch
	prn cl
	mov ah,4ch
	int 21h
end
