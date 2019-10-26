#define _CRT_SECURE_NO_WARNINGS
#include <cstdio>
#include <cctype>

int main()
{
	FILE* Rambo = fopen("filz1.txt", "r+b");
	if (Rambo == NULL)
		printf("Cannot open Rambo!\n");

	char symbol;
	int countsymbol = 0, countstring = 0, maxstring = 0, currentstring = 0;
	for (;;)
	{


		symbol = fgetc(Rambo);
		if (feof(Rambo)) break;

		(isgraph(symbol) ? countsymbol++ && currentstring++ : 0);

		if (symbol == '\n')
		{
			if (currentstring != 0)
			{
				countstring++;
				if (currentstring > maxstring)
				{
					maxstring = currentstring;
					currentstring = 0;
				}
			}
		}
	}
	(currentstring ? countstring++ : 0);

	printf("Amount of symbols: %d\nAmount of strings: %d\nLongest string: %d", countsymbol, countstring, maxstring);

	fflush(Rambo);
	fclose(Rambo);

	getchar();
	return 0;
}
