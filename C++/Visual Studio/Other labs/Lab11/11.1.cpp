#include <iostream>
#include <vector>
#include <algorithm>
#include <numeric>

using namespace std;

int main()
{
	vector<int> v = { 1, 22, 34, 23, 12, 34, 90, 0 };

	//Суммируем все элементы массива с помощью accumulate из  и делим на кол-во элементов
	//чтобы получить среднее арифметическое
	double sr_sum = accumulate(v.begin(), v.end(), 0) / (v.size() + 0.0);
	cout << sr_sum << endl;

	//Из каждого элемента вычитаем среднее арифметическое
	//для этого в функцию for_each 3-м параметром передаём лямбда-функцию
	for_each(v.begin(), v.end(), [sr_sum](int& n) { n -= sr_sum; });
	for (size_t i = 0; i < v.size(); i++)
	{
		cout << v[i] << "  ";
	}
	cout << endl;

	cin.get();
	return 0;
}


