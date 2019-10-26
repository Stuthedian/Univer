#include "Main.h"

using namespace Lab3; 

[STAThreadAttribute]
int main(array<System::String ^> ^args) {
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	Application::Run(gcnew Main()); 
	return 0;
}

Void Lab3::Main::loadFile(String ^ Filename, String ^ Filecontents)
{
	dataGridView1->RowCount = 1;
	for (size_t i = 0; i < dataGridView1->ColumnCount; i++)
	{
		dataGridView1->Rows[0]->Cells[i]->Value = nullptr;
	}
	array<array<System::String ^>^> ^ records;
	filename = gcnew String(Filename);
	if(this->Text->IndexOf(L'—') != -1) 
		this->Text = this->Text->Remove(this->Text->IndexOf(L'—')-1);
	this->Text += L" — " + 
		Filename->Substring(Filename->LastIndexOf(L'\\')+1,Filename->LastIndexOf(L'.')-(Filename->LastIndexOf(L'\\')+1));
	auto str = Filecontents->Split(gcnew array<wchar_t>{L'\n'}, StringSplitOptions::RemoveEmptyEntries);
	records = gcnew array<array<System::String ^>^>(str->Length);
	for (size_t i = 0; i < str->Length; i++)
	{
		auto str2 = str[i]->Split(gcnew array<wchar_t>{L' ', L'\t'}, StringSplitOptions::RemoveEmptyEntries);
		records[i] = gcnew array<System::String ^>(str2->Length);
		for (size_t j = 0; j < str2->Length; j++)
		{
			records[i][j] = str2[j];
		}
		dataGridView1->Rows->Add(records[i]);
	}
	isopenfile = true;
	dataGridView1->Enabled = true;
	ñîõðàíèòüToolStripMenuItem->Enabled = true;
	return Void();
}

System::Void Lab3::Main::îòêðûòüToolStripMenuItem_Click(System::Object ^ sender, System::EventArgs ^ e)
{
	openFileDialog1->ShowDialog();
	if (openFileDialog1->FileName == "")
		return;
	else
	{
		try
		{
			auto Reader = gcnew IO::StreamReader(openFileDialog1->FileName, System::Text::Encoding::GetEncoding(65001));
			loadFile(openFileDialog1->FileName, Reader->ReadToEnd());
			Reader->Close();
		}
		catch (Exception^ e) 
		{ 
			MessageBox::Show(e->Message, "Îøèáêà",MessageBoxButtons::OK,MessageBoxIcon::Exclamation);
		}
	}
	
	return System::Void();
}

System::Void Lab3::Main::dataGridView1_CellValueChanged(System::Object ^ sender, System::Windows::Forms::DataGridViewCellEventArgs ^ e)
{
	ischanged = true;
	if (isopenfile)
	{
		DataGridViewCell^ cell = dataGridView1->Rows[e->RowIndex]->Cells[e->ColumnIndex];
		if (e->ColumnIndex >= 0 && e->ColumnIndex <= 2)
		{
			if (Regex::Match(cell->Value->ToString(), gcnew String("[^À-ßà-ÿ¨¸A-Za-z-]"), RegexOptions::ECMAScript)->Success)
				cell->ErrorText = "Íåäîïóñòèìûå ñèìâîëû â ÔÈÎ";
			else cell->ErrorText = "";
		}
		
	}
	
	return System::Void();
}

System::Void Lab3::Main::Main_Load(System::Object ^ sender, System::EventArgs ^ e)
{
	isopenfile = false;
	dataGridView1->Enabled = false;
	ñîõðàíèòüToolStripMenuItem->Enabled = false;
	ischanged = false;
	return System::Void();
}

