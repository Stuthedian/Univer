#include <iostream>
#include <string>

using namespace std;

int main() 
{
	string s0 = "        I'm  a\ttext  ,from   some  words.      ";
	string divs = " \t\r\n,.:;";
	string word;
	bool inword = false;
	for (int i = 0, len = s0.size(), start; i < len; i++)
	{
		if (divs.find(s0[i]) == string::npos && inword == true) continue;
		if (divs.find(s0[i]) == string::npos && inword == false)
		{
			start = i;
			inword = true;
		}
		else if (divs.find(s0[i]) != string::npos && inword == true)
		{
			word = s0.substr(start, i - start);
			cout << word << endl;
			inword = false;
		}
	}
	cin.sync(); 
	cin.get(); 
	return 0;
}
