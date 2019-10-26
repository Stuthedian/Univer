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
	
	cout << "������� ���������:" << "\t������ �����: 2x^2 + 4*x -x*r*z^5"<<endl;
	input_polynomial(P, s);
	if (loop_flag) cout << "�� �����: " << P << endl;
	while (loop_flag)
	{
		cout << "�������� �����:\t\t[ " << P << "]" << endl;
		cout << "+:�������� � �����������\t-:������� ���������\t*:�������� �� ���������" << endl;
		cout << "/:��������� �� �����\t\':����� �����������\ti:�������� ������ �����������" << endl;
		cout << "s:���������� ����� ��� ���������\t=:������ ���������";
		if(result) cout << "\t�:������������ ���������";
		cout << endl;
		cout << "q:�����" << endl;
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
		case '=': {cout << "������� ���������:" << endl; input_polynomial(P, s); } break;
		case 'q': loop_flag = false; break;
		case 'a': if (result) { P = Result; result = false; break; }
		default: {cout << "������������ �����" << endl; }break;
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
	cout << "������� ���������:" << endl;
	input_polynomial(second, s);
	Result = first + second;
	cout << "���������:\t" <<Result << endl;
	result = true;
}

void sub(const Polynomial& first, Polynomial& second)
{
	cout << "������� ���������:" << endl;
	input_polynomial(second, s);
	Result = first - second;
	cout << "���������:\t" << Result << endl;
	result = true;
}

void mul(const Polynomial& first, Polynomial& second)
{
	cout << "������� ���������:" << endl;
	input_polynomial(second, s);
	Result = first * second;
	cout << "���������:\t" << Result << endl;
	result = true;
}

void div(const Polynomial& first, string& s)
{
	double d;
	cout << "������� �����:" << endl;
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
			cout << "������������ ����" << endl;
		}
		catch (const exception& e)
		{
			cout << e.what() << endl;
		}
	}
	cout << "���������:\t" << Result << endl;
	result = true;
}

void deriv(const Polynomial& first, string& s)
{
	cout << "������� ���������� �����������������:" << endl;
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
		cout << "������������ ����" << endl;
		
	}
	Result = first.derivative(s[0]);
	cout << "���������:\t" << Result << endl;
	result = true;
}

void indet(const Polynomial& first)
{
	cout << "C����� �����������:\t" << first.getindeterminates() << endl;
	result = false;
}

void insert(const Polynomial& first, string& s)
{
	cout << "������� ��������� ��� ����� ��� �����������" << endl;
	cout << "������ �����: <���������� ����������>(<��������� ��� ����� ��� ������>)" << endl;
	cout << "������ �����: x(2*t^3)" << endl;
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
			cout << "���������:\t" << Result << endl;
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