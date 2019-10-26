#include <iostream>


using namespace std;
char* lftostr(double, char*);
double strtolf(char*);

int main()
{
	char str[100] = {0};
	cout<< lftostr(14112.395,str)<<endl;
	//cout <<  strtolf(str) << endl;
	printf("%lf \n", strtolf(str));

	system("pause");
	return 0;
}

char* lftostr(double number,char* n)
{
	double fractpart, intpart;
	char* begin = n;
	fractpart = modf(number, &intpart);

	int abovedot = (int)intpart;
	int belowdot = (int)(fractpart * 1000000);
	bool ispos = (abovedot >= 0 ? true : false);
	do
	{
		*n++ = belowdot % 10 + '0';
	} while (belowdot /= 10);
	*n++ = '.';
	do
	{
		*n++ = abovedot % 10 + '0';

	} while (abovedot /= 10);
	if (!ispos)
		*n++ = '-';
	*n = '\0';
	return _strrev(begin);
}

double strtolf(char* t)
{
	double number = 0,var = 0.1;
	bool ispos = true;
	int len = 0;
	char* z = t;

	if (*t == '-')
	{
		t++;
		bool ispos = false;
	}
	while (*t != '.')
	{
		len++;
		t++;
	}
	while (*z != '.')
	{
		number += pow(10, --len)* (*z++ - '0');
	}
	z++;
	while (*z != '\0')
	{
		number += (*z++ - '0')   * var;
		var /= 10;
	}
	return (ispos?number:-number);
}

