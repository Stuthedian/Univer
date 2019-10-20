dosseg
.model small
.stack 100h
.data
maxlen EQU 100
tabl db 256 dup (0)
str_ db maxlen dup (0)
ascii db 'ascii.txt',0
pass db 'getpass.txt',0
hand dw 0
hand1 dw 0
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
	
	mov ah,3dh
	mov al,00
	lea dx,ascii
	int 21h
	jc done
	mov hand1,ax

	mov ah,3dh
	mov al,00
	lea dx,pass
	int 21h
	jc done
	mov hand,ax

	mov ah,3fh
	mov bx,hand1
	mov cx,256
	lea dx,tabl
	int 21h
	jc done

	mov ah,3fh
	mov bx,hand
	mov cx,maxlen
	lea dx,str_
	int 21h
	jc done



 	mov cx,ax
	push cx

;	mov ah,40h
;	mov bx,1
;	pop cx
;	lea dx,str_
;	int 21h

	lea bx,tabl
	pop cx
	lea si,str_
	mov sp,0


loop_:
	mov al,[si]
	xlat


	prn al
	cmp sp,2
	jz tan
tan:
	add bx,5
	mov sp,0
lcon:

	inc si
	inc sp
	dec bx
	dec cx
	jnz loop_

	prn 13
	prn 10
;	jmp done

	mov ah,3eh
	mov bx,hand
	int 21h

	mov ah,3eh
	mov bx,hand1
	int 21h
	
done:
	mov ah,4ch
	int 21h
	
end
