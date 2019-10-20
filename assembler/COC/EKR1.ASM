dosseg
.model small
.stack 100h
.data
.code
	mov ah,09h
	mov al,'*'
	mov bh,0
	mov bl,1eh;0001.1110
	int 10h

	mov ah,4ch
	int 21h
end