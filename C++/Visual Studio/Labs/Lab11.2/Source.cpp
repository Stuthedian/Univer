#include <iostream>
#include <vector>
#include <random>
#include <map>

using namespace std;

int main()
{
	default_random_engine rand_gen;
	uniform_int_distribution<> d(1, 50);

	vector<int> V(30);
	map<int, int> M;
	
	//decltype(M.try_emplace(declval<int>(), declval<int>())) Pair_type;
	decltype(M.emplace(declval<int>(), declval<int>())) Pair_type;

	for (int& x : V)
	{
		x = d(rand_gen);
		Pair_type = M.emplace(x, 1);
		//Pair_type = M.try_emplace(x, 1);
		if (Pair_type.second == false)
		{
			M.at(x)++;
		}
	}
		
	for (auto& x : M)
		cout << x.first << '\t' << x.second << endl;
	
	cin.get();
	return 0;
}