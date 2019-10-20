dosseg
.model small
.stack 100h
.data
word1 dw 3206h,2521h
word2 dw 6400h
rzlt dw 3 dup(0)
.code
begin:
	mov ax,@data
	mov ds,ax

	mov ax,word1+2
	mul word2
	mov rzlt+4,ax
	mov rzlt+2,dx
	mov ax,word1
	mul word2
	add rzlt+2,ax
	adc rzlt,dx

	mov ah,4ch
	int 21h
end begin