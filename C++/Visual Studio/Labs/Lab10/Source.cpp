#include <iostream>
#include <vector>
#include <algorithm>
#include "OAR.h"

using namespace std;

int main()
{
	vector<Sportsman*> v;
	v.push_back(new Sportsman(1, "Galtsov", 12));
	v.push_back(new OAR(2, "Chemesov", 45));
	v.push_back(new OAR(3, "Kirov", 56));

	for (int i = 0; i < v.size(); i++)
	{
		*(v[i]) = *(v[i]) + 4;
		(*v[i])++;
		v[i]->show();
	}



	for (int i = 0; i < v.size(); i++)
	{
		delete v[i];
	}
	
	cin.get();
	return 0;
}