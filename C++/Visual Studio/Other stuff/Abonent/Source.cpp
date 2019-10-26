#include <iostream>
#include <vector>
#include <string>

using namespace std;

struct abonent
{
	string tel_num;
	string abon_fam;
};

class assoc_arr
{
public:
	void add(string tel, string fam)
	{
		abonent ab;
		ab.tel_num = tel;
		ab.abon_fam = fam;
		tel_arr.push_back(ab);
	}
	void del(string fam)
	{
		for (size_t i = 0; i < tel_arr.size(); i++)
		{
			if (tel_arr[i].abon_fam == fam)
				tel_arr.erase(tel_arr.begin() + i);
		}
	}
	void show()
	{
		for (size_t i = 0; i < tel_arr.size(); i++)
		{
			cout << "Tel number: " << tel_arr[i].tel_num
				<< "  Abonent fam: " << tel_arr[i].abon_fam << endl;
		}
	}
private:
	vector<abonent> tel_arr;
};


int main()
{
	assoc_arr arr;
	char choice;
	bool flag = true;
	while (flag)
	{
		cout << "a - add record to array\nd - delete record from array\ns - show all records\nq - quit" << endl;
		cin >> choice;
		switch (choice)
		{
		case 'a':
		{
			string tel, fam;
			cout << "Enter number" << endl;
			cin >> tel;
			cout << "Enter surname" << endl;
			cin >> fam;
			arr.add(tel, fam);
		}break;
		case 'd':
		{
			string fam;
			cout << "Enter surname" << endl;
			cin >> fam;
			arr.del(fam);
		}break;
		case 's':
			arr.show(); break;
		case 'q':
			flag = false; break;
		default:
			break;
		}
	}
	cin.get();
	return 0;
}