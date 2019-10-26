#include <iostream>
#include <cctype>
#include <clocale>
#include <Windows.h>
#include "Polynomial.h"


using namespace std;

void add(const Polynomial& first, Polynomial& second);
void sub(const Polynomial& first, Polynomial& second);
void mul(const Polynomial& first, Polynomial& second);
void div(const Polynomial& first, string& s);
void deriv(const Polynomial& first, string& s);
void indet(const Polynomial& first);
void insert(const Polynomial& first, string& s);
void input_polynomial(Polynomial& P, string& s);

bool loop_flag = true, result = false;
string s;
Polynomial P, Second, Result;
int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	setlocale(LC_CTYPE, "ru-RU");
	
	char choice = 0;
	
	cout << "Введите многочлен:" << "\tПример ввода: 2x^2 + 4*x -x*r*z^5"<<endl;
	input_polynomial(P, s);
	if (loop_flag) cout << "Вы ввели: " << P << endl;
	while (loop_flag)
	{
		cout << "Выберите опцию:\t\t[ " << P << "]" << endl;
		cout << "+:Сложение с многочленом\t-:Вычесть многочлен\t*:Умножить на многочлен" << endl;
		cout << "/:Разделить на число\t\':Взять производную\ti:Получить список неизвестных" << endl;
		cout << "s:Подставить число или многочлен\t=:Ввести многочлен";
		if(result) cout << "\tа:Использовать результат";
		cout << endl;
		cout << "q:Выход" << endl;
		cin >> choice;
		cin.ignore(100, '\n');

		switch (choice)
		{
		case '+': add(P, Second); break;
		case '-': sub(P, Second); break;
		case '*': mul(P, Second); break;
		case '/': div(P, s); break;
		case '\'': deriv(P, s); break;
		case 'i': indet(P); break;
		case 's': insert(P, s); break;
		case '=': {cout << "Введите многочлен:" << endl; input_polynomial(P, s); } break;
		case 'q': loop_flag = false; break;
		case 'a': if (result) { P = Result; result = false; break; }
		default: {cout << "Некорректная опция" << endl; }break;
		}
	}
	return 0;
}

void input_polynomial(Polynomial& P, string& s)
{
	while (1)
	{
		getline(cin, s);
		if(s == "q")
		{
			loop_flag = false;
			break;
		}
			
		try
		{
			P = s;
			result = false;
			break;
		}
		catch (const std::exception& e)
		{
			cout << e.what() << endl;
			s.clear();
		}
	}
}

void add(const Polynomial& first, Polynomial& second)
{
	cout << "Введите многочлен:" << endl;
	input_polynomial(second, s);
	Result = first + second;
	cout << "Результат:\t" <<Result << endl;
	result = true;
}

void sub(const Polynomial& first, Polynomial& second)
{
	cout << "Введите многочлен:" << endl;
	input_polynomial(second, s);
	Result = first - second;
	cout << "Результат:\t" << Result << endl;
	result = true;
}

void mul(const Polynomial& first, Polynomial& second)
{
	cout << "Введите многочлен:" << endl;
	input_polynomial(second, s);
	Result = first * second;
	cout << "Результат:\t" << Result << endl;
	result = true;
}

void div(const Polynomial& first, string& s)
{
	double d;
	cout << "Введите число:" << endl;
	while (1)
	{
		getline(cin, s);
		if (s == "q")
		{
			loop_flag = false;
			return;
		}
		try
		{
			d = stod(s);
			Result = first / d;	
			break;
		}
		catch (const invalid_argument&)
		{
			cout << "Некорректный ввод" << endl;
		}
		catch (const exception& e)
		{
			cout << e.what() << endl;
		}
	}
	cout << "Результат:\t" << Result << endl;
	result = true;
}

void deriv(const Polynomial& first, string& s)
{
	cout << "Введите переменную дифференцирования:" << endl;
	while (1)
	{
		getline(cin, s);
		if (s == "q")
		{
			loop_flag = false;
			return;
		}
		else if (s.size() == 1 && isalpha((unsigned char)s[0]))
			break;
		cout << "Некорректный ввод" << endl;
		
	}
	Result = first.derivative(s[0]);
	cout << "Результат:\t" << Result << endl;
	result = true;
}

void indet(const Polynomial& first)
{
	cout << "Cписок неизвестных:\t" << first.getindeterminates() << endl;
	result = false;
}

void insert(const Polynomial& first, string& s)
{
	cout << "Введите многочлен или число для подстановки" << endl;
	cout << "Формат ввода: <заменяемая переменная>(<многочлен или число для замены>)" << endl;
	cout << "Пример ввода: x(2*t^3)" << endl;
	while (1)
	{
		getline(cin, s);
		if (s == "q")
		{
			loop_flag = false;
			break;
		}
		try
		{
			Result = P(s);
			cout << "Результат:\t" << Result << endl;
			result = true;
			break;
		}
		catch (const std::exception& e)
		{
			cout << e.what() << endl;
			s.clear();
		}
	}
	
}