dosseg
.model small
.stack 100h
.data
len equ 100
;op1 db len dup(0)
;len1 db 0
;op2 db len dup(0)
;len2 db 0
op1 db '005'
op2 db '015'
len1 db 3
len2 db 3
rzlt db len dup(0)
;mes1 db ''
;mes2 db ''
.code
	mov ax,@data
	mov ds,ax

;	mov ah,3fh
;	mov bx,0
;	mov cx,len
;	lea dx,op1
;	int 21h
;	sub ax,2
;	mov len1,ah


;	mov ah,3fh
;	mov bx,0
;	mov cx,len
;	lea dx,op2
;	int 21h
;	sub ax,2
;	mov len2,ah
	lea si,op1
	lea di,op2
	mov ah,0
	mov al,30h
	mov cx,0
	jmp chnull1



sicorr:
	inc si
	inc cx
chnull1:
	cmp al,[si]
	je sicorr
	sub len1,cl
	mov cx,0
	jmp chnull2
dicorr:
	inc di
	inc cx
chnull2:
	cmp al,[di]
	je dicorr
	sub len2,cl

	push di
	mov al,len1
	cmp al,len2
	ja nullinc
	push si
	push di
	jb procesxchg
	jmp checkxchg

ravno:
	inc si
	inc di 

checkxchg:
	mov al,[si]
	cmp al,[di]
	je ravno
	ja vych
procesxchg:
	mov bl,len1
	mov bh,len2
	mov len2,bl
	mov len1,bh
	pop si
	pop di
	mov ax,si
	mov si,di
	mov di,ax
	lea bx,rzlt
	mov al,2dh
	mov [bx],al
	inc bx

nullinc:
	add len2,1
	dec di
	mov al,len1
	cmp al,len2
	jne nullinc
	jmp vych

vych:
	;pop di
	lea bx,rzlt
	mov al,[bx]
	cmp al,2dh
	je corr
stp:
	mov ah,0
	mov al,len1
	dec ax

	add bx,ax
	add si,ax
	add di,ax
	inc ax
	mov cx,ax
	push cx
	clc
	pushf
	jmp vych2
corr:
	inc bx
	jmp stp

vych2:
	mov al,[si]
	mov dl,[di]
	and al,0fh
	and dl,0fh
	popf
	sbb al,dl
	pushf
	aas
	or al,30h
	mov [bx],al
	dec si
	dec di
	dec bx
	dec cx
	jnz vych2
	popf

	pop cx
	lea bx,rzlt
	mov al,[bx]
	cmp al,2dh
	jne done
	inc cx 		
	
	
done:
	mov ah,40h
	mov bx,0
	;cx
	lea dx,rzlt
	int 21h 

	mov ah,4ch
	int 21h
end