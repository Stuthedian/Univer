dosseg
.model small
.stack 100h
.data
buf db 0,0
.code
	mov ax,@data
	mov ds,ax
	mov ax,0
	mov bx,0

	mov al,'5'
	mov bl,'7'
	and al,0fh
	and bl,0fh

	add al,bl
	aaa
	or ax,3030h
	lea si,buf
	mov [si],ah
	inc si
	mov [si],al
	
end
