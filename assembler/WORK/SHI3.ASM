dosseg
.model small
.stack 100h
.data
maxlen EQU 100
tabl db 20h dup(0),' !"#$%&',0,'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~',0,'€‚ƒ„…†‡‰‹‘’“”•–—™› ΅Ά£¤¥¦§¨©ª«¬­®―',30h dup(0),'ΰαβγδεζηθικλμνξοπρ !"#$%&',0,'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~',0,'€‚ƒ„…†‡‰‹‘’“”•–—™› ΅Ά£¤¥¦§¨©ª«¬­®―',30h dup(0),'ΰαβγδεζηθικλμνξοπρ'
str_ db maxlen dup(0)
.code;make output like:0000000
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
	mov al,[si]


loop_:
	mov ah,[si]

;	sub [si],al
;	xchg al,[si]	
;	cbw 
;	shr ax,8
;	sub bx,ax
;	mov ah,al

	xlat
	prn ah
	prn bh
	prn bl

	inc si
	dec cx
	jnz loop_

	prn 13
	prn 10
	prn dh;marker
	jmp done

done:
	mov ah,4ch
	int 21h
	
end
