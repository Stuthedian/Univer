#include <stdio.h>
#include <conio.h>
#include <winsock.h>
#include <process.h>
#include <direct.h>
#include <dos.h>
#include <Windows.h>
#pragma comment(lib, "ws2_32.lib")
#ifndef SD_SEND
#define SD_SEND 1
#endif

int WinSockInit();
void WinSockClose();
void stopTCP(SOCKET s);
const short TalkPort = 83; // ѕорт сокета
const short MaxConn = 1;   // ћаксимальное колличество соединений

int main(int argc, char *argv[])
{
	if (argc == 1) { printf("Usage: TALK <host name>\nFor example: talk cyber_1\ntalk 62.76.77.141"); return -1; }
	if (WinSockInit()) { WinSockClose(); return -2; }
	SOCKET lsock;
	if ((lsock = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP)) == INVALID_SOCKET)
	{
		printf("Talk: Error creating listening socket.. Error %d\n", WSAGetLastError());
		//free(bs);
		WinSockClose();
		return -6;
	}
	else printf("Talk: Listening socket [%ld] created..\n", lsock);
	
	SOCKADDR_IN sin;//параметры сервера
	hostent* hp;
	if ((hp = gethostbyname(argv[1])) == NULL)
	{
		printf("Talk: Unknown host name '%s'\n", argv[1]);
		WinSockClose();
		return -4;
	}

	else
	{
		memset((char *)&sin, 0, sizeof(sin));
		//memcpy((char *)&sin.sin_addr, hp->h_addr, hp->h_length); // IP адрес
		sin.sin_family = hp->h_addrtype; // “ип адреса
		sin.sin_port = htons(TalkPort);  // ѕорт сокета
		//sin.sin_family = PF_INET;//протокол tcp/ip
		//sin.sin_port = TalkPort;//порт
		sin.sin_addr.s_addr = INADDR_ANY;//ждать соединение с любым адресом
	}
	

	if (bind(lsock, (struct sockaddr*) &sin, sizeof(sin)))
	{
		printf("Talk: Error binding to port (%d).. Error %d\n", TalkPort, WSAGetLastError());
		//free(bs);
		WinSockClose();
		return -7;
	}
	else printf("Talk: Port (%d) bound to socket [%ld] for talk service..\n", TalkPort, lsock);
	if (listen(lsock, MaxConn))
	{
		printf("Talk: Error listening on socket.. Error %d\n", WSAGetLastError());
		//free(bs);
		WinSockClose();
		return -8;
	}
	else printf("Talk: Now listening on socket [%ld] for incoming connections..\n", lsock);
	printf("Waiting for client connection...\n");
	SOCKADDR_IN from;
	int fromlen = sizeof(from);
	SOCKET client = accept(lsock, (struct sockaddr*)&from, &fromlen);//ожидаем запросы клиента
	if (client == INVALID_SOCKET)
	{
		if (WSAGetLastError() != WSAEINPROGRESS)
		{
			printf("Talk: Interrupt detected, Closing.. Result (%d)\n", WSAGetLastError());
			//free(bs);
			stopTCP(lsock);
			WinSockClose();
			return -9;
		}
	}
	printf("Client is connected\n");
	

	while (true)
	{
		char b[256];
		printf("Waiting client command...\n");
		recv(client, b, sizeof(b), 0);
		printf("Received: %s\n", b);
		if (b[0] == 'c' && b[1] == 'd' && b[2] == ' ')
		{
			if (SetCurrentDirectory(b + 3))
				_getcwd(b, sizeof(b));
			else
				strcpy_s(b, "Unrecognized path");
		}
		else if (strcmp(b, "bye") == 0)
		{
			printf("Ending session...");
			shutdown(client, 2);
			closesocket(client);
			shutdown(lsock, 2);
			closesocket(lsock);
			printf("Session is over");
			_getch();
			break;
		}
		else strcpy_s(b, "Unrecognized command");
		printf("Sending response...\n");
		send(client, b, sizeof(b), 0);
	}
	return 0;
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
	shutdown(s, SD_SEND); // ќстановка передачи данных
	closesocket(s); //  «акрытие сокета
	printf("Socket %ld closed.\n", s);
}