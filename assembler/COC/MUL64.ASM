dosseg
.model small
.stack 100h
.data
divd db '7236'
divs db '6'
result db 4 dup('0')
.code
.286
begin:
	mov ax,@data
	mov ds,ax

	mov cx,4
	mov ah,0
	and divs,0fh
	lea si,divd
	lea di,result
	
loop_:
	mov al,[si]
	and al,0fh
	aad
	div divs
	or al,30h
	mov [di],al
	inc si
	inc di
	loop loop_
end begin