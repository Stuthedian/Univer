#include <iostream>
#include "OAR.h"

using namespace std;

int main()
{
	OAR* _1 = new OAR();
	_1->get_desc();
	
	Sportsman* p = _1->return_base();
	Sportsman _s(*p);
	delete p;

	_s.show();

	OAR m(2, "kol", 2);
	(m.*OAR_info)();

	delete _1;
	cin.get();
	return 0;
}