#include <iostream>

using namespace std;

double equation();

int main()
{
	cout << equation() << endl;

	system("pause");
	return 0;
}

double equation()
{
	double fx(double);

	double fderivativex(double);

	double root = -1.0, nextroot = 0.0;

	while(1)
	{
		nextroot = root - (fx(root) / fderivativex(root));
		if (abs(nextroot - root) <= 0.0001) break;
		root = nextroot;
	}
	return nextroot;
}

double fx(double xk)
{
	return xk * xk * xk - 0.212 * xk * xk + 0.105;
}

double fderivativex(double xk)
{
	return 3*(xk * xk) - 0.424 * xk;
}

