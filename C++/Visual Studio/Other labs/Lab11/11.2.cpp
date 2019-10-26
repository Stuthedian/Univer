#include <iostream>
#include <vector>
#include <algorithm>
#include <iterator>

using namespace std;

int main()
{
	vector<int> v = { 22, 22, 31, 27, 11, 11, 20, 9 };

	//��������� ������ � ������� ��������, ��� ����� ������� � sort ������-�������
	sort(v.begin(), v.end(), 
		[](int a, int b){return a > b;});

	//������� �� ������� ���������� ��������. last ��������� �� ����� ����������� �������(����� ���� ���������)
	auto last = unique(v.begin(), v.end());

	//������� � ������� ostream_iterator �� ������� �������� �������, ����� 1-��(������ ��-�� ������������)
	//� ���������� (������ ��-�� �����������)
	copy(v.begin() + 1, last - 1, 
		ostream_iterator<int>(std::cout, " "));
	
	cin.get();
	return 0;
}