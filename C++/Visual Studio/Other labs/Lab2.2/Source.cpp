#include <iostream>
#include <ctime>

using namespace std;

int* vector(int);
int find(int* arr, int arr_size, int T1, int T2);
int main()
{
	int T1 = 50, T2 = 81;
	int* arr = vector(20);
	setlocale(LC_ALL, "Ru-ru");
	srand(time(NULL));
	
	cout << "\nНайти номер последнего минимального элемента среди элементов, меньших Т1["
		<< T1 << "]\nи лежащих правее первого элемента, равного  Т2["<< T2 <<"]:\n\t";
	int t = find(arr, 20, T1, T2);
	cout << "arr[" << t <<"] = " << arr[t];
	cin.get();
	delete[] arr;
	return 0;
}

int* vector(int sizeofarray)
{
	int* a = new int[sizeofarray];
	
	for (int i = 0; i < sizeofarray; i++)
	{
		a[i] = rand() % 100;
		cout << a[i] << "  ";
	}
	
	return a;
}

int find(int* arr, int arr_size, int T1, int T2)
{
	int i = 0;
	for (; i < arr_size; i++)
	{
		if (arr[i] == T2)
			break;
	}
	int** temp = new int*[2];
	temp[0] = new int[arr_size - i];
	temp[1] = new int[arr_size - i];
	int j = 0;
	for (; i < arr_size; i++)
	{
		if (arr[i] < T1)
		{
			temp[0][j] = arr[i];
			temp[1][j] = i;
			j++;
		}
	}
	int min = INT_MAX, pos = -1;
	for (int k = 0; k < j; k++)
	{
		if (temp[0][k] <= min)
		{
			min = temp[0][k];
			pos = temp[1][k];
		}
	}
	delete[] temp;
	return pos;
}