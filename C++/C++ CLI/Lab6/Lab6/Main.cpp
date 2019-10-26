#include "Main.h"

using namespace Lab6;

[STAThreadAttribute]
int main(array<System::String ^> ^args) 
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	Application::Run(gcnew Main());
	return 0;
}