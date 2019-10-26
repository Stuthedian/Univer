#include "VectorN.h"

int main()
{
	int a[] = { 6,7,10 };
	int b[] = { 8,5,9 };
	VectorN v(3, a);
	VectorN l(3, b);
	std::cout << v;
	std::cout << l << std::endl;
	std::cout << v.cross(l);

	std::cin.get();
	return 0;
}