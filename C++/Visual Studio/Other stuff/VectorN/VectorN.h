#pragma once
#include <vector>
#include <iostream>
#include <cmath>
class VectorN
{
	friend std::ostream& operator<<(std::ostream& out, VectorN v);
private:
	const int size;
	std::vector<int> members;
public:
	VectorN(int n);
	VectorN(int n, int* arr);
	~VectorN();
	VectorN operator+(VectorN v);
	VectorN operator-(VectorN v);
	VectorN operator*(int n);
	double length();
	int dot(VectorN v);
	VectorN cross(VectorN v);
	double angle(VectorN v);
};

