#define _CRT_SECURE_NO_WARNINGS
#include <cstdio>

int main()
{
	char buf[40];
	FILE* f1 = fopen("f1.txt", "r");
	FILE* f2 = fopen("f2.txt", "w");
	if (f1 == NULL)
		printf("Cannot open f1!\n");
	if (f2 == NULL)
		printf("Cannot open f2!\n");
	int count = 1;
	while (!feof(f1))
	{
		fgets(buf, 40, f1);
		fprintf(f2, "%d %s", count, buf);
		count++;
	}
	fflush(f1);
	fflush(f2);
	fclose(f1);
	fclose(f2);
	//getchar();
	return 0;
}