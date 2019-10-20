DOSSEG
.MODEL SMALL
.STACK 100h
.DATA
mes1 db 'Получилось, лол...$'
mes2 db 'А, нет, показалось.$'
.CODE
     mov ax, @Data
     mov ds, ax

     mov al, es:[82h]
     cmp al, '?'
     jz goto1
     mov al, es:[83h]
     cmp al, '?'
     jz goto1

     mov ah, 9h
     lea dx, mes2
     int 21h
     jmp goto2

goto1:
     mov ah, 9h
     lea dx, mes1
     int 21h

goto2:
     mov ah, 4ch
     int 21h

END