dosseg
.model small
.stack 100h
.data
sutki db'����� �६� ��⮪?(���/����/����/����)[u/d/v/n]$'
god db'����� �६� ����?(����/��᭠/���/�ᥭ�)[z/v/l/o]$'
utro db 13,10,'���஥ ���!',13,10,'$'
den db 13,10,'����� ����!',13,10,'$'
vecher db 13,10,'����� ����!',13,10,'$'
noch db 13,10,'���ன ���!',13,10,'$'
zima db 13,10,'�������!',13,10,'$'
vesna db 13,10,'�������!',13,10,'$'
leto db 13,10,'��મ!',13,10,'$'
osen db 13,10,'��誨�!',13,10,'$'

error db 13,10,'������ �ࠢ���� ᨬ���![u/o/v/n]',13,10,'$'
error2 db 13,10,'������ �ࠢ���� ᨬ���![z/l/v/o]',13,10,'$'

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
lea dx, sutki
int 21h
jmp prove

begin2:
mov ah, 9
lea dx, god
int 21h
jmp prove2

prove:
mov ah, 01
int 21h

fup 'u', isutro		
fup 'U', isutro		
fup 'd', isden	
fup 'D', isden		
fup 'v', isvecher		
fup 'V', isvecher		
fup 'n', isnoch		
fup 'N', isnoch
jnz iserror

prove2:
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
jnz iserror2

isutro:
cap utro, displayblink

isden:
cap den, displayblink

isvecher:
cap vecher, displayblink

isnoch:
cap noch, displayblink

iszima:
cap zima, displayblink2

isvesna:
cap vesna, displayblink2

isleto:
cap leto, displayblink2

isosen:
cap osen, displayblink2

iserror:
mov ah, 9
lea dx, error
int 21h
jmp begin

iserror2:
mov ah, 9
lea dx, error2
int 21h
jmp begin2


displayblink:
mov ah, 9
int 21h
jmp begin2

displayblink2:
mov ah, 9
int 21h

mov ah, 4ch																																																													
int 21h
end
