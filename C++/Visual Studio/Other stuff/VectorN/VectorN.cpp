#include "VectorN.h"

VectorN::VectorN(int n) :size(n)
{
	
}

VectorN::VectorN(int n, int* arr):size(n)
{
	for (size_t i = 0; i < size; i++)
	{
		members.push_back(arr[i]);
	}
}

VectorN::~VectorN()
{
}

VectorN VectorN::operator+(VectorN v)
{
	VectorN res(this->size);
	for (size_t i = 0; i < this->size; i++)
	{
		res.members.push_back(this->members[i] + v.members[i]);
	}
	return res;
}

VectorN VectorN::operator-(VectorN v)
{
	VectorN res(this->size);
	for (size_t i = 0; i < this->size; i++)
	{
		res.members.push_back(this->members[i] - v.members[i]);
	}
	return res;
}

VectorN VectorN::operator*(int n)
{
	VectorN res(this->size);
	for (size_t i = 0; i < this->size; i++)
	{
		res.members.push_back(this->members[i]*n);
	}
	return res;
}

double VectorN::length()
{
	double sum = 0;
	for (size_t i = 0; i < this->size; i++)
	{
		sum += this->members[i] * this->members[i];
	}
	return sqrt(sum);
}

int VectorN::dot(VectorN v)
{
	int sum = 0;
	for (size_t i = 0; i < this->size; i++)
	{
		sum += this->members[i] * v.members[i];
	}
	return sum;
}

VectorN VectorN::cross(VectorN v)
{
	VectorN res(3);
	res.members.push_back(this->members[1] * v.members[2] - this->members[2] * v.members[1]);
	res.members.push_back(-(this->members[0] * v.members[2] - this->members[2] * v.members[0]));
	res.members.push_back(this->members[0] * v.members[1] - this->members[1] * v.members[0]);
	return res;
}

double VectorN::angle(VectorN v)
{

	return this->dot(v)/(this->length() *v.length());
}

std::ostream & operator<<(std::ostream & out, VectorN v)
{
	for (size_t i = 0; i < v.size; i++)
	{
		out << v.members[i] << '\n';
	}
	return out;
}
