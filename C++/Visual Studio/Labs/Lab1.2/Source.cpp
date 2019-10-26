#include <iostream>
#include <ctime>

using namespace std;

double yfromx(double);

double mathsum();

int main()
{
	const int size = 50;
	double xarray[size], yarray[size];

	double temp = mathsum();

	srand(time(NULL));

	for (int i = 0; i < size; i++)
	{
		xarray[i] = rand() % 100;
	}
	for (int i = 0; i < size; i++)
	{
		yarray[i] = yfromx(xarray[i])/temp;
		cout << yarray[i] << endl;
	}
	system("pause");
	return 0;
}

double yfromx(double xarrayelem)
{
	if (xarrayelem < 0) return log(abs(xarrayelem));
	else return xarrayelem + 0.7;
}

double mathsum()
{
	double sum = 0;
	for (int i = 1; i <= 10; i++)
	{
		sum += (i*i) / (i*i) + 1;
	}
	return sum;
}
