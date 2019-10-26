#include "Polynomial.h"

const char Polynomial::shadow_var = '?';

Polynomial::Polynomial(double d)
{
	Variable variable = { Polynomial::shadow_var , 0 };
	Member member;
	member.coefficient = d;
	member.variables.push_back(variable);
	members.push_back(member);
}

Polynomial::Polynomial(string strinput)
{
	for (int i = 0; i < strinput.size(); i++)
	{
		if (strinput[i] == ' ') strinput.erase(i, 1);
	}
	
	while (1)
	{
		if (strinput.size() == 0)
			break;
		find_members(strinput);
	}
	correct();
}

Polynomial::~Polynomial()
{
}

void Polynomial::find_members(string & strinput)
{
	int i = 1;
	for (; (i < strinput.size() && strinput[i] != '+' && strinput[i] != '-'); i++) {}
	string strmember(strinput.substr(0, i));
	members.push_back(find_variables(strmember));
	strinput.erase(0, i);
}

Member Polynomial::find_variables(const string & strinput)
{	
	Variable variable;
	Member member;
	bool wasdouble;
	size_t pos = 0;
	try
	{
		member.coefficient = stod(strinput, &pos);
		wasdouble = true;
	}
	catch (const exception)
	{
		member.coefficient = 1.0;
		wasdouble = false;
	}

	int count_variables = 0, count_mul = 0;
	size_t i = pos;

	if (wasdouble)
	{
		if (i == strinput.size())
		{
			variable.litera = Polynomial::shadow_var;
			variable.power = 0;
			member.variables.push_back(variable);
			return member;
		}
		if (strinput[i] == '*')
		{
			count_mul--;
		}
	}
	else
	{
		if (strinput[i] == '+' || strinput[i] == '-')
		{
			if (strinput[i] == '-')member.coefficient = -1.0;
			i++;
		}
		if (i == strinput.size())
		{
			throw exception("Некорректный ввод");
		}
		if (strinput[i] == '*')
		{
			throw exception("Некорректный ввод");
		}
	}
	while (1)
	{
		if (i < strinput.size())
		{
			if (strinput[i] == '*')
			{
				count_mul++;
				i++;
				if (i == strinput.size())
				{
					throw exception("Некорректный ввод");
				}
			}
			if (isalpha((unsigned char)strinput[i]))
			{
				variable.litera = strinput[i];
				count_variables++;
				if (count_variables - 1 > count_mul)
				{
					throw exception("Некорректный ввод");
				}
				i++;
				if (i == strinput.size())
				{
					variable.power = 1;
					member.variables.push_back(variable);
					return member;
				}
				if (strinput[i] == '^')
				{
					i++;
					if (i == strinput.size())
					{
						throw exception("Некорректный ввод");
					}
					try
					{
						variable.power = stoi(strinput.substr(i, strinput.size() - i), &pos);
						member.variables.push_back(variable);
						i += pos;
						if (i == strinput.size()) return member;
					}
					catch (const std::exception&)
					{
						throw exception("Некорректный ввод");
					}
				}
				else if (strinput[i] == '*')
				{
					variable.power = 1;
					member.variables.push_back(variable);
				}
				else
				{
					throw exception("Некорректный ввод");
				}
			}
			else
			{
				throw exception("Некорректный ввод");
			}
		}
		else
		{
			throw exception("Некорректный ввод");
		}
	}
}

void Polynomial::correct()
{
	Polynomial temp(0.0);

	cleaner();
	multiply_variables();
	sort_variables();
	
	for (int i = 0; i < members.size(); i++)
	{
		bool wascorrected = false;
		string thispowers = getpowers(i);
		string thisliterals = getliterals(i);

		for (int j = 0; j < temp.members.size(); j++)
		{
			string temppowers = temp.getpowers(j);
			string templiterals = temp.getliterals(j);
			if ((thisliterals == templiterals) && (thispowers == temppowers))
			{
				temp.members[j].coefficient += members[i].coefficient;
				wascorrected = true;
				break;
			}
		}
		if (wascorrected == false)
		{
			temp.members.push_back(members[i]);
		}
	}

	(*this) = temp;
	cleaner();
	sort();
}

