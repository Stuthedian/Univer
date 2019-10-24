#include <stdio.h>
#include <conio.h>
#include <dos.h>
#define base  0x3F8  // ���� COM1

 char ctl,int_save;
     /* ������� �ணࠬ�� ��ࠡ�⪨ ���뢠��� */
void interrupt  receiv(void);
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
              /* *** ���樠������ ����஫�� ���뢠��� *** */
void init_ctrl()  {
     int_save = inp(0x21);
     outp(0x21,int_save & 0x0E7);
 }
/* ���. ������ ��ࠡ��稪� */
void set_vect()  
   {  setvect (0x0C, receiv); }
               /* *** ���� ��ࠡ��稪 *** */
void interrupt receiv() {
     char ch;
     unsigned   inp_reg, status_reg;
     status_reg = base+5;
     inp_reg = base+0;
  //   while( (inp(  status_reg) & 1) == 0);
     ch = inp(inp_reg);
// �뢮� �� �࠭
     //_AL = ch-1;  
     _AL = ch;
     _AH = 0x0E; _BX = 0;
     geninterrupt(0x10);
//�����襭�� �����⭮�� ���뢭��
     outp (0x20, 0x20);
 }
       /* *** �뢮� ᨬ���� � ���� *** */
void  send_sym (char ch)  {
 unsigned   out_reg, status_reg;
    status_reg = base+5;
    out_reg = base+0;
        while( (inp(status_reg) & 0x20) == 0);
    outp(out_reg, ch);
 }
             /* *** �᭮���� �ணࠬ�� *** */
void  main()  {
   char ch;
    set_vect();
    init_port();
    init_ctrl();
    printf ("\n ���樠������  COM-����  �ந�������.  ������  ���� �������...\n");
     while ((ch = getch())!=27)
     {    send_sym(ch); }
 }

