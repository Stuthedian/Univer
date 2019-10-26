#include <iostream>
#include <vector>
#include <algorithm>
#include <iterator>

using namespace std;

int main()
{
	vector<int> v = { 22, 22, 31, 27, 11, 11, 20, 9 };

	//Сортируем массив в порядке убывания, для этого передаём в sort лямбда-функцию
	sort(v.begin(), v.end(), 
		[](int a, int b){return a > b;});

	//Выбрали из массива уникальные элементы. last указывает на конец уникального массива(далее идут дубликаты)
	auto last = unique(v.begin(), v.end());

	//Выводим с помощью ostream_iterator на консоль элементы массива, кроме 1-го(кторый яв-ся максимальным)
	//и последнего (кторый яв-ся минимальным)
	copy(v.begin() + 1, last - 1, 
		ostream_iterator<int>(std::cout, " "));
	
	cin.get();
	return 0;
}