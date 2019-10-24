
//------------------------------------------------------------------------------
// SERVER.C 
//------------------------------------------------------------------------------
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <dir.h>
#include "ipx.h"

IPXADDRESS myaddress;

IPXECB recb;
IPXECB secb;

IPXHEADER rheader;
IPXHEADER sheader;

unsigned char rbuffer[80] = {0};
unsigned char sbuffer[100]={0};
unsigned char temp[20]={0};
struct ffblk ffblk;
int i;
int done;
int shift = 0;

//------------------------------------------------------------------------------
void main ( void )
{
    if(!ipxinit())
    {
        printf("IPX not installed\n");
        exit(1);
    }
    printf("ipxentry %08lX\n",ipxentry);
    printf("max packet size %u\n",ipxgetmaxpacketsize());

    ipxgetaddress(&myaddress);
    printf("%02X:%02X:%02X:%02X %02X:%02X:%02X:%02X:%02X:%02X\n",myaddress.netadd[0],myaddress.netadd[1],myaddress.netadd[2],myaddress.netadd[3],myaddress.nodeadd[0],myaddress.nodeadd[1],myaddress.nodeadd[2],myaddress.nodeadd[3],myaddress.nodeadd[4],myaddress.nodeadd[5]);

    myaddress.socket=0x4450;
    switch(ipxopensocket(0x00,&myaddress.socket))
    {
        case 0x00: // Success
            printf("Socket %04X\n",reverseword(myaddress.socket));
            break;
        case 0xFE:
            printf("Socket Table Full\n");
            exit(1);
        case 0xFF:
            printf("Socket Already Open\n");
            exit(1);
    }

    recb.socket=myaddress.socket;
    recb.esraddress=NULL;
    recb.fragcount=2;
    recb.fragaddr1=&rheader;
    recb.fragsize1=sizeof(IPXHEADER);
    recb.fragaddr2=rbuffer;
    recb.fragsize2=sizeof(rbuffer);
    ipxlistenforpacket(&recb);

 
    printf("Waiting for packet\n");
    while(!kbhit())
    {
        ipxrelenquishcontrol();
        if(!recb.inuse)
        {
            printf("Packet Received\n");
            printf("  from %02X:%02X:%02X:%02X  %02X:%02X:%02X:%02X:%02X:%02X\n",rheader.source.netadd[0],rheader.source.netadd[1],rheader.source.netadd[2],rheader.source.netadd[3],rheader.source.nodeadd[0],rheader.source.nodeadd[1],rheader.source.nodeadd[2],rheader.source.nodeadd[3],rheader.source.nodeadd[4],rheader.source.nodeadd[5]);
            printf("  from socket %04X\n",reverseword(rheader.source.socket));
            printf("%s",rbuffer);
	    break;
        }
    }
	if (rbuffer[0] == 'l' && rbuffer[1] == 's')
	{
		done = findfirst("*.*", &ffblk, 0);
		while(!done)
		{
			memcpy(sbuffer + shift, ffblk.ff_name, 13);
			done = findnext(&ffblk);
			shift += 13;
		}
	}
	else if (rbuffer[0] =='c' && rbuffer[1] =='d' && rbuffer[2] ==' ') {
                for (i=0; rbuffer[i+3] != '\n'; ++i){
                    temp[i] = rbuffer[i+3];
                }
                temp[i] = '\0';
                printf(temp);
		//chdir(rbuffer+3);
                if (chdir(temp) == -1) printf("Fail!");
                system(rbuffer);
                done = findfirst("*.*", &ffblk, 0);
		while(!done)
		{
			memcpy(sbuffer + shift, ffblk.ff_name, 13);
			done = findnext(&ffblk);
			shift += 13;
		}       
		//sbuffer = "cd'ed 2 new dir";
	}
        for(i=0; i<80; i++)
        {
                if(sbuffer[i] == '\0')
                                sbuffer[i] = ' ';
        }

	printf("\n I am sending an answer\n");

    for(i=0;i<4;i++) sheader.dest.netadd[i]=0x00;
    for(i=0;i<6;i++) sheader.dest.nodeadd[i]=rheader.source.nodeadd[i];//0xFF;
    for(i=0;i<6;i++) secb.immedaddr[i]=0xFF;
    sheader.dest.socket=rheader.source.socket;
    secb.socket=myaddress.socket;
    secb.esraddress=NULL;
    sheader.type=4;
    secb.fragcount=2;
    secb.fragaddr1=&sheader;
    secb.fragsize1=sizeof(IPXHEADER);
    secb.fragaddr2=sbuffer;
    secb.fragsize2=sizeof(sbuffer);
    ipxsendpacket(&secb);

    printf("Waiting for the transfer to finish\n");
    while(!kbhit())
    {
        ipxrelenquishcontrol();
        if(!secb.inuse)
        {
            printf("Packet sended\n");
            printf("  to  %02X:%02X:%02X:%02X  %02X:%02X:%02X:%02X:%02X:%02X\n",rheader.source.netadd[0],rheader.source.netadd[1],rheader.source.netadd[2],rheader.source.netadd[3],rheader.source.nodeadd[0],rheader.source.nodeadd[1],rheader.source.nodeadd[2],rheader.source.nodeadd[3],rheader.source.nodeadd[4],rheader.source.nodeadd[5]);
            printf("  to  socket %04X\n",reverseword(rheader.source.socket));
	    break;
        }
    }
   
   

 while(kbhit()) getch();
    ipxclosesocket(myaddress.socket);
}
