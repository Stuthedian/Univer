#include <iostream>
#include <fstream>
#include <cstring>

using namespace std;

int main()
{
	setlocale(LC_CTYPE, "Russian");//����� ��������� � �������
	ifstream textfile("textfile.txt");//��� ����
	char nomertelefona[8], famabon[50], mesyacplat[3], godplat[5];

	if (!textfile.is_open())//���������, ���������� �� ��
	{
		cout << "Error opening" << endl;
		cin.get();
		return 0;
	}

	char mesyac[3], god[5];

	cin >> mesyac >> god;

	while (true)//���������� � ����� ���� � ������ ��������
	{
		textfile >> nomertelefona >> famabon >> mesyacplat >> godplat;
		if (strcmp(mesyacplat, mesyac) == 0 && strcmp(godplat, god) == 0)//���������, ���� ����. �������
			cout << famabon << endl;
		if (textfile.eof())//���������, �� ����� �� ����� �����
		{
			break;
		}
	}


	cin.ignore(INT_MAX, '\n');
	cin.get();
	return 0;
}