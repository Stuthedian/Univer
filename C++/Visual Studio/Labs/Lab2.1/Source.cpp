#include <iostream>

using namespace std;

char* strdespace(char*);

int main()
{
	char string[]= "s*&(#)$#($)%&%^%&%*(%%$%*)(^*&^(*#)\*s";
	
	cout<< strdespace(string)<<endl;

	system("pause");
	return 0;
}

char* strdespace(char* strinput)
{
	void del(char*);

	for (int i = 0; strinput[i] != '\0' || strinput[i - 1] != '\0';)
	{
		if ((strinput[i] >= 0x21 && strinput[i] <= 0x2F)
			|| (strinput[i] >= 0x3a && strinput[i] <= 0x40)
			|| (strinput[i] >= 0x5B && strinput[i] <= 0x60)
			|| (strinput[i] >= 0x7B && strinput[i] <= 0x7E))
		{
			del(&strinput[i]);
		}
		else i++;
	}
	return strinput;
}

void del(char* elem)
{
	for (int i = 0; elem[i] != '\0' || elem[i - 1] != '\0'; i++)
	{
		elem[i] = elem[i + 1];
	}
}