#include "Main.h"
#include "SearchForm.h"
using namespace Lab7; 

[STAThreadAttribute]
int main(array<System::String ^> ^args) {
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	Application::Run(gcnew Main()); 
	return 0;
}

Void Lab7::Main::loadFile(String ^ Filename, String ^ Filecontents)
{
	/*dataGridView1->RowCount = 1;
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
	сохранитьToolStripMenuItem->Enabled = true;*/
	return Void();
}

System::Void Lab7::Main::открытьToolStripMenuItem_Click(System::Object ^ sender, System::EventArgs ^ e)
{
	openFileDialog1->ShowDialog();
	if (IO::File::Exists(openFileDialog1->FileName))
	{
		BaseName = openFileDialog1->FileName;
		Table = gcnew DataTable();
		Set = gcnew DataSet();
		Set->ReadXml(BaseName);
		String ^ StringXML = Set->GetXml();
		dataGridView1->DataSource = Set->Tables["Books"];
		dataGridView1->AutoResizeColumns();
	}
	else
	{
		MessageBox::Show("Файл по данному пути отсутствует", "Ошибка");
		return;
	}
	return System::Void();
}

System::Void Lab7::Main::dataGridView1_CellValueChanged(System::Object ^ sender, System::Windows::Forms::DataGridViewCellEventArgs ^ e)
{
	if (e->ColumnIndex == 0 || e->ColumnIndex == 4)
	{
		auto cell = dataGridView1->Rows[e->RowIndex]->Cells[e->ColumnIndex];
		int b;
		if (!Int32::TryParse(cell->Value->ToString(), b))
		{
			cell->ErrorText = "Данная запись не является целым числом";
		}
		else
		{
			cell->ErrorText = "";
		}
	}
	return System::Void();
}

System::Void Lab7::Main::Main_Load(System::Object ^ sender, System::EventArgs ^ e)
{
	BaseName = "Library.xml";
	Table = gcnew DataTable();
	Set = gcnew DataSet();
	dataGridView1->DataSource = Table;
	Table->Columns->Add("Инвентарный номер");
	Table->Columns->Add("Название");
	Table->Columns->Add("Ф.И.О. автора");
	Table->Columns->Add("Место издания");
	Table->Columns->Add("Год издания");
	Table->PrimaryKey = gcnew array<System::Data::DataColumn^>(1){Table->Columns["Инвентарный номер"]};
	Set->Tables->Add(Table);
	dataGridView1->AutoResizeColumns();
	//this->AutoSize = true;
	//this->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
	return System::Void();
}

System::Void Lab7::Main::сохранитьToolStripMenuItem_Click(System::Object ^ sender, System::EventArgs ^ e)
{
	saveFileDialog1->ShowDialog();
	if (saveFileDialog1->FileName != "")
	{
		BaseName = saveFileDialog1->FileName ;
		Table->TableName = "Books";
		Set->WriteXml(BaseName);
	}
}

System::Void Lab7::Main::dataGridView1_CellBeginEdit(System::Object ^ sender, System::Windows::Forms::DataGridViewCellCancelEventArgs ^ e)
{
	return System::Void();
}

System::Void Lab7::Main::dataGridView1_CellEndEdit(System::Object ^ sender, System::Windows::Forms::DataGridViewCellEventArgs ^ e)
{
	return System::Void();
}

System::Void Lab7::Main::Main_FormClosing(System::Object ^ sender, System::Windows::Forms::FormClosingEventArgs ^ e)
{
	if (ischanged)
	{
		if (MessageBox::Show("Есть несохранённые изменения. Вы действительно хотите выйти?", 
			"Выйти?", MessageBoxButtons::YesNo) == System::Windows::Forms::DialogResult::No)
			e->Cancel = true;
	}
	if(child != nullptr)
		child->Close();
	return System::Void();
}

System::Void Lab7::Main::dataGridView1_UserDeletedRow(System::Object ^ sender, System::Windows::Forms::DataGridViewRowEventArgs ^ e)
{
	/*ischanged = true;*/
	return System::Void();
}

System::Void Lab7::Main::поискToolStripMenuItem_Click(System::Object ^ sender, System::EventArgs ^ e)
{
	if (child == nullptr)
	{
		child = gcnew SearchForm(this);
		child->Show();
	}
	else
	{
		child->Focus();
	}
	return System::Void();
}

Void Lab7::Main::clear_child()
{
	child = nullptr;
	return Void();
}

