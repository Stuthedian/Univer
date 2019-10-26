#include <iostream>
#include <cstring>

using namespace std;

char* charreplc(char*, int, char);

int main()
{
	int n = 5;//с какого символа начинаем замену
	char s[50] = "Important information about ";
	char a = 'h';//замен€ющий символ
	
	char* st = charreplc(s, n, a);
	if (st != NULL)//так как под строку была выделена пам€ть освобождаю еЄ
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
		for (int i = 0; i < position; i++)//копирую символы, которые не нужно замен€ть из оригинальной строки
		{
			replcpos[i] = string[i];
		}
		for (int i = position, temp = strlen(string); i < temp+1; i++)
		{
			if (isgraph(string[i]))//замен€ю символ с заданной позиции если он не €вл€етс€ пробелом
				replcpos[i] = replacer;
			else
				replcpos[i] = string[i];
		}
	}
	return replcpos;
}
