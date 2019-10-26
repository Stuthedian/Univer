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
		{ "Иванов","FIIT",1997,3},
		{ "Петров","AGF",1998,2},
		{ "Лермонтов","SF",1998,2},
		{ "Сидоров","IEF",1996,4},
		{ "Чайковский","AGF",1998,2},
		{ "Толстой","FVZO",1999,1},
		{ "Чехов","AGF",2000,1},
	};

	int count = 0;
	cout << "Фамилия\tФакультет\tГод рождения\tКурс\n";
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
	cout << "Количество студентов в возрасте от 17 до 19 лет: " << count;
	cin.get();
	return 0;
}