#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <initializer_list>

using namespace std;

int main()
{
	vector<string> v = {"abdc","badc","abc","abcd","ab" };
	auto is_less = [](const string& s1, const string& s2)
	{
		return (s1.compare(s2) < 0 ? true: false);
	};

	sort(v.begin(), v.end(), is_less);

	for (auto& x : v)
	{
		cout << x << endl;
	}
	
	cin.get();
	return 0;
}