#include <iostream>
#include <string>
#include <vector>
#include <cctype>

using namespace std;


int main()
{
	void findsegment(char* s);

	char* s = "Our TV company called ABC";

	findsegment(s);

	cin.get();
	return 0;
}

void findsegment(char* t)
{
	const int diff = 'a' - 'A';
	string s(t);
	for (int i = 0; i < s.size(); i++)
	{
		if (s[i] == ' ') s.erase(i, 1);
	}



	vector<string> v;
	string segment;

	for (int i = 0; i<s.size(); i++)
	{
		segment += s[i];
		int j = i + 1;
		for (; j<s.size(); j++)
		{
			if (isupper(s[j]))
			{
				if (isupper(segment.back()))
				{
					if (s[j] > segment.back())
					{
						segment += s[j];
					}
					else
					{
						break;
					}
				}
				else
				{
					if ((s[j] + diff) > segment.back())
					{
						segment += s[j];
					}
					else
					{
						break;
					}
				}
			}
			else
			{
				if (isupper(segment.back()))
				{
					if (s[j] > (segment.back() + diff))
					{
						segment += s[j];
					}
					else
					{
						break;
					}
				}
				else
				{
					if (s[j] > segment.back())
					{
						segment += s[j];
					}
					else
					{
						break;
					}
				}
			}
		}
		v.push_back(segment);
		i += j - i - 1;
		segment.clear();
	}

	int n = 0;

	for (int i = 0; i < v.size(); i++)
	{
		if (v[i].size() > n) n = v[i].size();
	}

	for (int i = 0; i < v.size(); i++)
	{
		if (v[i].size() == n)cout << v[i] << endl;;
	}
	return;
}