System::Void Lab3::Main::ñîõðàíèòüToolStripMenuItem_Click(System::Object ^ sender, System::EventArgs ^ e)
{
	ischanged = false;
	for (size_t i = 0; i < dataGridView1->RowCount-1; i++)
	{
		for (size_t j = 0; j < dataGridView1->ColumnCount; j++)
		{
			if (dataGridView1->Rows[i]->Cells[j]->ErrorText != "")
			{
				MessageBox::Show("Ïðèñóòñòâóþò íåäîïóñòèìûå çíà÷åíèÿ â ÿ÷åéêàõ", "Ñîõðàíåíèå îòìåíåíî");
				return;
			}
			else if (dataGridView1->Rows[i]->Cells[j]->Value == nullptr)
			{
				MessageBox::Show("Ïðèñóòñòâóþò ïóñòûå ÿ÷åéêè", "Ñîõðàíåíèå îòìåíåíî");
				return;
			}

		}
	}
	if (filename != nullptr)
	{
		saveFileDialog1->FileName = filename;
	}
	else
	{
		saveFileDialog1->ShowDialog();
		if (saveFileDialog1->FileName == "")
			return;
	}
	try
	{
		auto Writer = gcnew IO::StreamWriter(saveFileDialog1->FileName, false, System::Text::Encoding::GetEncoding(65001));
		String^ records = gcnew String("");
		for (size_t i = 0; i < dataGridView1->RowCount-1; i++)
		{
			for (size_t j = 0; j < dataGridView1->ColumnCount; j++)
			{
				if (j == 0)
					records += dataGridView1->Rows[i]->Cells[j]->Value->ToString();
				else
					records += " " + dataGridView1->Rows[i]->Cells[j]->Value->ToString();
			}
			records += "\n";
		}
		Writer->Write(records);
		Writer->Close();
	}
	catch (Exception^ e) 
	{ 
		MessageBox::Show(e->Message, "Îøèáêà",MessageBoxButtons::OK,MessageBoxIcon::Exclamation);
	}
	if(this->Text->IndexOf(L'—') != -1) 
		this->Text = this->Text->Remove(this->Text->IndexOf(L'—')-1);
	this->Text += L" — " + 
		saveFileDialog1->FileName->Substring(saveFileDialog1->FileName->LastIndexOf(L'\\')+1,saveFileDialog1->FileName->LastIndexOf(L'.')-(saveFileDialog1->FileName->LastIndexOf(L'\\')+1));
	return System::Void();
}

System::Void Lab3::Main::dataGridView1_CellBeginEdit(System::Object ^ sender, System::Windows::Forms::DataGridViewCellCancelEventArgs ^ e)
{
	ôàéëToolStripMenuItem->Enabled = false;
	return System::Void();
}

System::Void Lab3::Main::dataGridView1_CellEndEdit(System::Object ^ sender, System::Windows::Forms::DataGridViewCellEventArgs ^ e)
{
	ôàéëToolStripMenuItem->Enabled = true;
	return System::Void();
}

System::Void Lab3::Main::ñîçäàòüToolStripMenuItem_Click(System::Object ^ sender, System::EventArgs ^ e)
{
	dataGridView1->Enabled = true;
	filename = nullptr;
	ñîõðàíèòüToolStripMenuItem->Enabled = true;
	ischanged = true;
	return System::Void();
}

System::Void Lab3::Main::Main_FormClosing(System::Object ^ sender, System::Windows::Forms::FormClosingEventArgs ^ e)
{
	if (ischanged)
	{
		if (MessageBox::Show("Åñòü íåñîõðàí¸ííûå èçìåíåíèÿ. Âû äåéñòâèòåëüíî õîòèòå âûéòè?", "Âûéòè?", MessageBoxButtons::YesNo)
			== System::Windows::Forms::DialogResult::No)
			e->Cancel = true;
	}
		
	return System::Void();
}

System::Void Lab3::Main::dataGridView1_UserDeletedRow(System::Object ^ sender, System::Windows::Forms::DataGridViewRowEventArgs ^ e)
{
	ischanged = true;
	return System::Void();
}

