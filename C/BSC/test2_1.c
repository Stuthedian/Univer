#include <stdio.h>
#include <conio.h>
#include <dos.h>
#include <dir.h>
struct ffblk ffblk;
int f_d=0;   // ����� �㤥� 䨪�஢��� �ਥ� ᨬ���� DLE
int j=0;	      // ����� ��।��������  ᨬ���� ������	
int i=0;	      // ���稪 �ਭ���� ᨬ����� ������ 	
char ctl, in_sv, f1=0, int_save;
void interrupt receiv(void); // ������� ��楤��� ���뢠���
char in_buf[80]={0}; // ���� �����
char out_buf[10]={"Hello!"};       // ���� �뢮�� 
// ��।���� ����, ᮮ⢥�����騥 �ࠢ���騬 ᨬ�����
#define DLE    0x10
#define ENQ    0x05
#define SOH    0x01
#define ETB     0x17
#define ACK0  0x06
#define ACK1  0x08
#define EOT     0x04
#define base  0x3F8  

          /* *** ���樠������ COM-���� *** */
void init_port()  {
  ctl = inp(base+3);
     outp(base+3, ctl | 0x80); // ���. ��. ��� ०���
// �����뢠�� ���祭�� ����⥫� �����
     outp(base+1, 0x00);
     outp(base+0, 0x0C); // ᪮���� 9600 ���
// ��⠭�������� �ࠪ���⨪� ������ - 8 ���,1 �⮯, �⭮���
     outp(base+3, 0x1b); // 0001.1011
// ���. ॣ���� �ࠢ����� ���뢠���� �� �����
     outp(base+1,  0x01);
// ���. ॣ���� �ࠢ����� modem ���뢠��� */
     outp(base+4,  0x0b);
 }
/* ���. ������ ��ࠡ��稪� */
 void set_vect()   
 {
  setvect (0x0C, receiv);
 }
 /* *** ���樠������ ����஫�� ���뢠��� *** */
void init_ctrl()  
{
int_save = inp(0x21);
     outp(0x21,int_save & 0x0E7);
 }
/* *** �뢮� ᨬ���� � ���� *** */
 void  send_sym (char ch)  
 {
unsigned   out_reg, status_reg;
    status_reg = base+5;
    out_reg = base+0;
        while( (inp(status_reg) & 0x20) == 0);
    outp(out_reg, ch);
 }
/* ��ࠡ��稪 ���뢠��� �� ����� ᨬ����. � �⮩ ��楤�� ॠ������� ��堭��� �������䨭��.*/
void interrupt receiv() {
     char ch;
     unsigned   inp_reg;
     inp_reg = 0x3F8;

     ch=inp(inp_reg);     //�p��� ᨬ���� �� ���� ������
/* ��楤�� �뢮�� �ਭ�⮣� ᨬ���� �� �࠭, ॠ���������� � ������� �㭪樨 BIOS */       
//_AL=ch; _AH=0x0e; _BX=0; geninterrupt(0x10);
/* ��� ०��� �������䨭��   */
 if(f_d==0)    /* �᫨ 䫠�  DLE �� ��⠭�����, �.�. �।��騩  
                         �ਭ��� ᨬ��� �� �� DLE */
 {      
     if(ch==DLE) f_d=1; // �᫨ �ਭ�� ᨬ��� DLE ��⠭���� 䫠�
     else  in_buf[i++]=ch;  // ���� ᨬ��� ������� � ����
  }
 else  /* �᫨ 䫠�  DLE  ��⠭�����, �.�. �।��騩  */
 {                       /*�ਭ��� ᨬ��� ��  DLE */
         if(ch==DLE) // �᫨ �ਭ�� DLE, � �� ᨬ��� ������ 
         {  f_d=0; in_buf[i]=ch; i++;}// ������� � ��� � ���� 
         else  /* ᨬ��� ��᫥ DLE - �ࠢ���騩. ���, �ਭ�⮣� 
                     �ࠢ���饣� ᨬ���� ����ᨬ � ��६����� f1
         � ��ᨬ 䫠� �ਥ�� DLE */
        {  f_d=0; 
if(ch==ENQ)   f1=ENQ;
             if(ch==SOH) { f1=SOH;  i=0;}
             if(ch==ETB) { f1=ETB; }
             if(ch==ACK0) f1=ACK0;
             if(ch==ACK1) f1=ACK1;
  }   }
   outp (0x20,0x20);
}
void main(void)
{
 char ch;
 clrscr();         // ���⨬ �࠭
 init_port();    // ��⠭���� ��ࠬ���� COM ����
 set_vect();    //  ������� ����� ���뢠��� COM ����
init_ctrl();

printf("F1-start, ESC-exit\n");
   for(;;)
    {
       while(!kbhit())
       //�᫨ �� ����� ������� ������ �p���p塞 ᮤ�ন��� f1
        {
          // �᫨ �ਭ�� ENQ, ��諥� ���⢥ত���� ACK0 
          if(f1==ENQ)
                 {f1=0; printf("RECEIVE ENQ\n");
                  send_sym (DLE);send_sym (ACK0); }
         /* �᫨ �ਭ�� ACK0, ��।���� � ����� ����� ��������� 
             � �ࠢ���騬� ᨬ������ ��砫� � ���� ��������� */ 
           if(f1==ACK0)
                 { f1=0;printf("RECEIVE ACK0\n");
                    send_sym(DLE); send_sym(SOH);
                    for(i=0; i<6; i++)
                      {
                        send_sym(out_buf[i]);
                      }
                   send_sym(DLE); send_sym(ETB);
                 }
/* �᫨ �ਭ�� ETB, �뢥��� �� �࠭ ᮤ�ন��� �室���� ���� in_buf � ��諥� ���⢥ত���� ACK1*/ 
           if(f1==ETB)
                 { f1=0; printf("RECEIVE ETB\n");
                   for(i=0; i<6; i++) putch(in_buf[i]);
                   send_sym(DLE);  send_sym(ACK1);
                 }
            if(f1==ACK1)
                 { f1=0; printf("RECEIVE ACK1\n");}
        }
       //�᫨ ����� ������
           ch=getch();
            if(ch==27) return;
/* �᫨ ������ F1, � ��᫠�� ᨬ��� ENQ - ����� �� ��⠭������� �裡 */
            if(ch==59)    // ����� ������ F1
                 { send_sym (DLE);send_sym (ENQ);}
       }
}
