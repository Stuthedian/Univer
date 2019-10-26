#define _CRT_SECURE_NO_WARNINGS
#include <cstdio>

int main()
{
	char buf[50];
	FILE* f1 = fopen("f1.txt", "r");
	FILE* f2 = fopen("f2.txt", "w");
	if (f1 == NULL)
		printf("Cannot open f1!\n");
	if (f2 == NULL)
		printf("Cannot open f2!\n");
	int character = 1;
	while ((character = fgetc(f1)) != EOF)
	{
		fprintf(f2, "%xh ", character);
	}
	fflush(f1);
	fflush(f2);
	fclose(f1);
	fclose(f2);
	//getchar();
	return 0;
}