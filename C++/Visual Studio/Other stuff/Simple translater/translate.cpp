#include "translate.h"



translate::translate(const char* path)
{
	stringstream ss;
	string en, ru, buff;
	ifstream fin(path, ios::in | ios::binary);
	while (!fin.eof())
	{
		getline(fin, buff);
		ss << buff;
		ss >> en >> ru;

		enru.insert(make_pair(en, ru));
	}
}


translate::~translate()
{
}

void translate::show_words()
{
	for (auto& t : enru)
	{
		cout << t.first << "\t" << t.second << endl;
	}
}

void translate::find_translation(string word)
{
	auto rslt = enru.find(word);
	if (rslt != enru.end())
	{
		cout << rslt->first << "\t" << rslt->second << endl;
	}
	else
	{
		cout << "Перевод отсутствует!\n";
	}
}
