#include <conio.h>
#include <dos.h>
#include <dir.h>
#include <stdio.h>
struct ffblk ffblk;
int f_d=0;   // Здесь будем фиксировать прием символа DLE
int j=0;	      // номер передаваемого  символа данных	
int i=0;	      // счетчик принятых символов данных 	
char ctl, in_sv, f1=0, int_save;
int ack_flag = 0;
int start_flag = 0;
int end_flag = 0;
int etx2 = 0;
void interrupt receiv(void); // Объявление процедуры прерывания
char in_buf[80]={0}; // Буфер ввода
char out_buf[10]={"HELLO!"};       // Буфер вывода 
char out_buf2[500]={0};
// Определим коды, соответствующие управляющим символам
#define DLE    0x10
#define ENQ    0x05
#define SOH    0x01
#define ETB     0x17
#define ACK0  0x06
#define ACK1  0x08
#define STX   0x02
#define ETX   0x03
#define EOT     0x04
#define base  0x3F8  

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
/* уст. нового обработчика */
 void set_vect()   
 {
  setvect (0x0C, receiv);
 }
 /* *** инициализация контролера прерывания *** */
void init_ctrl()  
{
int_save = inp(0x21);
     outp(0x21,int_save & 0x0E7);
 }
/* *** вывод символа в порт *** */
 void  send_sym (char ch)  
 {
unsigned   out_reg, status_reg;
    status_reg = base+5;
    out_reg = base+0;
        while( (inp(status_reg) & 0x20) == 0);
    outp(out_reg, ch);
 }
/* Обработчик прерывания по вводу символа. В этой процедуре реализован механизм байтстаффинга.*/
void interrupt receiv() {
     char ch;
     unsigned   inp_reg;
     inp_reg = 0x3F8;
                 
     ch=inp(inp_reg);     //пpием символа из порта данных
/* Процедура вывода принятого символа на экран, реализованная с помощью функции BIOS */       
//_AL=ch; _AH=0x0e; _BX=0; geninterrupt(0x10);
/* Учет режима байтстаффинга   */
 if(f_d==0)    /* если флаг  DLE не установлен, т.е. предыдущий  
                         принятый символ был не DLE */
 {      
     if(ch==DLE) f_d=1; // если принят символ DLE установим флаг
     else  in_buf[i++]=ch;  // иначе символ положим в буфер
  }
 else  /* если флаг  DLE  установлен, т.е. предыдущий  */
 {                       /*принятый символ был  DLE */
         if(ch==DLE) // если принят DLE, то это символ данных 
         {  f_d=0; in_buf[i]=ch; i++;}// положим в его в буфер 
         else  /* символ после DLE - управляющий. Код, принятого 
                     управляющего символа заносим в переменную f1
         и сбросим флаг приема DLE */
        {  f_d=0; 
		if(ch == SOH || ch == STX)
			i = 0;
		f1 = ch;
		}   
  }
   outp (0x20,0x20);
}

void send_ack()
{
	if(ack_flag == 0)
	{
		send_sym (DLE);send_sym (ACK0);
		ack_flag = 1;
	}
	else
	{
		send_sym (DLE);send_sym (ACK1);
		ack_flag = 0;
	}
}

void main(void)
{
 int done;
 char ch;
 char* cmd = "ls C:\\NET\\";
 FILE* ls= fopen("C:\\NET\\ls.txt", "w+");
 FILE* ls2 = fopen("C:\\NET\\ls2.txt", "w");
 clrscr();         // Очистим экран
 init_port();    // Установим параметры COM порта
 set_vect();    //  Заменим вектор прерывания COM порта
init_ctrl();

printf("F1-start, F2-send message, ESC-exit\n");
   while(1)
    {
       while(!kbhit())
       //если не нажата никакая клавиша пpовеpяем содержимое f1
        {
          // если принят ENQ, отошлем подтверждение ACK0 
          if(f1==ENQ)
                 {f1=0; printf("RECEIVE ENQ\n");
                  send_ack(); }
         /* если принят ACK0, передадим в линию пакет заголовка 
             с управляющими символами начала и конца заголовка */ 
           if(f1==ACK0)
           {
                 { f1=0;printf("RECEIVE ACK0\n");
				 if(start_flag == 0)
					{
						send_sym(DLE); send_sym(SOH);
						for(i=0; i<6; i++)
						   {
							 send_sym(out_buf[i]);
						   }
						   send_sym('\n');
						send_sym(DLE); send_sym(ETB);
						start_flag = 1;
					}
                                  else
                                  {
                                        send_sym(DLE); send_sym(STX);
                                        rewind(ls);
                                        while(!feof(ls))
                                        {
                                                send_sym(fgetc(ls));
                                        }
                                        send_sym('\0');
                                        send_sym(DLE); send_sym(ETX);
                                  }
				  if(end_flag == 1)
                                  {
                                  printf("Press any key to exit");
                                  getch();
                                        return;
                                  }
                 }
            }
/* если принят ETB, выведем на экран содержимое входного буфера in_buf и отошлем подтверждение ACK1*/ 
           if(f1==ETB)
                 { 
                 f1=0; printf("RECEIVE ETB\n");
                   for(i=0; i<6; i++) putch(in_buf[i]);
                   send_ack();
                 }
            if(f1==ACK1)
                 { 
                   f1=0; 
                   printf("RECEIVE ACK1\n");
                   send_sym(DLE); send_sym(STX);
                   for(j = 0; cmd[j]!='\0'; ++j)
                           send_sym(cmd[j]);
                           send_sym('\0');
                   send_sym(DLE); send_sym(ETX);
				   if(end_flag == 1)
		                   {
                                  printf("Press any key to exit");
                                  getch();
                                        return;
                                  }
                  }
            if(f1==ETX)
            {
                f1=0; printf("RECEIVE ETX\n");
                if(etx2 == 0)
                {
                etx2 = 1;
                   for(i=0; in_buf[i] != '\0'; i++) 
                            putch(in_buf[i]);
done = findfirst("C:\\NET\\*.*",&ffblk,0);
while (!done)
{
   fputs(ffblk.ff_name, ls);
   fputc('\n', ls);
   done = findnext(&ffblk);
}                            
                   send_ack();
                   }
                   else
                   {
                   fwrite(out_buf2,1,sizeof(out_buf2),ls2);    
                   return;
                   }
            }
			if(f1==EOT)
            {
                f1=0; printf("RECEIVE EOT\n");
				end_flag = 1;
                   send_ack();
            }
        }

       //если нажата клавиша
           ch=getch();
            if(ch==27)
			{
				send_sym (DLE);send_sym (EOT);
			}
/* Если нажать F1, то послать символ ENQ - запрос на установление связи */
            if(ch==59)    // Нажата клавиша F1
                 { 
					send_sym (DLE);send_sym (ENQ);
	 }
        }
}
