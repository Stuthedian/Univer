#pragma once
#include <string>
#include <iostream>

using namespace std;

class Sportsman
{
	//friend ostream& operator<<(ostream& out, Sportsman& S);
public:
	Sportsman();
	Sportsman(int n, string s, int p);
	Sportsman(int n, char* s, int p);
	Sportsman(const Sportsman& S);
	~Sportsman();
	void set_number(int n) { if (n >= 0) number = n; else cout << "Error, n must be >= 0!" << endl; }
	void set_surname(string s) { surname = s; }
	void set_surname(char* s) { surname = s; }
	void set_points(int p) { if (p >= 0) points = p; else cout << "Error, p must be >= 0!" << endl; }
	void show();
private:
	int number;
	string surname;
	int points;
};

Sportsman::Sportsman() : number(0), surname("NULL"), points(0)
{
}

Sportsman::Sportsman(int n, string s, int p) : number(n), surname(s), points(p)
{
}

Sportsman::Sportsman(int n, char * s, int p) : number(n), surname(s), points(p)
{
}

Sportsman::Sportsman(const Sportsman & S) : number(S.number), surname(S.surname), points(S.points)
{
}

Sportsman::~Sportsman()
{
	//cout << surname << " deleted!" << endl;
}

void Sportsman::show()
{
	cout << "Number: " << number << '\t' << "Surname: " << surname << '\t' << "Points: " << points << endl;
}

/*
ostream& operator<<(ostream& out, Sportsman& S)
{
	out << S.number << ' ' << S.surname << ' ' << S.points << endl;
	return out;
}
*/

