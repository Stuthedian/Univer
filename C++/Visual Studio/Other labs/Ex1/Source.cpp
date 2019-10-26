#include <iostream>

using namespace std;

const char* find(const char* str, int n1, int n2);

int main()
{
	const char* str = "String!12";
	const char* res = find(str, 48, 50);
	if(res == nullptr)
		cout << "NULL\n";
	else
		cout << res << '\n';
	cin.get();
	return 0;
}

const char * find(const char * str, int n1, int n2)
{
	const char* result = nullptr;
	if (!(n1 >= 0 && n1 <= 255) || !(n2 >= 0 && n2 <= 255)
		|| n1 > n2)
		return result;
	for (int i = 0; str[i] != '\0'; i++)
	{
		if (str[i] >= n1 && str[i] <= n2)
			result = &str[i];
	}
	return result;
}
