dosseg
.model small
.stack 100h
.data
sutki db "Время суток?(Утро/N)-[Y/N]$",13,10 ;дописать!

goodmorning   db 13,10,'Dobre utro!',13,10,'$'
goodafternoon db 13,10,'Dobre vecherochka!',13,10,'$'
er db 13,10,'Pishi pravilno stsuka!',13,10,'$'

	.code
	mov ax,@data
	mov ds,ax

	mov ah,9
	lea dx,timeprompt
	int 21h

	mov ah,0
	int 16h

	cmp al,'Y'
	jz isafternoon
	cmp al,'y'
	jz isafternoon

	cmp al,'N'
	jz ismorning
	cmp al,'n'
	jz ismorning
	jnz error


	isafternoon:
	lea dx,goodafternoon
	jmp displaygreeting

	ismorning:
	lea dx,goodmorning
	jmp displaygreeting


	error:
	lea dx,er

	displaygreeting:
	mov ah,9
	int 21h	

	mov ah,4ch
	int 21h
END
