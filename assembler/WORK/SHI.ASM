dosseg
.model small
.stack 100h
.data
maxlen EQU 100
tabl db 20h dup(0),' !"#$%&',0,'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~',0,'€‚ƒ„…†‡‰‹‘’“”•–—™› ΅Ά£¤¥¦§¨©ª«¬­®―',30h dup(0),'ΰαβγδεζηθικλμνξοπρ'
str_ db maxlen dup(0)
.code
prn macro cim
	push ax
	mov ah,2
	mov dl,cim
	int 21h
	pop ax
endm
	
	mov ax,@data
	mov ds,ax
	
	mov ah,3fh
	mov bx,0
	mov cx,maxlen
	lea dx,str_
	int 21h

	mov cx,ax
	dec cx
	dec cx
	push cx

	lea bx,tabl
	pop cx
	lea si,str_


loop_:
	mov al,[si]
	xlat


	prn al

	inc si
	dec cx
	jnz loop_

	prn 13
	prn 10
	jmp done

done:
	mov ah,4ch
	int 21h
	
end
