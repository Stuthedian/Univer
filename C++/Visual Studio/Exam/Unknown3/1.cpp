#include <iostream>

using namespace std;

char* similars(char* s1, char* s2);

int main()
{
	char* s1 = "Funny string";
	char* s2 = "More than string!";

	cout << similars(s1, s2) << endl;

	cin.get();
	return 0;
}

char* similars(char* s1, char* s2)
{
	int count = 0;
	const int symbols = 256;
	bool letters[symbols] = { 0 };

	for (int i = 0; s1[i] != '\0'; i++)
	{
		for (int j = 0; s2[j] != '\0'; j++)
		{
			if (s1[i] == s2[j] && letters[(int)s1[i]] == false)
			{
				letters[s1[i]] = true;
				count++;
			}
		}
	}

	char* s = new char[count + 1];
	s[count] = '\0';

	for (int i = 0, k = 0; i < symbols; i++)
	{
		if (letters[i] == true) s[k++] = (char)i;
	}

	return s;
}