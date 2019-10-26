#pragma once
#include <iostream>
#include <vector>
#include <string>
#include <cctype>
#include <exception>

using namespace std;

struct Variable
	//Структура, описывающая переменную. Хранит букву и степень переменной.
{
	char litera;
	unsigned int power;
};

struct Member
	//Структура, описывающая слагаемое многочлена. Хранит коэффициент и массив переменных.
{
	double coefficient;
	vector<Variable> variables;
};
class Polynomial
{
	//Операторы ввода-вывода в поток.
	friend ostream& operator<<(ostream& output, const Polynomial& P);
	friend istream& operator>>(istream& input, Polynomial& P);
	//Функции-друзья класса, выполняющие сложение, вычитание и умножение с числом. 
	friend Polynomial operator+(const double& left, const Polynomial& right);
	friend Polynomial operator-(const double& left, const Polynomial& right);
	friend Polynomial operator*(const double& left, const Polynomial& right);
private:
	/*Псевдо-переменная. Требуется для корректной работы со слагаемыми, не имеющих переменную, например, в данном случае для «7»: 2x^2 + 7 */
	static const char shadow_var;
	vector<Member> members;//Массив слагаемых многочлена.
						   /*Методы разбора входной строки. Ищут соответственно слагаемые многочлена и переменные для каждого слагаемого.*/
	void find_members(string& strinput);
	Member find_variables(const string& strinput);
	void correct();/*Складывает слагаемые, если присутствует такая возможность. Также, производит вызов методов: cleaner, sort_variables, multiply_variables, sort */
	void cleaner();/*Удаляет слагаемые с нулевым коэффициентом, удаляет переменные в нулевой степени*/
	void sort_variables();/*Сортирует переменные в слагаемого. Требуется для корректной работы сложения, т.е. 2a*b + 2b*a = 4a*b, так как a*b == b*a */
	void multiply_variables();/*Перемножает переменные, если присутствует такая возможность.*/
	void sort();//Сортирует слагаемые.
	string getpowers(const int & index) const;/*Возвращает степени переменных «index»-слагаемого*/
	string getliterals(const int & index) const;/*Возвращает буквы переменных «index»-слагаемого*/
	Polynomial operator^(const unsigned int& power) const;/*Возведение многочлена в положительную целочисленную степень. Используется в методе подстановки числа/полинома вместо переменной*/
public:
	Polynomial(double d = 0.0);
	Polynomial(string strinput);
	~Polynomial();
	Polynomial& operator= (const Polynomial& Other);

	Polynomial derivative(const char & variable) const;// Взятие (частной) производной
	string getindeterminates() const;// Получение списка переменных многочлена
									 /*Переопределённый оператор "круглые скобки".
									 Выполняет подстановку в многочлен числа или другого многочлена  в формате: x("y^2"), где x — заменяемая переменная,	а y^2 — подставляемое выражение.
									 Для вычисления многочлена при указанных значениях неизвестных используется следующий формат:
									 x("2") y("6") z("0") — для многочлена, имеющего 3 неизвестных: x,y и z соответственно
									 */
	Polynomial operator()(string& strinput) const;
	/*
	Переопределённые операторы сложения, вычитания и умножения с многочленом и числом double. Оператор деления на число double
	*/
	Polynomial operator+(const Polynomial& right) const;
	Polynomial operator-(const Polynomial& right) const;
	Polynomial operator*(const Polynomial& right) const;
	Polynomial operator+(const double& right) const;
	Polynomial operator-(const double& right) const;
	Polynomial operator*(const double& right) const;
	Polynomial operator/(const double& right) const;
};
