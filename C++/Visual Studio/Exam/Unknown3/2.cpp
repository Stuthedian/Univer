#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main()
{
	ifstream listing("listing.txt");
	if (!listing.is_open())
	{
		cout << "Error!" << endl;
		cin.get();
		return 0;
	}
	ofstream outputwithcomments("output.txt", ios::trunc);

	char a;
	while (true)
	{
		listing.read(&a, 1);
		if (listing.eof()) break;
		if (a != '/') continue;
		listing.read(&a, 1);
		if (listing.eof()) break;
		if (a != '*') continue;
		listing.unget().unget();
		while (true)
		{
			listing.read(&a, 1);
			if (listing.eof()) break;
			outputwithcomments.write(&a, 1);
			if (a != '*') continue;
			listing.read(&a, 1);
			outputwithcomments.write(&a, 1);
			if (listing.eof()) break;
			if (a != '/') continue;
			break;
		}
		if (listing.eof()) break;
	}
	cin.get();
	return 0;
}