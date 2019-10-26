#include <iostream>
//strcmp – сравнение двух строк, учитывая регистр символов
using namespace std;

int strcmp_(char* s1, char* s2);
/*
-1 если левая строка стоит раньше правой в алфавитном порядке
0 если равны
1 если левая строка стоит после правой в алфавитном порядке
*/

int strcmp_(const char * s1, const char * s2)
{
	size_t i = 0;
	for (; s1[i] != '\0' || s2[i] != '\0'; i++)
	{
		if (s1[i] != s2[i])
		{
			if (s1[i] > s2[i])
				return 1;
			else
				return -1;
		}
	}
	if(s1[i] == '\0' && s2[i] == '\0')
		return 0;
	else
	{
		if (s1[i] != '\0' && s2[i] == '\0')
			return 1;
		else
			return -1;
	}
}


int main()
{
	cout << int(0.9999999);
	cin.get();
	return 0;
}