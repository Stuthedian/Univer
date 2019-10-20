DOSSEG
.MODEL SMALL
.STACK 100h
.DATA
mass1 db '1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '$'
mass2 db '1', '1', '1', '1', '1', '1', '6', '1', '1', '1', '1', '1', '$'
mass3 db '2', '2', '2', '2', '2', '2', '5', '2', '2', '2', '2', '2', '$'
mass4 db '3', '3', '3', '3', '3', '3', '4', '3', '3', '3', '3', '3', '$'
mass5 db '4', '4', '4', '4', '4', '4', '3', '4', '4', '4', '4', '4', '$'
nln db 10, 13, '$'
.CODE
write7 macro mass
       mov ah, 40h
       mov bx, 1h
       lea dx, mass
       add dx, 6h
       mov cx, 1
       int 21h
       fnextline
endm

fnextline macro
          mov ah, 9h
          mov bx, 1
          lea dx, nln
          int 21h
endm


     mov ax, @Data
     mov ds, ax

     write7 mass1
     write7 mass2
     write7 mass3
     write7 mass4
     write7 mass5

;     mov ah, 40h
;     mov bx, 1h
;     lea dx, mass3
;     add dx, 6h
;     mov cx, 1
;     int 21h

     mov ah, 4ch
     int 21h

END
