#define _CRT_SECURE_NO_WARNINGS
#include <cstdio>

int main()
{
	FILE* text = fopen("C:\\Users\\dnevalniy\\Downloads\\karamazov_brothers.a4.pdf", "rb");
	if (text == NULL) printf("Error!\n");

	int filesize = 0, cp866 = 0, win1251 = 0, koi8_r = 0;

	fseek(text, 0, SEEK_END);
	filesize = ftell(text);
	rewind(text);

	unsigned char s;
	for (long i = 0; i < filesize; i++)
	{
		fread(&s, sizeof(char), 1, text);

		if ((s >= 0x80 && s <= 0xAF) || (s >= 0xE0 && s <= 0xEF))  cp866++;
		if ((s == 0xA8 || s == 0xB8) || (s >= 0xC0 && s <= 0xFF))  win1251++;
		if ((s == 0xA3 || s == 0xB3) || (s >= 0xC0 && s <= 0xFF))  koi8_r++;
		
	}

	printf("Probability of cp866: %.2lf%%\n", ((cp866 + 0.0) / filesize) * 100);
	printf("Probability of win1251: %.2lf%%\n", ((win1251 + 0.0) / filesize) * 100);
	printf("Probability of koi8_r: %.2lf%%\n", ((koi8_r + 0.0) / filesize) * 100);


	fclose(text);
	getchar();
	return 0;
}