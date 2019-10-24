#include <stdio.h>
#include <conio.h>
#include <dos.h>
#define base  0x3F8  // порт COM1

 char ctl,int_save;
 FILE* in, * out;
     /* объявление программы обработки прерываний */
void interrupt  receiv(void);
          /* *** инициализация COM-порта *** */
void init_port()  {
     ctl = inp(base+3);
     outp(base+3, ctl | 0x80); // уст. ст. бит режима
// записываем значение делителя частоты
     outp(base+1, 0x00);
     outp(base+0, 0x0C); // скорость 9600 бод
// устанавливаем характеристики обмена - 8 бит,1 стоп, четность
     outp(base+3, 0x1b); // 0001.1011
// уст. регистр управления прерыванием по вводу
     outp(base+1,  0x01);
// уст. регистр управления modem прерывания */
     outp(base+4,  0x0b);
     }
              /* *** инициализация контролера прерывания *** */
void init_ctrl()  {
     int_save = inp(0x21);
     outp(0x21,int_save & 0x0E7);
 }
/* уст. нового обработчика */
void set_vect()  
   {  setvect (0x0C, receiv); }
               /* *** новый обработчик *** */
void interrupt receiv() {
     char ch;
     unsigned   inp_reg, status_reg;
     status_reg = base+5;
     inp_reg = base+0;
  //   while( (inp(  status_reg) & 1) == 0);
     ch = inp(inp_reg);
	fputc(ch, out);
// вывод на экран
     //_AL = ch-1;  
//     _AL = ch;
//     _AH = 0x0E; _BX = 0;
//     geninterrupt(0x10);
//завершение аппаратного прерывния
//     outp (0x20, 0x20);
 }
       /* *** вывод символа в порт *** */
void  send_sym (char ch)  {
 unsigned   out_reg, status_reg;
    status_reg = base+5;
    out_reg = base+0;
        while( (inp(status_reg) & 0x20) == 0);
    outp(out_reg, ch);
 }
             /* *** основная программа *** */
void  main()  {
   char ch;
   char* first_name, * second_name;
    set_vect();
    init_port();
    init_ctrl();
    printf ("\n Инициализация  COM-порта  произведена.  Нажмите  любую клавишу...\n");
 //    while ((ch = getch())!=27)
   //  {    send_sym(ch); }
 
	if ((in = fopen("file1.c", "rt")) == NULL)
     printf("\n\nPlease enter a name of first file: ");
      scanf("%s", first_name);
      if ((in = fopen(first_name, "rt")) == NULL)
		{  fprintf(stderr, "Cannot open input \
				   file.\n");
		   return ;
		}
     printf("\n\nPlease enter a name of out file: ");
      scanf("%s", second_name);
     if ((out = fopen(second_name, "wt")) == NULL)
		{  fprintf(stderr, "Cannot open output \
				   file.\n");
		   return ;
		}
	while (!feof(in))
		send_sym(fgetc(in));
//	   fputc(fgetc(in), out);
	fclose(in);
	fclose(out);

 }

