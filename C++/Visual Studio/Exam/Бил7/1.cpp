#include <iostream>
#include <cstring>

using namespace std;

char* charreplc(char*, int, char);

int main()
{
	int n;
	char s[50] = "Important information about "; 
	

	char a = cin.get();
	cin >> n;

	//charreplc(s, n, a);

	cout << charreplc(s, n, a);
	//cout << s;

	cin.ignore(INT_MAX,'\n');
	cin.get();
	return 0;
}

char * charreplc(char *string, int position, char replacer)
{
	char* replcpos = "";
	if (position >= 0 && (position + 1) <= strlen(string))
	{
		replcpos = string + position;
		for (int i = position, temp = strlen(string); i < temp; i++)
		{
			if (isgraph(string[i]))
				string[i] = replacer;
		}
	}
	return replcpos;
}
