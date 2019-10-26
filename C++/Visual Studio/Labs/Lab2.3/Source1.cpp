#include <iostream>
#include <fstream>
using namespace std;

int main()
{
	char* lftostr(double, char*);
	double strtolf(char* s);

	char str[100];
	double number = 23.41;

	cout << lftostr(number,str) << endl;
	cout << strtolf(lftostr(number, str))+2 << endl;
	
	system("pause");
	return 0;
}

char* lftostr(double n,char* s)
{

	fstream file("test.txt", fstream::in | fstream::out | fstream::trunc);
	file << n;

	file.clear();
	file.seekg(0, ios::beg);

	file >> s;
	file.close();

	remove("test.txt");
	return s;
}

double strtolf( char* s)
{
	double d = -1.0;

	fstream file("test.txt", fstream::in | fstream::out | fstream::trunc);
	file << s;

	file.clear();
	file.seekg(0, ios::beg);

	file >> d;
	file.close();

	remove("test.txt");
	return d;
}