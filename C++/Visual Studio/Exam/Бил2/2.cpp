#include <iostream>
#include <fstream>
#include <cstring>

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "Russian");//Вывод кириллицы в консоль
	ifstream textfile("textfile.txt");//Наш файл
	char nomertelefona[8], famabon[50], mesyacplat[3], godplat[5];

	if (!textfile.is_open())//Проверяем, существует ли он
	{
		cout << "Error opening" << endl;
		cin.get();
		return 0;
	}

	char mesyac[3], god[5];

	cin >> mesyac >> god;

	while (true)//Выдёргиваем в цикле инфу о каждом абоненте
	{
		textfile >> nomertelefona >> famabon >> mesyacplat >> godplat;
		if (strcmp(mesyacplat, mesyac) == 0 && strcmp(godplat, god) == 0)//Проверяем, дату посл. платежа
			cout << famabon << endl;
		if (textfile.eof())//Проверяем, не вышли за конец файла
		{
			break;
		}
	}


	cin.ignore(INT_MAX, '\n');
	cin.get();
	return 0;
}