void Polynomial::cleaner()
{
	for (int i = 0; i < members.size(); i++)
	{
		if (members[i].coefficient == 0)
		{
			members.erase(members.begin() + i--);
			continue;
		}
		for (int j = 0; j < members[i].variables.size(); j++)
		{
			if (members[i].variables[j].power == 0 && members[i].variables[j].litera != Polynomial::shadow_var)
			{
				members[i].variables.erase(members[i].variables.begin() + j--);
				continue;
			}
			if (members[i].variables[j].litera == Polynomial::shadow_var && members[i].variables.size() > 1)
			{
				members[i].variables.erase(members[i].variables.begin() + j--);
			}
		}
		if (members[i].variables.size() == 0)
		{
			Variable variable = { Polynomial::shadow_var , 0 };
			members[i].variables.push_back(variable);
		}
	}
	if (members.size() == 0)
	{
		Variable variable = { Polynomial::shadow_var , 0 };
		Member member;
		member.coefficient = 0.0;
		member.variables.push_back(variable);
		members.push_back(member);
	}
}

void Polynomial::sort_variables()
{
	for (int n = 0; n < members.size(); n++)
	{
		for (int i = members[n].variables.size() - 1; i >= 0; i--)
		{
			for (int j = 0; j < i; j++)
			{
				if (members[n].variables[j].litera > members[n].variables[j + 1].litera)
				{
					swap(members[n].variables[j], members[n].variables[j + 1]);
				}
			}
		}
	}
}

void Polynomial::multiply_variables()
{
	string str;

	for (int i = 0; i < members.size(); i++)
	{
		for (int j = 0; j < members[i].variables.size(); j++)
		{
			if (str.find_first_of(members[i].variables[j].litera) == string::npos)
			{
				str += members[i].variables[j].litera;
			}
			else
			{
				for (int k = 0; k < j; k++)
				{
					if (members[i].variables[k].litera == members[i].variables[j].litera)
					{
						members[i].variables[k].power+= members[i].variables[j].power;
						break;
					}
				}
				members[i].variables.erase(members[i].variables.begin() + j--);
			}
		}

		str.clear();
	}
}

string Polynomial::getpowers(const int & index) const
{
	string temp;
	for (int i = 0; i < members[index].variables.size(); i++)
	{
		temp += to_string(members[index].variables[i].power);
	}
	return temp;
}

string Polynomial::getliterals(const int & index) const
{
	string temp;
	for (int i = 0; i < members[index].variables.size(); i++)
	{
		temp += members[index].variables[i].litera;
	}
	return temp;
}

void Polynomial::sort()
{
	for (int i = members.size() - 1; i >= 0; i--)
	{
		for (int j = 0; j < i; j++)
		{
			if (members[j].variables.size() < members[j + 1].variables.size() 
				|| members[j].variables[0].litera == Polynomial::shadow_var)
			{
				swap(members[j], members[j + 1]);
			}
		}
	}
}

Polynomial Polynomial::derivative(const char & variable) const
{
	Polynomial temp(*this);

	for (int i = 0; i < temp.members.size(); i++)
	{
		if (temp.members[i].variables[0].litera == Polynomial::shadow_var 
			|| temp.getliterals(i).find(variable) == string::npos)
		{
			temp.members.erase(temp.members.begin() + i--);
			continue;
		}
		for (int j = 0; j < temp.members[i].variables.size(); j++)
		{
			if (temp.members[i].variables[j].litera == variable)
			{
				temp.members[i].coefficient *= temp.members[i].variables[j].power;
				temp.members[i].variables[j].power--;
				break;
			}
		}
	}
	temp.correct();
	return temp;
}

