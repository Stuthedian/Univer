#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <fstream>
#include <cstring>

using namespace std;

bool comparestr(char*, char*);

int main()
{
	ifstream textfile("textfile.txt");
	char abonent[50], number[8], query[8];

	if (!textfile.is_open())
	{
		cout << "Error opening" << endl;
		cin.get();
		return 0;
	}

	cin >> query;
		
	while (true)
	{
		textfile >> abonent >> number;
		if (textfile.eof())
		{
			break;
		}
			
		
		if (comparestr(number, query))
			cout << abonent << '\t' << number << endl;
		
	}
	
	
	cin.ignore(INT_MAX,'\n');
	cin.get();
	return 0;
}

bool comparestr(char *string, char *mask)
{
	char buf[50];
	int len = strlen(mask);
	while ((*(string + len) != '\0') || (*string != '\0'))
	{
		strncpy(buf, string, len);
		buf[len] = '\0';
		if (!strcmp(buf, mask))
			return true;
		string++;
	}
	return false;
}
