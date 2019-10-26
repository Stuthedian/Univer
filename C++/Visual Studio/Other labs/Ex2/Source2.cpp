#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	ifstream file("file.txt");
	int count = 0;
	double sum = 0.0, temp;
	while (1)
	{
		if (file.eof())
			break;
		file >> temp;
		sum += temp;
		count++;
	}
	file.seekg(ios::beg);
	int* arr = new int[count];
	for (int i = 0; i < count; i++)
	{
		file >> arr[i];
		if (abs((int)(sum / count) - arr[i]) <= 15)
			cout << arr[i] << '\n';
	}
	//cout << count << '\n' << (sum / count) << '\n';
	cin.get();
	return 0;
}