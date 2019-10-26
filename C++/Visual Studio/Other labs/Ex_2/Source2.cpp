#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	char fam[50];
	int site, wage, tempsite, numofworker = 0, midwage = 0;
	ifstream textfile("textfile.txt");
	if (!textfile.is_open())
	{
		cout << "Error opening" << endl;
		cin.get();
		return 0;
	}

	setlocale(LC_ALL, "Russian");
	cout << "Введите номер участка\n";
	cin >> tempsite;

	while (true)
	{
		if (textfile.eof())//проверяем, достигли конец файла или нет
		{
			cout << "Количество рабочих:\t" << numofworker << endl;
			cout << "Средняя зарплата:\t" << midwage / (numofworker + 0.0) << endl;
			break;
		}
		textfile >> fam >> site >> wage;
		if (site == tempsite)//если рабочий с требуемого участка, то увеличиваем счётчик рабочих и накапливаем сумму
		{
			cout << fam << endl;
			numofworker++;
			midwage += wage;
		}
	}

	cin.ignore(INT_MAX, '\n');
	cin.get();
	return 0;
}