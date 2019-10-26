#include <iostream>
#include <fstream>
#include <cctype>

using namespace std;

int main()
{
	ifstream input("input.txt");
	if (!input.is_open()) return 0;
	ofstream output("output.txt", ios::trunc);

	char a = 0;
	while (true)
	{
		input.read(&a, 1);
		if (input.eof()) break;

		if (islower(a))
		{
			a = toupper(a);
			output.write(&a, 1);
		}
		else if (isdigit(a))
		{
			output << /*hex <<*/(int)a;
		}
		else output.write(&a, 1);;
	}


	cin.get();
	return 0;
}