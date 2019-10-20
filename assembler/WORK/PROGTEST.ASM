DOSSEG
.MODEL SMALL
.STACK 100h
.DATA
Mess    DB 'nasha tanya',13,10
Ji EQU   ($-Mess)
	DB 'gromko plachet',13,10
Ta EQU   ($-Mess)
	DB 'uronila v rechku myachik',13,10
Ezhi EQU ($-Mess)
.CODE
	mov ax, @Data
	mov ds, ax

	mov ah, 40h
	mov bx, 1
	mov cx, Ezhi 
	lea dx, Mess
	int 21h

	mov ah, 40h
	mov bx, 1
	mov cx, Ta
	lea dx, $
	int 21h

	
	mov ah, 4ch
	int 21h
END
