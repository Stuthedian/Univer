dosseg
.model small
.stack 100h
.data
sutki db'Какое время суток?(Утро/День/Вечер/Ночь)[m/d/e/n]$'
utro db 13,10,'Сейчас утро!',13,10,'$'
den db 13,10,'Сейчас день!',13,10,'$'
vecher db 13,10,'Сейчас вечер!',13,10,'$'
noch db 13,10,'Сейчас ночь!',13,10,'$'

error db 13,10,'Введите правильный символ![m/d/e/n]',13,10,'$'

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


mov ah, 01
int 21h

fup 'm', isutro		
fup 'M', isutro		
fup 'd', isden	
fup 'D', isden		
fup 'e', isvecher		
fup 'E', isvecher		
fup 'n', isnoch		
fup 'N', isnoch
jnz iserror



isutro:
cap utro, displayblink

isden:
cap den, displayblink

isvecher:
cap vecher, displayblink

isnoch:
cap noch, displayblink


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
