#include <iostream>
#include <fstream>
#include <cctype>
#include <string>

using namespace std;

int main()
{
	const int offset = 'a', latin = 26;
	int numberofchars = 0;
	double latinletter[latin] = { 0 }, max = 0;
	char b = 0;
	ifstream textfile("textfile.txt");
	string line;
	

	if (!textfile.is_open())
	{
		cout << "Error opening" << endl;
		cin.get();
		return 0;
	}
	
	
	while (!textfile.eof())
	{
		b = textfile.get();
		(isgraph(b) ? numberofchars++ : 0);
	}
	
	textfile.clear();
	textfile.seekg(0, textfile.beg);
	
	getline(textfile, line);

	for (int i = 0, temp=line.size(); i < temp; i++)
	{
		b = line[i];
		(isalpha(b) && islower(b) ? latinletter[b - offset]++ : 0);
	}
		

	for (int i = 0; i < latin; i++)
	{
		latinletter[i] = (latinletter[i] / numberofchars) * 100;
	}
	
	for (int i = 0; i < latin; i++)
	{
		if (latinletter[i] > max)
			max = latinletter[i];
	}
	 
	for (int i = 0; i < latin; i++)
	{
		if (latinletter[i] == max)
		{
			cout << "Letter:" << (char)(offset + i) << "\tPercentage:" << latinletter[i] << "%\n";
			cin.get();
			return 0;
		}
	}
	
	cin.get();
	return 0;
}