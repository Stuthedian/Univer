#include <locale.h>
#include <map>
#include <string>
#include <sstream>
#include <fstream>
#include <iostream>
#include <vector>
#include <Windows.h>


using namespace std;

class translate
{
public:
	translate(const char* path)
	{
		stringstream ss;
		string en, ru, buff;
		ifstream fin(path, ios::in | ios::binary);
		while (!fin.eof())
		{
			getline(fin, buff);
			ss << buff;
			ss >> en;
			while (!ss.eof())
			{
				ss >> ru;
				enru.insert(make_pair(en, ru));
				ruen.insert(make_pair(ru, en));
			}
			ss.clear(ios::goodbit);
		}
	}
	~translate() {}
	void show_words()
	{
		int entrycount = 0;
		for (auto i = enru.begin(); i != enru.end();)
		{
			cout << i->first;
			auto rslt = enru.equal_range(i->first);
			for (auto j = rslt.first; j != rslt.second; j++)
			{
				cout << "\t" << j->second;
			}
			i = rslt.second;
			cout << endl;
			entrycount++;
			if (entrycount == 10)
			{
				system("pause");
				entrycount = 0;
			}
		}
	}
	void eng_to_ru(string word)
	{
		bool found = false;
		for (auto i = enru.begin(); i != enru.end();)
		{
			if (i->first.find(word) != string::npos)
			{
				found = true;
				auto rslt = enru.equal_range(i->first);
				cout << rslt.first->first;
				for (auto i = rslt.first; i != rslt.second; ++i)
				{
					cout << "\t" << i->second;
				}
				cout << endl;
				i = rslt.second;
			}
			else i++;
		}
		if (!found)
		{
			cout << "ѕеревод отсутствует!\n";
			return;
		}
		/*auto rslt = enru.equal_range(word);
		if (enru.count(word) == 0)
		{
			cout << "ѕеревод отсутствует!\n";
			return;
		}
		cout << rslt.first->first;
		for (auto i = rslt.first; i != rslt.second; ++i)
		{
			cout << "\t" << i->second;
		}
		cout << endl;*/
	}
	void ru_to_eng(string word)
	{
		auto rslt = ruen.find(word);
		if (rslt != ruen.end())
		{
			cout << rslt->first << "\t" << rslt->second << endl;
		}
		else
		{
			cout << "ѕеревод отсутствует!\n";
		}
	}
private:
	multimap<string, string> enru;
	map<string, string> ruen;
};

int main()
{
	//setlocale(LC_CTYPE, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	bool flag = true;
	translate dictionary("словарь.txt");
	string buff;
	char choice = 0;

	while (flag)
	{
		cout << "1) показать слова\n"
			<< "2) перевод анг на рус\n"
			<< "3) перевод рус на анг\n"
			<< "4) выйти из программы\n";
		choice = cin.get();
		cin.ignore(INT_MAX, '\n');
		switch (choice)
		{
		case '1':
		{
			dictionary.show_words();
		}
		break;
		case '2':
		{
			cout << "¬ведите слово дл€ перевода:\n";
			cin >> buff;
			cin.ignore(INT_MAX, '\n');
			dictionary.eng_to_ru(buff);
		}
		break;
		case '3':
		{
			cout << "¬ведите слово дл€ перевода:\n";
			cin >> buff;
			cin.ignore(INT_MAX, '\n');
			dictionary.ru_to_eng(buff);
		}
		break;
		case '4': flag = false; break;
		default: break;
		}
	}
	system("pause");
	return 0;
}