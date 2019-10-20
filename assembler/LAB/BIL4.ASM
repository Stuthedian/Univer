dosseg
.model small
.stack 100h
.data
m1 db '123456489101'
m2 db '123456L89101'
m3 db '123456I89101'
m4 db '123456F89101'
m5 db '123456E89101'
mn db 5 dup (0)
.code
prn macro mas
	lea bx,mas
	mov al,[bx+si]
	mov [di],al
	inc di
endm
	mov ax,@data
	mov ds,ax
	
	mov si,6
	lea di,mn
	prn m1
	prn m2
	prn m3
	prn m4
	prn m5

	mov ah,40h
	mov bx,1
	mov cx,5
	lea dx,mn
	int 21h
	

	mov ah,4ch
	int 21h

end