string Polynomial::getindeterminates() const
{
	string str;
	for (int i = 0; i < members.size(); i++)
	{
		for (int j = 0; j < members[i].variables.size(); j++)
		{
			if (str.find_first_of(members[i].variables[j].litera) == string::npos
				&& members[i].variables[j].litera != Polynomial::shadow_var)
			{
				str += members[i].variables[j].litera;
				str += ", ";
			}
		}
	}
	if (str.empty() == false)
	{
		str.pop_back();
		str.pop_back();
	}
	else str = "Пусто!";
	return str;
}

Polynomial Polynomial::operator()(string & strinput) const
{
	Polynomial result(*this);

	for (int i = 0; i < strinput.size(); i++)
	{
		if (strinput[i] == ' ') strinput.erase(i, 1);
	}
	for (size_t i = 0, size = strinput.size(); i < size; i++)
	{
		if (isalpha(strinput[i]))
		{
			char letter = strinput[i];
			size_t beg, end;
			beg = strinput.find('(', i);
			end = strinput.find(')', i);
			if (beg == string::npos || end == string::npos || beg > end)
			{
				throw exception("Некорректный ввод");
			}
			i = end;

			for (int n = 0; n < result.members.size(); n++)
			{
				for (int m = 0; m < result.members[n].variables.size(); m++)
				{
					if (result.members[n].variables[m].litera == letter)
					{
						Polynomial insert(strinput.substr(beg + 1, end - beg - 1));
						insert = insert ^ result.members[n].variables[m].power;
						insert = insert * result.members[n].coefficient;
						result.members[n].variables.erase(result.members[n].variables.begin() + m);
						for (int l1 = 0; l1 < insert.members.size(); l1++)
						{
							for (int l2 = 0; l2 < result.members[n].variables.size(); l2++)
							{
								insert.members[l1].variables.push_back(result.members[n].variables[l2]);
							}
						}

						for (int l1 = 0; l1 < insert.members.size(); l1++)
						{
							result.members.insert(result.members.begin() + n++, insert.members[l1]);
						}

						result.members.erase(result.members.begin() + n--);
						break;
					}
				}
			}
			result.correct();
		}
	}
	return result;
}

Polynomial & Polynomial::operator=(const Polynomial & Other)
{
	members.clear();
	Variable variable;
	Member member;
	for (int i = 0; i < Other.members.size(); i++)
	{
		member.coefficient = Other.members[i].coefficient;

		for (int j = 0; j < Other.members[i].variables.size(); j++)
		{
			variable.litera = Other.members[i].variables[j].litera;
			variable.power = Other.members[i].variables[j].power;
			member.variables.push_back(variable);
		}
		members.push_back(member);
		member.variables.clear();
	}
	return *this;
}

Polynomial Polynomial::operator+(const Polynomial & right) const
{
	Polynomial result(*this);

	for (int i = 0; i < right.members.size(); i++)
	{
		bool wasadded = false;
		string rightpowers = right.getpowers(i);
		string rightliterals = right.getliterals(i);

		int j = 0;
		for (; j < result.members.size(); j++)
		{
			string resultpowers = result.getpowers(j);
			string resultliterals = result.getliterals(j);
			if ((resultliterals == rightliterals) && (resultpowers == rightpowers))
			{
				result.members[j].coefficient += right.members[i].coefficient;
				wasadded = true;
				break;
			}
		}
		if (wasadded == false)
		{
			result.members.push_back(right.members[i]);
		}
	}
	result.correct();
	return result;
}

Polynomial Polynomial::operator+(const double & right) const
{
	Polynomial R(right);
	return (*this) + R;
}

Polynomial Polynomial::operator-(const Polynomial & right) const
{
	Polynomial result(*this);

	for (int i = 0; i < right.members.size(); i++)
	{
		bool wassubtracted = false;
		string rightpowers = right.getpowers(i);
		string rightliterals = right.getliterals(i);

		int j = 0;
		for (; j < result.members.size(); j++)
		{
			string resultpowers = result.getpowers(j);
			string resultliterals = result.getliterals(j);
			if ((resultliterals == rightliterals) && (resultpowers == rightpowers))
			{
				result.members[j].coefficient -= right.members[i].coefficient;
				wassubtracted = true;
				break;
			}
		}
		if (wassubtracted == false)
		{
			result.members.push_back(right.members[i]);
			result.members.back().coefficient = -result.members.back().coefficient;
		}
	}
	result.correct();
	return result;
}

