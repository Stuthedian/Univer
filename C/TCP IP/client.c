#include <stdio.h>
#include <conio.h>
#include <winsock.h>
#include <process.h>
#include <dos.h>
#pragma comment(lib, "ws2_32.lib")
#ifndef SD_SEND
#define SD_SEND 1
#endif

int WinSockInit();
void WinSockClose();
void stopTCP(SOCKET s);
const short TalkPort = 83; // Порт сокета

int main(int argc, char *argv[])
{
	if (argc == 1) { printf("Usage: TALK <host name>\nFor example: talk cyber_1\ntalk 62.76.77.141"); return -1; }
	if (WinSockInit()) { WinSockClose(); return -2; }
	SOCKET client;
	hostent *hp;
	sockaddr_in sock;
	if ((client = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP)) == INVALID_SOCKET)
	{
		printf("Talk: Error creating socket.. Error %d\n", WSAGetLastError());
		//free(bs);
		WinSockClose();
		return -6;
	}
	else printf("Talk: Socket [%ld] created..\n", client);

	if ((hp = gethostbyname(argv[1])) == NULL)
	{
		printf("Talk: Unknown host name '%s'\n", argv[1]);
		WinSockClose();
		return -4;
	}
	else
	{
		//sock.sin_family = PF_INET;//протокол tcp/ip
		//sock.sin_port = TalkPort;//порт
		//sock.sin_addr.s_addr = 0;//ждать соединение с любым адресом
		memset((char *)&sock, 0, sizeof(sock));
		memcpy((char *)&sock.sin_addr, hp->h_addr, hp->h_length); // IP адрес
		sock.sin_family = hp->h_addrtype; // Тип адреса
		sock.sin_port = htons(TalkPort);  // Порт сокета
		printf("Talk: Trying to connect to %d.%d.%d.%d\n", 
			(u_char)hp->h_addr[0], (u_char)hp->h_addr[1], (u_char)hp->h_addr[2], (u_char)hp->h_addr[3]);
	}

	if (connect(client, (struct sockaddr*) &sock, sizeof(sock)))
	{
		printf("Talk: Server not found... ");
		stopTCP(client);
		WinSockClose();
		return -4;
	}
	else printf("Talk: Connected to %d.%d.%d.%d\n", 
		(u_char)hp->h_addr[0], (u_char)hp->h_addr[1], (u_char)hp->h_addr[2], (u_char)hp->h_addr[3]);

		char b[1000] = "tera nova";
	while (true)
	{
		printf("Enter command...\n");
		fgets(b, 1000, stdin);
		char *pos;
		if ((pos = strchr(b, '\n')) != NULL)
			*pos = '\0';
	/*	if (strcmp(b, "bye") == 0 || strcmp(b, "exit") == 0)
			break;*/
		printf("Sending to server ...\n");
		send(client, b, sizeof(b), 0);
		//Sleep(2000);
		printf("Waiting server response...\n");
		recv(client, b, sizeof(b), 0);
		//printf("error: %d", WSAGetLastError());
		printf("Received: %s\n", b);	
	}
	
}

int WinSockInit()
{
	WORD wVersionRequested;
	WSADATA wsaData;

	wVersionRequested = MAKEWORD(2, 0);

	printf("Starting winsock...");

	if (WSAStartup(wVersionRequested, &wsaData) != 0)
	{
		printf("\nError : Couldn't find a usable winsock Dll\n");
		return 1;
	}

	if (LOBYTE(wsaData.wVersion) != 2 || HIBYTE(wsaData.wVersion) != 0)
	{
		printf("\nError : Couldn't find a usable WinSock DLL\n");
		WSACleanup();
		return 1;
	}
	printf(" Winsock started.\n");
	return 0;
}

void WinSockClose()
{
	WSACleanup();
	printf("WinSock Closed...\n");
}

void stopTCP(SOCKET s)
{
	shutdown(s, SD_SEND); // Остановка передачи данных
	closesocket(s); //  Закрытие сокета
	printf("Socket %ld closed.\n", s);
}