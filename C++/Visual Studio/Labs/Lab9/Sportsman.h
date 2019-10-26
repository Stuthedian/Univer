#pragma once
#include <string>
#include <iostream>

using namespace std;

class Sportsman
{
public:
	Sportsman(int n = 0, string s = "NULL", int p = 0) : number(n), surname(s), points(p) {};
	Sportsman(const Sportsman& S) : number(S.number), surname(S.surname), points(S.points) {};
	virtual ~Sportsman() {};
	void set_number(int n) { if (n >= 0) number = n; else cout << "Error, number must be >= 0!" << endl; }
	void set_surname(string s) { surname = s; }
	void set_surname(char* s) { surname = s; }
	void set_points(int p) { if (p >= 0) points = p; else cout << "Error, points must be >= 0!" << endl; }
	virtual void show();
protected:
	int number;
	string surname;
	int points;
};

void Sportsman::show()
{
	cout << "Number: " << number << '\t' << "Surname: " << surname << '\t' << "Points: " << points << endl;
}
