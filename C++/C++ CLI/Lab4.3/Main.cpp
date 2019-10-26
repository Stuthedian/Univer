#include "Main.h"

using namespace Lab4_3; 

[STAThreadAttribute]
int main(cli::array<System::String ^> ^args) {
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	Application::Run(gcnew Main()); 
	return 0;
}

