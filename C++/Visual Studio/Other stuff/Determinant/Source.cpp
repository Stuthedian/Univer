#include <iostream>

using namespace std;

int main() 
{
	int det(int, int, int**);
	const int m = 4, n = 4;
	int shiet[m][n]=
	{
		{ 3, 2,  3, 5},
		{ 8, 1,  2, 0},
		{ 0, 5,  3, 4},
		{ 6, 6, 10, 7},
	};
	
	int** matrix = new int*[m];
	for (int i = 0; i < m; i++)
	{
		matrix[i] = new int[n];
	}
	

	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			matrix[i][j] = shiet[i][j];
		}
	}
	
	cout << det(m, n, matrix)<<endl;

	for (int i = 0; i < m; i++)
		delete[] matrix[i];
	delete[] matrix;

	system("pause");
	return 0;
}

int det(int m, int n, int **a)
{
	if (m == 2)
	{
		return a[0][0] * a[1][1] - a[0][1] * a[1][0];
	}
	else
	{
	int** submatrix(int , int , int , int**);
	int mathsum = 0;
	int** temp = NULL;

		for (int j = 0; j < n; j++)
		{
			mathsum += ((int)pow(-1, j + 2)) * a[0][j] * det(m-1,n-1,temp=submatrix(m-1,n-1,j,a));
			for (int i = 0; i < n - 1; i++)
				delete[] temp[i];
			delete[] temp;
		}
		return mathsum;
	}
}

int** submatrix(int m1, int n1, int jbad, int **a)
{
	int** minor = new int* [m1];
	for (int i = 0; i < m1; i++)
	{
		minor[i] = new int[n1];
	}

	for (int i = 1,im = 0; i < m1 + 1; i++, im++)
	{
		for (int j = 0,jm = 0; j < n1 + 1; j++)
		{
			if (j != jbad)
			{
				minor[im][jm++] = a[i][j];
			}
		}
	}
	return minor;
}
