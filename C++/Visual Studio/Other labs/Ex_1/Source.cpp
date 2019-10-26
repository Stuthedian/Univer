#include <iostream>
#include <cstring>

using namespace std;

char* charreplc(char*, int, char);

int main()
{
	int n = 5;//� ������ ������� �������� ������
	char s[50] = "Important information about ";
	char a = 'h';//���������� ������
	
	char* st = charreplc(s, n, a);
	if (st != NULL)//��� ��� ��� ������ ���� �������� ������ ���������� �
	{
		cout << st;
		delete[] st;
	}
		

	cin.get();
	return 0;
}

char * charreplc(char *string, int position, char replacer)
{
	char* replcpos = NULL;
	if (position >= 0 && (position + 1) <= strlen(string))
	{
		replcpos = new char[strlen(string) + 1];
		for (int i = 0; i < position; i++)//������� �������, ������� �� ����� �������� �� ������������ ������
		{
			replcpos[i] = string[i];
		}
		for (int i = position, temp = strlen(string); i < temp+1; i++)
		{
			if (isgraph(string[i]))//������� ������ � �������� ������� ���� �� �� �������� ��������
				replcpos[i] = replacer;
			else
				replcpos[i] = string[i];
		}
	}
	return replcpos;
}
