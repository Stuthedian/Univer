#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	ifstream input("input.txt");
	if (!input.is_open())
	{
		return 0;
	}
	ofstream output("output.txt", ios::trunc);
	int number, N, count = 0;
	double sum = 0.0;

	cin >> N;
	cin.ignore(INT_MAX, '\n');

	while (true)
	{
		input >> number;
		if (input.eof() && input.fail()) break;
		sum += number;
		count++;
	}
	sum /= count;
	input.clear();
	input.seekg(0, ios::beg);

	while (true)
	{
		input >> number;
		if (input.eof() && input.fail()) break;
		if (abs(number - sum) <= N)
			output << number << ' ';
	}


	cin.get();
	return 0;
}