Polynomial Polynomial::operator-(const double & right) const
{
	Polynomial R(right);
	return (*this) - R;
}

Polynomial Polynomial::operator*(const Polynomial & right) const
{
	Polynomial result;
	Variable variable;
	Member member;
	
	for (int i = 0; i < members.size(); i++)
	{
		for (int n = 0; n < right.members.size(); n++)
		{
			member.coefficient = members[i].coefficient * right.members[n].coefficient;
			for (int j = 0; j < members[i].variables.size(); j++)
			{
				variable.litera = members[i].variables[j].litera;
				variable.power = members[i].variables[j].power;
				member.variables.push_back(variable);
			}
			for (int m = 0; m < right.members[n].variables.size(); m++)
			{
				bool wasmultiplied = false;
				for (int k = 0; k < members[i].variables.size(); k++)
				{

					if (members[i].variables[k].litera == right.members[n].variables[m].litera)
					{
						for (int l = 0; l < member.variables.size(); l++)
						{
							if (member.variables[l].litera == members[i].variables[k].litera)
							{
								member.variables[l].power = members[i].variables[k].power + right.members[n].variables[m].power;
								continue;
							}
						}
						wasmultiplied = true;
						continue;
					}
				}
				if (wasmultiplied == false)
				{
					variable.litera = right.members[n].variables[m].litera;
					variable.power = right.members[n].variables[m].power;
					member.variables.push_back(variable);
				}
			}
			result.members.push_back(member);
			member.variables.clear();
		}
	}
	result.correct();
	return result;
}

Polynomial Polynomial::operator*(const double & right) const
{
	Polynomial R(right);
	return (*this) * R;
}

Polynomial Polynomial::operator/(const double & right) const
{
	if (right == 0.0)
	{
		throw exception("Деление на ноль!");
	}
	Polynomial result(*this);
	for (int i = 0; i < result.members.size(); i++)
	{
		result.members[i].coefficient /= right;
	}
	return result;
}

Polynomial Polynomial::operator^(const unsigned int & power) const
{
	Polynomial result(*this);
	for (int i = 0; i < power - 1; i++)
	{
		result = result * (*this);
	}
	return result;
}

ostream & operator<<(ostream & output, const Polynomial & P)
{
	for (int i = 0; i < P.members.size(); i++)
	{
		if (P.members[i].coefficient < 0.0)
		{
			output << "-";
			if (i != 0) output << " ";
			if (P.members[i].variables[0].litera == Polynomial::shadow_var)
				output << -P.members[i].coefficient;
			else if(P.members[i].variables[0].litera != Polynomial::shadow_var && P.members[i].coefficient != -1.0)
				output << -P.members[i].coefficient;
		}
		else
		{
			if (i != 0)
			{
				output << "+ ";
			}
			if (P.members[i].coefficient != 1.0) output << P.members[i].coefficient;
			else if (P.members[i].variables[0].litera == Polynomial::shadow_var)
				output << P.members[i].coefficient;
		}
		
		for (int j = 0; j < P.members[i].variables.size(); j++)
		{
			if (P.members[i].variables[j].litera != Polynomial::shadow_var)
			{
				if (j != 0) output << '*';
				output << P.members[i].variables[j].litera;
				if (P.members[i].variables[j].power != 1)
				{
					output << '^' << P.members[i].variables[j].power;
				}
			}
		}
		output << ' ';
	}
	return output;
}

istream & operator>>(istream & input, Polynomial & P)
{
	string strinput;
	getline(input, strinput);
	P = Polynomial(strinput);
	return input;
}

Polynomial operator+(const double & left, const Polynomial & right)
{
	Polynomial L(left);
	return L + right;
}

Polynomial operator-(const double & left, const Polynomial & right)
{
	Polynomial L(left);
	return L - right;
}

Polynomial operator*(const double & left, const Polynomial & right)
{
	Polynomial L(left);
	return L * right;
}