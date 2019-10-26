#include <iostream>
#include <string>
#include <fstream>
#include <locale>

using namespace std;

struct Sportsman
{
	unsigned int number;
	string surname;
	unsigned int points;
	Sportsman *next = nullptr;
};

Sportsman * getfromfile(string path);
void show(Sportsman *&begin);
void push_back(Sportsman *to, const Sportsman &from);
void delete_(Sportsman *&begin, unsigned int number);
void edit(Sportsman *begin, unsigned int number);
void sort(Sportsman *&begin);
bool pkfind(Sportsman *begin, unsigned int number);

int main()
{
	setlocale(LC_CTYPE, "ru-RU");
	Sportsman *S = getfromfile("sport.txt");

	for (char a = CHAR_MAX; a && S;)
	{
		cout << "\n[1] — Просмотр списка\n[2] — Добавление элемента\n"
			<< "[3] — Редактирование элемента\n[4] — Удаление элемента" << endl << ">>";
		cin >> a;
		cin.ignore(INT_MAX, '\n');
		switch (a)
		{
		case '1':show(S); break;
		case '2':
		{
			Sportsman n;
			cout << "Введите данные в формате: Номер Фамилия Очки" << endl << ">>";
			cin >> n.number >> n.surname >> n.points;
			if (cin.fail())
			{
				cin.clear();
				cin.ignore(INT_MAX, '\n');
				cout << "Некорректный ввод. Операция отменена" << endl;
				break;
			}
			else cin.ignore(INT_MAX, '\n');
			push_back(S, n);
		}break;
		case '3':
		{
			unsigned int n;
			cout << "Введите номер для редактирования" << endl << ">>";
			cin >> n;
			if (cin.fail())
			{
				cin.clear();
				cin.ignore(INT_MAX, '\n');
				cout << "Некорректный ввод. Операция отменена" << endl;
				break;
			}
			else cin.ignore(INT_MAX, '\n');
			edit(S, n);
		}break;

		case'4':
		{
			unsigned int n;
			cout << "Введите номер для удаления" << endl << ">>";
			cin >> n;
			if (cin.fail())
			{
				cin.clear();
				cin.ignore(INT_MAX, '\n');
				cout << "Некорректный ввод. Операция отменена" << endl;
				break;
			}
			else cin.ignore(INT_MAX, '\n');
			delete_(S, n);
		}break;
		
		default:a = 0; break;
		}
	}
	

	cout << endl << "Для выхода нажмите Enter" << endl;
	cin.get();
	return 0;
}

Sportsman * getfromfile(string path)
{
	ifstream file(path);
	if (!file.is_open())
		return nullptr;
	Sportsman *begin = nullptr, *current = nullptr, *previous = nullptr;
	while (true)
	{
		current = new Sportsman;
		file >> current->surname >> current->number >> current->points;
		if (file.eof())
		{
			if (current->surname.size() > 0)
			{
				if (pkfind(begin, current->number) == true)
				{
					cout << "Конфликт первичного ключа PK______"<<current<<"\n"
						<< "Запись из входного файла\"" << current->number << ' '
						<< current->surname << ' ' << current->points << "\"пропущена" << endl << endl;
					delete current;
					break;
				}
				if (begin == nullptr) begin = current;
				else previous->next = current;
			}
			else delete current;
			break;
		}
		if (pkfind(begin, current->number) == true)
		{
			cout << "Конфликт первичного ключа PK______" << current << "\n"
				<< "Запись из входного файла\"" << current->number << ' '
				<< current->surname << ' ' << current->points << "\"пропущена" << endl << endl;
			delete current;
		}
		else
		{
			if (begin == nullptr) begin = current;
			else previous->next = current;
			previous = current;
		}
	}
	file.close();
	return begin;
}

void show(Sportsman *&begin)
{
	sort(begin);
	Sportsman *temp = begin;
	while(temp)
	{
		cout << temp->number << ") " << temp->surname << ", очков: " << temp->points << endl;
		temp = temp->next;
	}
	cout << endl;
}

void push_back(Sportsman * to, const Sportsman & from)
{
	Sportsman *previous = nullptr, *temp = nullptr;
	if (pkfind(to, from.number) == true)
	{
		cout << "Конфликт первичного ключа PK______" << &from <<"!Операция отменена" << endl;
		return;
	}
	while (to)
	{
		previous = to;
		to = to->next;
	}
	temp = new Sportsman;
	temp->number = from.number;
	temp->surname = from.surname;
	temp->points = from.points;

	previous->next = temp;
}

void delete_(Sportsman *& begin, unsigned int number)
{
	bool founded = false;
	Sportsman *previous = nullptr, *head = begin;
	while (head)
	{
		if (head->number == number)
		{
			founded = true;
			if (previous != nullptr)
			{
				previous->next = head->next;
			}
			else 
			{
				begin = head->next;
			}
				delete head;
				break;
		}
		else
		{
			previous = head;
			head = head->next;
		}
	}
	if (!founded) cout << "Данный элемент не найден" << endl;
}

void edit(Sportsman * begin, unsigned int number)
{
	bool founded = false;
	Sportsman temp;
	while (begin)
	{
		if (begin->number == number)
		{
			founded = true;
			cout << begin->number << ") " << begin->surname << ", очков: " << begin->points << endl;
			cout << "Введите новые данные в формате: Номер Фамилия Очки" << endl << ">>";
			cin >> temp.number >> temp.surname >> temp.points;
			if (cin.fail())
			{
				cin.clear();
				cin.ignore(INT_MAX, '\n');
				cout << "Некорректный ввод. Операция отменена" << endl;
				return;
			}
			else cin.ignore(INT_MAX, '\n');
			if (begin->number != temp.number && pkfind(begin, temp.number) == true)
			{
				cout << "Конфликт первичного ключа!Операция отменена" << endl;
				return;
			}
			begin->number = temp.number;
			begin->surname = temp.surname;
			begin->points = temp.points;
			break;
		}
		begin = begin->next;
	}
	if (!founded) cout << "Данный элемент не найден" << endl;
}

void sort(Sportsman *& begin)
{
	Sportsman *q, *out = nullptr, *p, *pr;
	while (begin != nullptr)
	{ 
		q = begin; begin = begin->next;
		for (p = out, pr = NULL;p != nullptr && q->number > p->number;	pr = p, p = p->next);
		if (pr == nullptr)
		{ 
			q->next = out; 
			out = q; 
		} 
		else 
		{ 
			q->next = p; 
			pr->next = q; 
		}
	}
	begin = out;
}

bool pkfind(Sportsman * begin, unsigned int number)
{
	while (begin)
	{
		if (begin->number == number)
		{
			return true;
		}
		begin = begin->next;
	}
	return false;
}