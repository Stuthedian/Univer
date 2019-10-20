dosseg
.model small
.stack 100h
.data
mes1 db 'Сообщение1',13,10,'$'
mes2 db 'Сообщение2',13,10,'$'
.code
	mov ax, @data
	mov ds, ax

	cmp byte ptr es:[80h], 0
	je done

	cmp byte ptr es:[80h], 2
	jg done

	cmp byte ptr es:[82h], '1'
	je prn_1

	cmp byte ptr es:[82h], '2'
	je prn_2
	jmp done

prn_1:
	mov ah, 9
	lea dx, mes1
	int 21h
	jmp done
prn_2:
	mov ah, 9
	lea dx, mes2
	int 21h
done:
	mov ah, 4ch
	int 21h
end
