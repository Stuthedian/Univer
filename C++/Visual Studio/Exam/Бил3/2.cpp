#include <iostream>
#include <fstream>
#include <cctype>

using namespace std;

int main()
{
	bool notemptyline = false;
	ifstream textfile("textfile.txt");
	int buf = 0, linebeg = 0, temp = 0;
	char b = 0;

	if (!textfile.is_open())
	{
		cout << "Error opening" << endl;
		cin.get();
		return 0;
	}
	
	while (1)
	{
		temp = textfile.tellg();
		b = textfile.get();
		if (textfile.eof()) break;
		if (notemptyline == false && isgraph(b))
		{
			notemptyline = true;
			linebeg = (int)textfile.tellg() - 1;
		}
			
		if (b == '\n')
		{
			buf += (notemptyline?(temp + 1) - linebeg:0);
			notemptyline = false;
			linebeg = 0;
		}
	}
	if (notemptyline)
	{
		buf += temp - linebeg;
	}
	
	cout << "Buf  " << buf << endl;
	
	cin.get();
	return 0;
}