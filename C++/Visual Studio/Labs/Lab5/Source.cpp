#include <iostream>
#include <iomanip>
#include <fstream>

using namespace std;

int main()
{
	ifstream text("cyrillic.txt", ios::binary);
	
	if (!text.is_open())
	{
		cout << "Error!\n";
		cin.get();
		return 0;
	}

	int filesize = 0, cp866 = 0, win1251 = 0, koi8_r = 0;

	text.seekg(0, ios::end);
	filesize = text.tellg();
	text.seekg(0, ios::beg);
	
	unsigned char* s = new unsigned char[filesize];
	text.read((char*)s, filesize);

	for (int i = 0; i < filesize; i++)
	{

		if ((s[i] >= 0x80 && s[i] <= 0xAF) || (s[i] >= 0xE0 && s[i] <= 0xEF))  cp866++;
		if ((s[i] == 0xA8 || s[i] == 0xB8) || (s[i] >= 0xC0 && s[i] <= 0xFF))  win1251++;
		if ((s[i] == 0xA3 || s[i] == 0xB3) || (s[i] >= 0xC0 && s[i] <= 0xFF))  koi8_r++;

	}

	cout.precision(4);
	cout << "Probability of cp866: " << ((cp866 + 0.0) / filesize) * 100 << '%' << endl;
	cout << "Probability of win1251: "<< ((win1251 + 0.0) / filesize) * 100 << '%' << endl;
	cout << "Probability of koi8_r: "<<((koi8_r + 0.0) / filesize) * 100 << '%' << endl;

	delete[] s;
	text.close();
	cin.get();
	return 0;
}