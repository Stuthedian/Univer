#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	char buf[40];
	ifstream f1("f1.txt");
	ofstream f2("f2.txt");
	if (!f1)
		cout << "Cannot open f1!\n";
	if (!f2)
		cout << "Cannot open f2!\n";
	int count = 1;
	while (1)
	{
		if (f1.eof())
			break;
		f1.getline(buf, 40);
		f2 << count << ' ' << buf << '\n';
		count++;
	}
	
	
	return 0;
}