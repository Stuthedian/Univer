#pragma once
#include "Sportsman.h"

class OAR : public Sportsman
{
private:
	const static string desc;
public:
	OAR(int n = 0, string s = "NULL", int p = 0) : Sportsman(n, s, p) {};
	OAR(const OAR& other) : Sportsman(other.number, other.surname, other.points) {};
	~OAR() {};
	Sportsman* return_base();
	void get_desc();
	void show();
	OAR operator++(int);
	OAR operator+(const int i);
};

const string OAR::desc("We are Olympic Athletes from Russia");
void (OAR::*OAR_info)() = &OAR::show;

void OAR::get_desc()
{
	cout << desc << endl;
}

void OAR::show()
{
	cout << "<OAR>" << "\tNumber: " << number << '\t' << "Surname: " << surname << '\t' << "Points: " << points << endl;
}

OAR OAR::operator++(int)
{
	OAR temp(*this);
	points++;
	return temp;
}

OAR OAR::operator+(const int i)
{
	OAR temp(*this);
	temp.points += i;
	return temp;
}

Sportsman* OAR::return_base()
{
	return new Sportsman(number, surname, points);
}
