#include <iostream>
#include <sstream>
#include <string>
#include <vector>

using namespace std;

int main()
{
	cout << "Enter the string: ";
	string str;
	getline(cin, str);

	vector <string> vecstr;
	string word;
	for (int i = 0, strsize = str.size(); i < strsize; i++)
	{
		(isalnum(str[i]) || str[i] == ' ' || str[i] == '\''? 0 : str[i] = ' ');
	}
	stringstream s(str);


	while (s >> word) vecstr.push_back(word);

	
	for (int i = 0, vsize = vecstr.size(); i < vsize; i++)
	{
		cout << vecstr[i] << endl;
	}
	cin.get();
	return 0;
}
