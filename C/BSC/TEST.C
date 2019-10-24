#include <stdio.h>
#include <conio.h>
#include <dos.h>
char ctl;
         
void init_port()  {
     ctl = inp(0x3fb);

     outp(0x3fb, ctl | 0x80); 


     outp(0x3f9, 0x00);
     outp(0x3f8, 0x0C); 

     outp(0x3fb, 0x1b);
}

       
void  send_sym (char ch)  {
 unsigned   out_reg, status_reg;
    status_reg = 0x3fd;
    out_reg = 0x3f8;
    while( (inp(status_reg) & 0x20) ==0);
        outp(out_reg, ch);
 }

 char receiv() {
     unsigned   inp_reg, status_reg;

     status_reg = 0x3fd;
     inp_reg = 0x3f8;

     while( (inp(status_reg) & 1) == 0);

     return (inp(inp_reg));
}
void main(void)  {
  init_port();
  while(1)  {
   
	char ch;
	if ((ch=getch())==27) return;
   
      send_sym (ch);
      putchar(receiv());
      }
 }
