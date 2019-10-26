//#include <string>
#include <iostream>
#include "Sportsman.h"

using namespace std;

int main()
{
	Sportsman S(22, "Petrov", 34), S1(S), S2;
	S1.show();

	S.set_number(12);
	S.show();

	S.set_number(-2);
	S2.show();


	cin.get();
	return 0;
}