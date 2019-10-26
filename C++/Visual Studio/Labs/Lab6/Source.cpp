#include <iostream>
#include <string>
#include <fstream>

using namespace std;

int main()
{
	ifstream file("sport.txt");
	if (!file.is_open())
		return 0;
	//file <<"Ivanov"<< 1<<' '<< 34<< "Petrov"<< 2 << ' ' << 12 <<"Sidorov" <<3<< ' ' << 89<< "Zyrjanov"<< 4<< ' ' << 45;
	
	struct Sportsman
	{
		string surname;
		unsigned int number;
		unsigned int points;
	};

	
	Sportsman Sportsmans[4];
	//Sportsman Sportsmans[4] = { {"Ivanov", 1, 34},{ "Petrov", 2, 12 },{ "Sidorov", 3, 89 },{ "Zyrjanov", 4, 45 } };
	for(int i = 0;;i++)
	{
		if (file.eof())
			break;
		while(file.peek() < '0' || file.peek() > '9')
		Sportsmans[i].surname += file.get();
		file >> Sportsmans[i].number >> Sportsmans[i].points;
	}
	/*
	for (int i = 0; i < 4; i++)
	{
		cout << Sportsmans[i].surname << ' ' << Sportsmans[i].number << ' ' << Sportsmans[i].points << endl;
	}
	*/
	Sportsman* temp[3];
	Sportsman tmp = { "",0,0 };
	for (int i = 0; i < 3; i++)
	{
		temp[i]= &tmp;
	}

	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			if (Sportsmans[i].points > temp[j]->points)
			{
				temp[j] = &Sportsmans[i];
				break;
			}
		}
	}

	for (int i = 0; i < 3; i++)
	{
		cout << temp[i]->surname << ' ' << temp[i]->number << ' ' << temp[i]->points << endl;
	}

	cin.get();
	return 0;
}