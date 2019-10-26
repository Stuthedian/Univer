#include "Main.h"
#include "Editor.h"

System::Void Lab2::Main::‚˚ıÓ‰ToolStripMenuItem_Click(System::Object ^ sender, System::EventArgs ^ e)
{
	Close();
	return System::Void();
}

System::Void Lab2::Main::ÒÓÁ‰‡Ú¸ToolStripMenuItem_Click(System::Object ^ sender, System::EventArgs^  e)
{
	Editfile("New" + Formcount + ".txt", "");
}

System::Void Lab2::Main::ÓÚÍ˚Ú¸‘‡ÈÎToolStripMenuItem_Click(System::Object ^ sender, System::EventArgs ^ e)
{
	openFileDialog1->ShowDialog();
	if (openFileDialog1->FileName == nullptr) return;
	try
	{
		auto Reader = gcnew IO::StreamReader(openFileDialog1->FileName, System::Text::Encoding::GetEncoding(1251));
		Editfile(openFileDialog1->FileName, Reader->ReadToEnd());
		Reader->Close();
	}
	catch (IO::FileNotFoundException^)
	{
		return;
	}
	catch (Exception^ e) 
	{ 
		MessageBox::Show(e->Message, "Œ¯Ë·Í‡",MessageBoxButtons::OK,MessageBoxIcon::Exclamation);
	}
}

System::Void Lab2::Main::Editfile(System::String ^ Filename, System::String ^ Filecontents)
{
	Editor^ ed = gcnew Editor(this);
	int size[2]= {300,300}; 
	String ^ split = " ,.:\txX";
	array <Char> ^ spliters = split->ToCharArray(); 
	String ^ line = toolStripTextBox1->Text; 
	array <String^> ^ words = line->Split (spliters); 
	bool ok=true; 
	if (words->Length>1) 
		for (int i=0; i<2; i++) 
		{ 
			try { 
				int n=System::Convert::ToInt32(words[i]); 
				if (n==0) n=size[i];
				else if (n<0) n=-n;
				System::Drawing::Rectangle scr = System::Windows::Forms::Screen::PrimaryScreen->WorkingArea;
				int screen_size[2] = { scr.Width, scr.Height }; 
				if (n>screen_size[i]) n = screen_size[i];
				size[i] = n;
			} catch (...) { ok=false; }
		}
	else ok=false; 
	toolStripTextBox1->Text = size[0]+"x"+size[1]; 
	ed->Size = System::Drawing::Size (size[0], size[1]);
	ed->Filename = Filename;
	ed->Filecontents = Filecontents;
	ed->Text += L" ó " + Filename;
	ed->textBox1->Text = Filecontents;
	ed->Show();
	Formcount++;
	return System::Void();
}

System::Void Lab2::Main::Main_Load(System::Object ^ sender, System::EventArgs ^ e)
{
	Formcount = 0;
	return System::Void();
}

System::Void Lab2::Main::Dec()
{
	Formcount--;
	return System::Void();
}

System::Void Lab2::Main::Main_FormClosing(System::Object ^ sender, System::Windows::Forms::FormClosingEventArgs ^ e)
{
	if (Formcount > 0) 
	{
		auto MBox = MessageBox::Show("—Ì‡˜‡Î‡ Á‡ÍÓÈÚÂ ‰Ó˜ÂÌËÂ ÓÍÌ‡","œÓÒÚÓÈ Â‰‡ÍÚÓ",   
			MessageBoxButtons::OK,MessageBoxIcon::Exclamation);
		e->Cancel = true; 
	}
	return System::Void();
}

System::Void Lab2::Editor::writefile()
{
	try
	{
		auto Writer = gcnew IO::StreamWriter(Filename, false, System::Text::Encoding::GetEncoding(1251));
		Writer->Write(textBox1->Text);  
		Writer->Close(); 
	}
	catch (Exception^ e)
	{
		MessageBox::Show(e->Message, "Œ¯Ë·Í‡",MessageBoxButtons::OK,MessageBoxIcon::Exclamation); 
	}
	return System::Void();
}

System::Void Lab2::Editor::toolStripOpenButton_Click(System::Object ^ sender, System::EventArgs ^ e)
{
	openFileDialog1->ShowDialog();
	if (openFileDialog1->FileName == nullptr) return;
	try
	{
		auto Reader = gcnew IO::StreamReader(openFileDialog1->FileName, System::Text::Encoding::GetEncoding(1251));
		Filename = openFileDialog1->FileName;
		Filecontents = Reader->ReadToEnd();
		Text += L" ó " + Filename;
		textBox1->Text = Filecontents;
		Reader->Close();
	}
	catch (IO::FileNotFoundException^)
	{
		return;
	}
	catch (Exception^ e) 
	{ 
		MessageBox::Show(e->Message, "Œ¯Ë·Í‡",MessageBoxButtons::OK,MessageBoxIcon::Exclamation);
	}
	return System::Void();
}

System::Void Lab2::Editor::toolStripSaveButton_Click(System::Object ^ sender, System::EventArgs ^ e)
{
	writefile();
	return System::Void();
}

System::Void Lab2::Editor::Editor_FormClosed(System::Object ^ sender, System::Windows::Forms::FormClosedEventArgs ^ e)
{
	parentMain->Dec();
	return System::Void();
}
