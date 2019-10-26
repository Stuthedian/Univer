#include <iostream>
#include <fstream>
#include <cctype>

using namespace std;

int main()
{
	ifstream file("file.txt");
	if (!file.is_open())
	{
		cout << "Error!" << endl;
		cin.get();
		return 0;
	}

	const int letters = 26*2, const offset = 'a';
	int latin[letters] = { 0 };
	char a = 0;

	while (true)
	{
		file.read(&a, 1);
		if (file.eof()) break;
		if (isalpha(a))
		{
			latin[a - offset]++;
		}
	}

	int max = -1;
	for (size_t i = 0; i < letters; i++)
	{
		if (latin[i] > max) max = latin[i];
	}

	for (size_t i = 0; i < letters; i++)
	{
		if (latin[i] == max) cout << (char)(i + offset) << endl;
	}
	
	cin.get();
	return 0;
}