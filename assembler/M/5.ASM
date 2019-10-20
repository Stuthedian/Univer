dosseg
.model small
.stack 100h
.data
mes1 db 'message1',0
nl db 13,10,0
mes2 db 'message2',0
.code
jmp begin
print proc near 

	mov bh,0
ckl:
	cmp [si],bh
	je done
	mov ah,2
	mov dl,[si]
	int 21h
	inc si
	jmp ckl

done:
	ret
endp

begin:
	mov ax,@data
	mov ds,ax

	lea si, mes1
	call print

	lea si, nl
	call print

	lea si, mes2
	call print

	mov ah,4ch
	int 21h
end
