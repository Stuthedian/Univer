#include <iostream>
#include <string>

using namespace std;

int main()
{
	setlocale(LC_ALL, "Ru-ru");
	struct Student
	{
		string fam;
		string fakultet;
		unsigned int god_rozhd;
		unsigned int kurs;
	};

	Student Stud[7] = { 
		{ "������","FIIT",1997,3},
		{ "������","AGF",1998,2},
		{ "���������","SF",1998,2},
		{ "�������","IEF",1996,4},
		{ "����������","AGF",1998,2},
		{ "�������","FVZO",1999,1},
		{ "�����","AGF",2000,1},
	};

	int count = 0;
	cout << "�������\t���������\t��� ��������\t����\n";
	for (size_t i = 0; i < 7; i++)
	{
		if ((2018 - Stud[i].god_rozhd) >= 17
			&& (2018 - Stud[i].god_rozhd) <= 19)
		{
			count++;
			cout << Stud[i].fam << "\t" << Stud[i].fakultet << "\t" <<
				Stud[i].god_rozhd << "\t" << Stud[i].kurs << '\n';
		}
	}
	cout << "���������� ��������� � �������� �� 17 �� 19 ���: " << count;
	cin.get();
	return 0;
}