#include <iostream>
#include <ctime>

using namespace std;

int main()
{
	int size;
	int* vector(int);
	int findmax(int*, int);


	srand(time(NULL));
	cin >> size;

	cout<<'\t'<<findmax(vector(size), size)<<endl;

	system("pause");
	return 0;
}

int* vector(int sizeofarray)
{
	int* a = new int [(sizeofarray <= 1? sizeofarray = 0: sizeofarray)];

	if (a == 0) sizeofarray = 0;

	for (int i = 0; i < sizeofarray; i++)
	{
		a[i] = rand() % 100;
		cout << a[i] << endl;
	}
	//delete [] a;
	return a;
}

int for3(int* a, int sizeofarray)
{
	for (int i = 0; i < sizeofarray; i++)
	{
		if (a[i] % 3 == 0) return i;
	}
	return -1;
}

int findmax(int* a, int sizeofarray)
{
	int temp = INT_MIN, number = -1;
	
	int index = for3(a, sizeofarray);

	if (index == -1)
	{
		delete[] a;
		return number;
	}


	for (int i = index + 1; i < sizeofarray - (index + 1); i++)
	{
		if (a[i] < a[1] && a[i] > temp)
		{
			temp = a[i];
			number = i;
		}
	}
	delete[] a;
	return number;
}