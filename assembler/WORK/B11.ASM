dosseg
.model small
.stack 100h
.data
god db'����� �६� ����?(����/��᭠/���/�ᥭ�)[z/v/l/o]$'
zima db 13,10,'����� ����!',13,10,'$'
vesna db 13,10,'����� ��᭠!',13,10,'$'
leto db 13,10,'����� ���!',13,10,'$'
osen db 13,10,'����� �ᥭ�!',13,10,'$'

error db 13,10,'������ �ࠢ���� ᨬ���![z/v/l/o]',13,10,'$'

.code
fup macro sim, metka
cmp al, sim
jz metka
endm

cap macro mess, metka
lea dx, mess
jmp metka
endm

mov ax, @data
mov ds, ax


begin:
mov ah, 9
lea dx, god
int 21h


mov ah, 01
int 21h

fup 'z', iszima		
fup 'Z', iszima		
fup 'v', isvesna
fup 'V', isvesna	
fup 'l', isleto	
fup 'L', isleto		
fup 'o', isosen		
fup 'O', isosen
jnz iserror

iszima:
cap zima, displayblink

isvesna:
cap vesna, displayblink

isleto:
cap leto, displayblink

isosen:
cap osen, displayblink

iserror:
mov ah, 9
lea dx, error
int 21h
jmp begin

displayblink:
mov ah, 9
int 21h

mov ah, 4ch																																																													
int 21h
end
