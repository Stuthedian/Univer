#include <iostream>
#include <ctime>

using namespace std;

double arithmmiddle(int* vector, int length);

int main()
{
	int number;
	int* X;

	cin >> number;
	if (number < 1) return 1;

	X = new int[number];
	srand(time(NULL));

	for (size_t i = 0; i < number; i++)
	{
		X[i] = rand() % 100;
	}

	cout << arithmmiddle(X, number) << endl;

	cin.ignore(INT_MAX, '\n');
	cin.get();
	return 0;
}

double arithmmiddle(int* vector, int length)
{
	double sum = 0.0;

	for (size_t i = 0; i < length; i++)
	{
		sum += vector[i];
	}

	return sum / length;
}