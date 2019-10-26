#include <iostream>

using namespace std;

char * maxword(char *, int&);
char * substring(char *, int);

int main()
{
	char * s = "holll efds dwarfs";
	int len;

	cout << maxword(s, len) << endl;
	cout << len << endl;

	cin.get();
	return 0;
}

char * maxword(char * string, int& maxwordlen)
{
	bool inword = false;
	int tempwordlen = 0;
	char * tempwordptr = 0, *maxwordptr = 0;
	
	maxwordlen = -1;

	while (*string != '\0')
	{
		if (*string != ' ' && inword == true)
		{
			tempwordlen++;
			//continue;
		}
		else if (*string != ' ' && inword == false)
		{
			tempwordlen++;
			tempwordptr = string;
			inword = true;
		}
		else if(*string == ' ' && inword == true)
		{
			inword = false;
			if (tempwordlen >= maxwordlen)
			{
				maxwordlen = tempwordlen;
				delete[] maxwordptr;
				maxwordptr = substring(tempwordptr, tempwordlen);
			}
			tempwordlen = 0;
			tempwordptr = 0;
		}
		string++;
	}
	if (tempwordlen >= maxwordlen)
	{
		maxwordlen = tempwordlen;
		delete[] maxwordptr;
		maxwordptr = substring(tempwordptr, tempwordlen);
	}
	return maxwordptr;
}

char * substring(char * string, int len)
{
	char * temp = new char[len+1];
	for (int i = 0; i < len; i++)
	{
		temp[i] = string[i];
	}
	temp[len] = '\0';
	return temp;
}
