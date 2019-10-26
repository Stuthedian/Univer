#pragma once


using namespace std;

class translate
{
public:
	translate(const char* path);
	~translate();
	void show_words();
	void find_translation(string word);
private:
	map<string, string> enru;
};

