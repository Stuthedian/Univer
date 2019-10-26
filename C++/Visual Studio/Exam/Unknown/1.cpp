#include <iostream>
#include <ctime>

using namespace std;

int* maxrow(int** M, int rows, int columns);
int* mincolumn(int** M, int rows, int columns);

int main()
{
	int n = 0, m = 0;
	cin >> n >> m;

	srand(time(NULL));
	int** Dmatrix = new int*[n];
	for (int i = 0; i < n; i++)
	{
		Dmatrix[i] = new int[m];
		for (int j = 0; j < m; j++)
		{
			Dmatrix[i][j] = rand() % 25;
			cout << Dmatrix[i][j] << ' ';
		}
		cout << endl;
	}
	cout << endl;

	int* rows = maxrow(Dmatrix, n, m);
	int* columns = mincolumn(Dmatrix, n, m);
	/*
	for (int i = 0; i < n; i++)
	{
		cout << rows[i] << ' ';
	}
	cout << endl;

	for (int i = 0; i < m; i++)
	{
		cout << columns[i] << ' ';
	}
	//int sedlo = 0;
	cout << endl;
	*/
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			if (Dmatrix[i][j] == rows[i] && Dmatrix[i][j] == columns[j])
				cout << Dmatrix[i][j] << endl;
		}
	}
	//cout << sedlo;

	cin.ignore(INT_MAX, '\n');
	cin.get();
	return 0;
}

int* maxrow(int** M, int rows, int columns)
{
	int* t = new int[rows];

	for (int i = 0; i < rows; i++)
	{
		t[i] = INT_MIN;
		for (int j = 0; j < columns; j++)
		{
			if (M[i][j] > t[i])	t[i] = M[i][j];
		}
	}

	return t;
}

int* mincolumn(int** M, int rows, int columns)
{
	int* t = new int[columns];

	for (int i = 0; i < columns; i++)
	{
		t[i] = INT_MAX;
		for (int j = 0; j < rows; j++)
		{
			if (M[j][i] < t[i])	t[i] = M[j][i];
		}
	}

	return t;
}