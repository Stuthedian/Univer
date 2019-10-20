dosseg
.model small
.stack 100h
.data
max_len EQU 100
tabl db 'ABCDEFGHIKLMOPQRSTUVWXYZtytytytytythdjretunvpoazr'
str_ db max_len dup(0)
;len EQU $ - str_
.code
	mov ax,@data
	mov ds,ax

;	mov ah,0
;	int 16h
;	cmp al,27
;	jz done

	mov ah,3fh
	mov bx,0
	mov cx,max_len
	lea dx,str_
	int 21h

;	lea bx,tabl
;	dec ax
;	dec ax
;	mov cx,ax
;	lea si,str_

;lo_op:
;	mov al,[si]
;	xlat
;	mov dl,al
;	mov ah,2
;	int 21h

;	mov dl,'_'
;	mov ah,2
;	int 21h
;
;	inc si
;	dec cx
;	jnz lo_op	

	mov ah,40h
	mov bx,1
	mov cx,ax
	lea dx,str_
	int 21h

done:
	mov ah,4ch
	int 21h
end